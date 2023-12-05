using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkelonTest2
{
    class DBHelper
    {
        public DBHelper(List<Products> productsList, List<Clients> clientsList, List<Orders> ordersList)
        {
            this.productsList = productsList;
            this.clientsList = clientsList;
            this.ordersList = ordersList;
        }

        List<Products> productsList { get; set; }
        List<Clients> clientsList { get; set; }
        List<Orders> ordersList { get; set; }

        public void PrintProductInfo(string nameProduct)
        {        
            var product = productsList.Where(x => x.name == nameProduct).FirstOrDefault();
            if (product == null)
            {
                Console.WriteLine("Продукт с таким названием не обнаружен");
            }
            else
            {
                var orders = ordersList.Where(x => x.idProduct == product.id);
                foreach (var item in orders)
                {
                    var client = clientsList.Where(x => x.id == item.idClient).FirstOrDefault();
                    Console.WriteLine($"{client.name} {item.date} {product.price}");
                }
            }
        }

    }
}
