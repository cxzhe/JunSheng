using System;

using SQLite;

namespace JZExample.Model
{
    public class Batch
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string BatchNo { get; set; }
        public DateTime CreateTime { get; set; }

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
    }
}
