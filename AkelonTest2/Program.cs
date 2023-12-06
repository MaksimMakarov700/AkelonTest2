using System.IO;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2019.Excel.RichData2;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace AkelonTest2
{
    internal class Program
    {       

        static void Main(string[] args)
        {
            Action PressEsc = delegate ()
            {
                Console.WriteLine("Для выхода из программы нажмите ESC");
            };

            //Console.Write("Введите путь к файлу: ");
            string FileName;// = Console.ReadLine();
            FileName =@"C:\1\1.xlsx";
            ConsoleKeyInfo cki;
            do 
            {
                Console.Clear();                
                Console.WriteLine("1. Информация о товаре");
                Console.WriteLine("2. Изменение контактного лица");
                Console.WriteLine("3. Найти золотого клиента");
                //Console.WriteLine("Для выхода из программы нажмите ESC"); 
                PressEsc();
                cki = Console.ReadKey();
                if ( cki.Key== ConsoleKey.D1) 
                {
                    Console.WriteLine("fgfdg");
                }

            }
            while ( cki.Key!= ConsoleKey.Escape) ;

            //string FileName = @"C:\1\1.xlsx"; // путь к Excel файлу
            var workbook = new XLWorkbook(FileName);
            var worksheetProducts = workbook.Worksheets.ElementAt(0);
            var worksheetClients = workbook.Worksheets.ElementAt(1);
            var worksheetOrders = workbook.Worksheets.ElementAt(2);


            ExcelParser excelParser = new ExcelParser();
            List<Products> productsList = excelParser.ReadTable<Products>(worksheetProducts);
            List<Clients> clientsList = excelParser.ReadTable<Clients>(worksheetClients);
            List<Orders> ordersList = excelParser.ReadTable<Orders>(worksheetOrders);

            DBHelper helper = new DBHelper(productsList, clientsList, ordersList);
            
            helper.PrintGoldClient("03.2023");

            string s = Console.ReadLine();
            helper.PrintProductInfo(s);
           


            /*

            foreach (var item in productsList)
            {
                Console.WriteLine($"{item.id}|{item.name}|{item.unit}|{item.price}|");
            }

            foreach (var item in clientsList)
            {
                Console.WriteLine($"{item.id}|{item.name}|{item.adress}|{item.contact}|");
            }

            foreach (var item in ordersList)
            {
                Console.WriteLine($"{item.id}|{item.idProduct}|{item.idClient}|{item.idClient}|");
            }*/

            Console.WriteLine("Hello, World!");
        }


    }
}
