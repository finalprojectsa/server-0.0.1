using System;
using DAL.DALFolder;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DBFromExcel db = new DBFromExcel();
            db.ReadExcel();
        }
    }
}
