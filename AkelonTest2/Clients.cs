using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkelonTest2
{
    class Clients: ITable
    {
        public Clients(string id, string name, string adress, string contact)
        {
            this.id = id;
            this.name = name;
            this.adress = adress;
            this.contact = contact;
        }
        public Clients() { }

        public string id { get; set; }
        public string name { get; set; }
        public string adress { get; set; }
        public string contact { get; set; }

        public void ParseRow(List<string> list)
        {
            this.id = list[0] ?? String.Empty;
            this.name = list[1] ?? String.Empty;
            this.adress = list[2] ?? String.Empty;
            this.contact = list[3] ?? String.Empty;
        }
    }
}
