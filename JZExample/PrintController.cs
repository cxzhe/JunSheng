using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
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


    public class PrintController
    {
        private Timer _timer;

        private BatchInfo[] _batchsToPrint;
        //private PrinterStatus? _currentPrinterStatus = null;
        private ClearSendStatus? _currentClearStatus = null;
        private X30Client _x30Client;
        private bool _initialized = false;
        private int _batchIndex = -1;
        private bool _isBusy = false;

        private string _fieldName;

        protected BatchInfo CurrentBatchInfo
        {
            get { return _batchsToPrint[_batchIndex]; }
        }

        public event EventHandler<PrintControllerLogEventArgs> Logged;



        //make sure printer is ready to print when create PrintController
        public PrintController(X30Client client, string fieldName, BatchInfo[] batchsToPrint)
        {
            _x30Client = client;
            _fieldName = fieldName;
            _batchsToPrint = batchsToPrint;

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
                //await _x30Client.TcpClient.ConnectAsync(Settings.Default.X30Ip, 21000);
                var status = await _x30Client.GetClearSendStatusAsync();
                //if(status == PrinterStatus.IncorrectState || status == PrinterStatus.Fault)
                //{
                //    _isBusy = false;
                //    OnLog($"打码机错误 -- {status.ToString()}");
                //    return;
                //}

                //if (status != _currentClearStatus)
                //{
                    if (status == ClearSendStatus.Ready)
                    {
                        CurrentBatchInfo.Status = BatchStatus.Printed;

                        var jobUpdateCommand = new JobCommand();
                        var bi = _batchsToPrint[_batchIndex + 1];

                        jobUpdateCommand.Fields.Add(_fieldName, bi.QRCodeContent);

                        //await _x30Client.TcpClient.ConnectAsync(Settings.Default.X30Ip, 21000);
                        await _x30Client.UpdateJob(jobUpdateCommand);

                        _currentClearStatus  = ClearSendStatus.NotReady;
                        _batchIndex++;
                        bi.Status = BatchStatus.CodeSent;
                        var message = $"{bi.SerinalNo} - {bi.QRCodeContent} 已赋码";
                        OnLog(message);
                    }
                    else
                    {
                        CurrentBatchInfo.Status = BatchStatus.Printing;
                        //OnLog("printing");
                }
                //}
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
                var jobUpdateCommand = new JobCommand();
                var bi = _batchsToPrint[0];

                jobUpdateCommand.Fields.Add(_fieldName, bi.QRCodeContent);

                //await _x30Client.TcpClient.ConnectAsync(Settings.Default.X30Ip, 21000);
                await _x30Client.UpdateJob(jobUpdateCommand);

                //_currentClearStatus = ClearSendStatus.NotReady;

                //log sent batch info
                _initialized = true;
                _batchIndex = 0;
              
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
        }
    }
}
