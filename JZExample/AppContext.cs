﻿using System;
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
            var bs = DB.Table<Batch>().OrderByDescending(b => b.CreateTime).ToList();
            Batchs = new BindingList<Batch>(bs);
            Batchs.AllowNew = false;
            foreach (var b in Batchs)
            {
                b.Items = DB.Table<BatchItem>().Where(bi => bi.BatchId == b.Id).ToArray();
                if(b.CompleteCount == 0)
                {
                    b.CompleteCount = b.Items.Length;
                }
            }
        }
    }
}
