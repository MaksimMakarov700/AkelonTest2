using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkelonTest2
{
    class Orders: ITable
    {
        public Orders()
        {
        
        }

        public string id = String.Empty;
        public string idProduct = String.Empty;
        public string idClient = String.Empty;
        public string number = String.Empty;
        public string values = String.Empty;
        public string date = String.Empty;

        public void ParseRow(List<string> list)
        {
            this.id = list[0] ?? String.Empty;
            this.idProduct = list[1] ?? String.Empty;
            this.idClient = list[2] ?? String.Empty;
            this.number = list[3] ?? String.Empty;
            this.values = list[4] ?? String.Empty;
            this.date = list[5] ?? String.Empty;
        }
    }
}
