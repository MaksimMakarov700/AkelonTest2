using System.Formats.Tar;
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
            Action PressAnyKey = delegate ()
            {
                Console.WriteLine("Для возврата в меню нажмите любую кнопку");
                Console.ReadKey();
            };
            string? fileName = string.Empty;
            do
            {
                Console.Write($"Введите путь к файлу (Например \"C:\\1.xlsx\"): ");
                fileName = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(fileName))
                {
                    Console.WriteLine("Пустой ввод. Введите путь к файлу.");
                    continue;
                }
                if (File.Exists(fileName))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Файл не найден. введите корректный путь");
                }
            }
            while (true);

            DBHelper helper = new DBHelper(fileName);

            ConsoleKeyInfo cki;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Информация о товаре");
                Console.WriteLine("2. Изменение контактного лица");
                Console.WriteLine("3. Найти золотого клиента");
                Console.WriteLine("Для выхода из программы нажмите ESC");
                cki = Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.Write("Введите название продукта: ");
                        helper.PrintProductInfo(Console.ReadLine());
                        goto defaultExit;
                    case ConsoleKey.D2:
                        Console.Clear();
                        goto defaultExit;
                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.Write("Введите месяц и год, в формате мм.гггг: ");
                        helper.PrintGoldClient(Console.ReadLine());
                        goto defaultExit;
                    defaultExit:
                        PressAnyKey();
                        break;
                }
            }
            while (cki.Key != ConsoleKey.Escape);
            //string FileName = @"C:\1\1.xlsx"; // путь к Excel файлу      


        }
    }
}
