using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkelonTest2
{
    class DBHelper
    {
        List<Products> productsList { get; set; }
        List<Clients> clientsList { get; set; }
        List<Orders> ordersList { get; set; }

        public DBHelper(List<Products> productsList, List<Clients> clientsList, List<Orders> ordersList)
        {
            this.productsList = productsList;
            this.clientsList = clientsList;
            this.ordersList = ordersList;
        }

       

        public void PrintGoldClient(string date)
        {           
            var max = ordersList.Where(x => x.date.Contains(date)).
                    GroupBy(g => g.idClient).OrderByDescending(o => o.Count()).Select(k => k.Count()).First();
            var goldClient = ordersList.Where(x => x.date.Contains(date)).Select(x => x.idClient).
                    GroupBy(g => g).Where(h => h.Count() == max);
            
            if (goldClient == null)
            {
                Console.WriteLine("Клиентов за этот месяц не обнаружено");
            }
            else if (goldClient.Count() > 1)             
            {
                Console.WriteLine($"Золотых клиентов в этом месяце несколько.");
                foreach (var item in goldClient)
                {                    
                    Console.WriteLine($"Золотой клиент: {item.Key}");
                }                
            }
            else
            {
                Console.WriteLine($"Золотой клиент: {goldClient.First().Key}");
            }
                          
        }

        public void PrintProductInfo(string nameProduct)
        {        
            var product = productsList.Where(x => x.name == nameProduct).FirstOrDefault();
            if (product == null)
            {
                Console.WriteLine("Продукт с таким названием не обнаружен.");
            }
            else
            {
                var orders = ordersList.Where(x => x.idProduct == product.id);
                if (orders != null)
                {
                    Console.WriteLine($"Заказы товара \"{product.name}\":");
                    foreach (var order in orders)
                    {
                        var client = clientsList.Where(x => x.id == order.idClient).FirstOrDefault();
                        if (client != null)
                        {
                            Console.WriteLine($"Клиент: {client.name} Дата: {order.date} " +
                                $"Цена: {product.price} Кол-во {order.values} {product.unit}");
                        }
                    }
                }
                else 
                {
                    Console.WriteLine("Заказы для такого товара не найдены.");
                }
            }
        }

    }
}
