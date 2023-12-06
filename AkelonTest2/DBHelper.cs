using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AkelonTest2
{
    class DBHelper
    {
        private List<Products> productsList { get; set; }
        private List<Clients> clientsList { get; set; }
        private List<Orders> ordersList { get; set; }
        XLWorkbook? workbook;
       

        public DBHelper(string FileName)
        {            
            try
            {
                workbook = new XLWorkbook(FileName);
            }
            catch 
            {
                Console.WriteLine("При открытии таблитцы произошла ошибка");
                Console.ReadKey();
                return;
            }
            Refresh(workbook);
        }

        private void Refresh(XLWorkbook workbook)
        {
            var worksheetProducts = workbook.Worksheets.ElementAt(0);
            var worksheetClients = workbook.Worksheets.ElementAt(1);
            var worksheetOrders = workbook.Worksheets.ElementAt(2);

            ExcelParser excelParser = new ExcelParser();
            productsList = excelParser.ReadTable<Products>(worksheetProducts);
            clientsList = excelParser.ReadTable<Clients>(worksheetClients);
            ordersList = excelParser.ReadTable<Orders>(worksheetOrders);
        }

        public void PrintGoldClient(string date)
        {
            if (string.IsNullOrEmpty(date)) return;
            if (!Regex.IsMatch(date, @"\b\d{2}\.\d{4}\b"))
            {
                Console.WriteLine("Не верный формат даты.");                
                return;
            }

            int max = ordersList.Where(x => x.date.Contains(date)).
                    GroupBy(g => g.idClient).OrderByDescending(o => o.Count()).Select(k => k.Count()).FirstOrDefault();
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
                    Console.WriteLine($"Золотой клиент id: {item.Key}");
                }                
            }
            else
            {
                Console.WriteLine($"Золотой клиент id: {goldClient.First().Key}");
            }
                          
        }

        public void EditClientContact()
        {
            //TODO переделать на работу с кешем
            Console.Write("Введите id клиента данные которого нужно изменить:");
            string id = Console.ReadLine();
            int index = 0;
            var worksheetClients = workbook.Worksheets.ElementAt(1);            

            for (int i = 2; i <= worksheetClients.Rows().Count(); i++)
            {
                if (worksheetClients.Cell(i, 1).Value.ToString() == id)
                {
                    index = i; 
                    break;
                }
            }
            if (index == 0) 
            {
                Console.WriteLine("Пользователь с таким id не найдено");
                return;
            }

            Console.Write("Введите название организации:");
            string org = Console.ReadLine();
            worksheetClients.Cell(index, 2).Value= org;

            Console.Write("Введите ФИО нового контактного лица:");
            string name = Console.ReadLine();
            worksheetClients.Cell(index, 4).Value = name;
            
            workbook.Save();
            Refresh(workbook);
            Console.WriteLine("Данные успешно записаны");

        }

        public void PrintProductInfo(string nameProduct)        
        {        
            if (string.IsNullOrWhiteSpace(nameProduct)) return;

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
