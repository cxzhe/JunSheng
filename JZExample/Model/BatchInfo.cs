using System;

using SQLite;

namespace JZExample.Model
{
    public class BatchInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string BatchNo { get; set; }
        public int SerinalNo { get; set; }
        public string QRCodeContent { get; set; }
    }
}
