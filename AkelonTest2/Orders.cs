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
            this.id = String.Empty;
            this.idProduct = String.Empty;
            this.idClient = String.Empty;
            this.number = String.Empty;
            this.values = String.Empty;
            this.date = String.Empty;
        }

        public string id { get; set; }
        public string idProduct { get; set; }
        public string idClient { get; set; }
        public string number { get; set; }
        public string values { get; set; }
        public string date { get; set; }

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
