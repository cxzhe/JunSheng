using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using JZExample.Model;

namespace JZExample
{
    public class AppContext
    {
        //public BatchItem[] BatchsToPrint { get; set; }
        public JunShengDb DB { get; private set; }
        public BindingList<Batch> Batchs { get; private set; }
        public static readonly AppContext Instance = new AppContext();

        private AppContext()
        {
            DB = JunShengDb.Create();
        }

        public void Load()
        {
            Batchs = new BindingList<Batch>(DB.Table<Batch>().ToList());
            Batchs.AllowNew = false;
            foreach (var b in Batchs)
            {
                b.Items = DB.Table<BatchItem>().Where(bi => bi.BatchId == b.Id).ToArray();
            }
        }
    }
}
