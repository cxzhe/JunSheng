using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JZExample.Model;

namespace JZExample
{
    public class AppContext
    {
        public BatchInfo[] BatchsToPrint { get; set; }

        public static readonly AppContext Instance = new AppContext();

        private AppContext()
        {
        }
    }
}
