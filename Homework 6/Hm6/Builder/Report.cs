using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hm6
{
    public class Report
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public string Footer { get; set; }

        public void Display()
        {
            Console.WriteLine(Header);
            Console.WriteLine(Content);
            Console.WriteLine(Footer);
        }
    }

}
