using System;
using System.ComponentModel;

using SQLite;

namespace JZExample.Model
{
    public class Batch : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _completeCount;


        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string BatchNo { get; set; }
        public DateTime CreateTime { get; set; }

        public int CompleteCount
        {
            get { return _completeCount; }
            set
            {
                _completeCount = value;
                OnPropertyChanged(nameof(CompleteCount));
            }
        }

        [Ignore]
        public BatchItem[] Items { get; set; }

        public int ItemsCount
        {
            get
            {
                return Items?.Length ?? 0;
            }
        }

        public string PrintText
        {
            get { return "打码"; }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
