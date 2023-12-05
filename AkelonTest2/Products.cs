using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkelonTest2
{
   class Products: ITable
    {
        public Products()
        {
            this.id = String.Empty;
            this.name = String.Empty;
            this.unit = String.Empty;
            this.price = String.Empty;
        }

        public string id { get; set; }   
        public string name { get; set; }
        public string unit { get; set; }
        public string price { get; set; }

        public void ParseRow(List<string> list)
        {
            this.id = list[0] ?? String.Empty;
            this.name = list[1] ?? String.Empty;
            this.unit = list[2] ?? String.Empty;
            this.price =list[3] ?? String.Empty;
        }
    }
}
