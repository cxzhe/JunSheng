using System;
using System.ComponentModel;

using SQLite;

namespace JZExample.Model
{
    public enum BatchStatus
    {
        Pending = 0,
        CodeSent,
        Printing,
        Printed,
        Confirmed,
        NG
    }

    public class BatchInfo: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private BatchStatus _status;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string BatchNo { get; set; }
        public int SerinalNo { get; set; }
        public string QRCodeContent { get; set; }
        public BatchStatus Status
        {
            get { return _status; }
            set
            {
                if(value != _status)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }

    //public class BatchOperationInfo
    //{
    //    [PrimaryKey]
    //    public int BatchId { get; set; }
    //    public BatchStatus Status { get; set; }
    //    public DateTime Time { get; set; }
    //}
}
