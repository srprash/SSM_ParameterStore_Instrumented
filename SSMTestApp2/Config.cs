using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSMTestApp2
{
    public class DemoConfig
    {
        public string TestItem { get; set; }
        public DemoSubConfig SubConfig { get; set; }
    }

    public class DemoSubConfig
    {
        public string SubItem { get; set; }
    }
}
