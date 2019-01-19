using System;

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

    public class BatchInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string BatchNo { get; set; }
        public int SerinalNo { get; set; }
        public string QRCodeContent { get; set; }
        public BatchStatus Status { get; set; }
    }
}
