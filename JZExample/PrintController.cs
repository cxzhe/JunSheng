using System;
//using System.Threading;
using System.Linq;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Windows.Forms;

using JZExample.Model;

namespace JZExample
{
    public class PrintControllerLogEventArgs : EventArgs
    {
        public string Message { get; set; }
        public PrintControllerLogEventArgs(string message)
        {
            Message = message;
        }
    }

    public class CodeScanedEventArgs: EventArgs
    {
        public string Code { get; set; }
        public CodeScanedEventArgs(string code)
        {
            Code = code;
        }
    }

    public class PrintController
    {
        private Timer _timer;
        
        public X30Client X30Client { get; private set; }
        public string FieldName { get; set; }

        private BatchItem[] _batchsToPrint;
        private Batch _batch;

        private ClearSendStatus? _currentClearStatus = null;
       
        private bool _initialized = false;
        private int _batchIndex = -1;
        private bool _isBusy = false;

        public SerialPort SerialPort { get; private set; }

        public bool IsComplete
        {
            get
            {
                return _batchIndex == _batchsToPrint.Length - 1 ||
                        _batchsToPrint.Count(i => i.Status == BatchStatus.Confirmed) >= _batch.CompleteCount;
            }
        }

        private bool IsFatalError
        {
            get
            {
                int errorCount = 6;
                if (_batchIndex < errorCount)
                {
                    return false;
                }
                BatchItem[] lastThressItems = new BatchItem[errorCount];
                Array.Copy(_batchsToPrint, _batchIndex - errorCount, lastThressItems, 0, errorCount);
                return lastThressItems.All((i) => i.Status != BatchStatus.Confirmed);
            }
        }

        public int BatchIndex
        {
            get { return _batchIndex; }
        }

        public BatchItem[] BatchsToPrint
        {
            get { return _batchsToPrint; }
        }

        protected BatchItem CurrentBatchItem
        {
            get { return _batchsToPrint[_batchIndex]; }
        }

        public event EventHandler<PrintControllerLogEventArgs> Logged;
        public event EventHandler<EventArgs> Printed;
        public event EventHandler<EventArgs> PrintCompleted;
        public event EventHandler<CodeScanedEventArgs> CodeScaned;
        public event EventHandler<EventArgs> FatalError;


        //make sure printer is ready to print when create PrintController
        public PrintController(Batch batch)
        {
            X30Client = new X30Client();

            _batch = batch;
            _batchsToPrint = batch.Items;

            SerialPort = new SerialPort();

            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += _timer_Tick;
        }

        private void OnLog(string message)
        {
            Logged?.Invoke(this, new PrintControllerLogEventArgs(message));
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if(_initialized)
            {
                UpdateJob();
            }
            else
            {
                Setup();
            }
        }

        private async void UpdateJob()
        {
            if (_isBusy)
            {
                OnLog("上次请求还未处理");
                return;
            }

            _isBusy = true;

            try
            {
                var status = await X30Client.GetClearSendStatusAsync();
                if (status == ClearSendStatus.Ready)
                {
                    if(IsComplete)
                    {
                        _timer.Stop();
                        await X30Client.StateChangeAsync(StateChangeStatus.Ready);
                        PrintCompleted?.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        CurrentBatchItem.Status = BatchStatus.Printed;
                        AppContext.Instance.DB.Update(CurrentBatchItem);

                        if(IsFatalError)
                        {
                            _timer.Stop();
                            FatalError?.Invoke(this, EventArgs.Empty);
                            await X30Client.StateChangeAsync(StateChangeStatus.Ready);
                            return;
                        }
                        var jobUpdateCommand = new JobCommand();
                        var bi = _batchsToPrint[_batchIndex + 1];

                        jobUpdateCommand.Fields.Add(FieldName, bi.QRCodeContent);

                        await X30Client.UpdateJob(jobUpdateCommand);

                        _currentClearStatus = ClearSendStatus.NotReady;
                        _batchIndex++;
                        bi.Status = BatchStatus.CodeSent;
                        AppContext.Instance.DB.Update(bi);
                        var message = $"{bi.SerinalNo} - {bi.QRCodeContent} 已赋码";
                        OnLog(message);
                        Printed?.Invoke(this, EventArgs.Empty);
                    }
                }
                else
                {
                    CurrentBatchItem.Status = BatchStatus.Printing;
                }
            }
            catch (Exception e)
            {
                var message = $"错误--{e.Message}";
                OnLog(message);
            }

            _isBusy = false;
        }

        private async void Setup()
        {
            if (_isBusy)
            {
                OnLog("上次请求还未处理");
                return;
            }

            _isBusy = true;
            try
            {
                await X30Client.StateChangeAsync(StateChangeStatus.Producing);
                var jobUpdateCommand = new JobCommand();
                var bi = _batchsToPrint[_batch.StartIndex];

                jobUpdateCommand.Fields.Add(FieldName, bi.QRCodeContent);

                await X30Client.UpdateJob(jobUpdateCommand);

                //log sent batch info
                _initialized = true;
                _batchIndex = _batch.StartIndex;
              
                bi.Status = BatchStatus.CodeSent;
                var message = $"成功初始化--{bi.SerinalNo} - {bi.QRCodeContent} 已赋码";
                OnLog(message);
            }
            catch (Exception e)
            {
                var message = $"初始化失败--{e.Message}";
                OnLog(message);
            }

            _isBusy = false;
        }

        public void Start()
        {
            if(!_timer.Enabled)
            {
                _timer.Start();
            }

            Task.Run(() =>
            {
                while (SerialPort.IsOpen)
                {
                    try
                    {
                        string code = SerialPort.ReadLine().Trim();
                        CodeScaned?.Invoke(this, new CodeScanedEventArgs(code));
                    }
                    catch (Exception)
                    {
                    }
                }
            });
        }

        public void Close()
        {
            X30Client.TcpClient.Close();
            SerialPort.Close();
        }
    }
}
