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
       
        }

        public string id = String.Empty;
        public string name = String.Empty;
        public string unit = String.Empty;
        public string price = String.Empty;

        public void ParseRow(List<string> list)
        {
            this.id = list[0] ?? String.Empty;
            this.name = list[1] ?? String.Empty;
            this.unit = list[2] ?? String.Empty;
            this.price =list[3] ?? String.Empty;
        }
    }
}
