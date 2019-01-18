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
    public class PrintController
    {
        public BatchInfo[] _batchsToPrint;
        private Timer _timer;
        private PrinterStatus? _currentPrinterStatus = null;
        private X30Client _x30Client;
        private bool _initialized = false;
        private int _batchIndex = -1;
        private bool _isBusy = false;

        public string QRFieldName { get; set; }


        //make sure printer is ready to print when create PrintController
        public PrintController(X30Client client, string fieldName, BatchInfo[] batchsToPrint)
        {
            _x30Client = client;
            QRFieldName = fieldName;
            _batchsToPrint = batchsToPrint;

            _timer = new Timer();
            _timer.Interval = 100;
            _timer.Tick += _timer_Tick;
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
                return;
            }

            _isBusy = true;

            try
            {
                var status = await _x30Client.GetPrinterStatusAsync();
                if(status == PrinterStatus.IncorrectState || status == PrinterStatus.Fault)
                {
                    _isBusy = false;
                    return;
                }

                if (status != _currentPrinterStatus)
                {
                    if (status == PrinterStatus.ReadyToPrint)
                    {
                        var jobUpdateCommand = new JobCommand();
                        var bi = _batchsToPrint[_batchIndex + 1];

                        jobUpdateCommand.Fields.Add(QRFieldName, bi.QRCodeContent);

                        await _x30Client.UpdateJob(jobUpdateCommand);

                        //log sent batch info

                        _currentPrinterStatus = status;
                        _batchIndex++;
                        
                    }
                }
            }
            catch (Exception e)
            {

            }

            _isBusy = false;
        }

        private async void Setup()
        {
            if (_isBusy)
            {
                return;
            }

            _isBusy = true;
            try
            {
                var status = await _x30Client.GetPrinterStatusAsync();
                if (status == PrinterStatus.ReadyToPrint)
                {
                    _currentPrinterStatus = status;

                    var jobUpdateCommand = new JobCommand();
                    var bi = _batchsToPrint[0];

                    jobUpdateCommand.Fields.Add(QRFieldName, bi.QRCodeContent);

                    await _x30Client.UpdateJob(jobUpdateCommand);

                    //log sent batch info
                    _initialized = true;
                    _batchIndex = 0;
                }
            }
            catch (Exception e)
            {
               
            }

            _isBusy = false;

        }

        public void Start()
        {
            if (_initialized)
            {
                return;
            }

            _timer.Start();
        }
    }
}
