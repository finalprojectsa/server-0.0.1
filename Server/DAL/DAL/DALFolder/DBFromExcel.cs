using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using OfficeOpenXml;
using System.IO;

namespace DAL.DALFolder
{
    public class DBFromExcel
    {
        DBcontext db = new DBcontext();
        public void ReadExcel()
        {
            Console.WriteLine("inEXcel");
            using (var package = new ExcelPackage(new FileInfo("../../../../files/src.xlsx")))
            {
                var firstSheet = package.Workbook.Worksheets["sheet1"];
                for (int i = 2; firstSheet.Cells[$"C{i}"].Text != ""; i++)
                {
                    Console.WriteLine("inEXcel");
                    Console.WriteLine(firstSheet.Cells[$"A{i}"].Text);
                    People p = new People()
                    {
                        LastName = firstSheet.Cells[$"C{i}"].Text,
                        FirstName = firstSheet.Cells[$"D{i}"].Text,
                        City = firstSheet.Cells[$"G{i}"].Text,
                        Street = firstSheet.Cells[$"F{i}"].Text,
                        FatherCode = Convert.ToInt32(firstSheet.Cells[$"J{i}"].Text),
                        FatherInLawCode = Convert.ToInt32(firstSheet.Cells[$"I{i}"].Text),
                        Telephone = firstSheet.Cells[$"K{i}"].Text,
                        Cellephone = firstSheet.Cells[$"L{i}"].Text,
                        Title = firstSheet.Cells[$"M{i}"].Text,
                        Suffix = firstSheet.Cells[$"N{i}"].Text,
                        EducationPlace = "PP LL",
                        DavenPlace = "בית מדרש"
                    };

                    db.People.Add(p);
                    Console.WriteLine(db.People);
                    db.SaveChanges(); 
                }
            }
            Console.ReadLine();
        }
    }
}