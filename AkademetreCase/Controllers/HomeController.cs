using AkademetreCase.Models;
using GemBox.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AkademetreCase.Controllers
{
    public class HomeController : Controller
    {
        private Info model = new Info();
        private static List<Info> FullData = new List<Info>();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Info info)
        {
            model = info;
            FullData.Add(model);
            return RedirectToAction("Index");


        }

        public ActionResult ExportExcel() 
        {

            DataSet data = new DataSet();
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            for (int i = 0; i < FullData.Count(); i++)
            {
                DataTable dataTable = new DataTable("Table " + (i + 1));
                dataTable.Columns.Add("İsim", typeof(string));
                dataTable.Columns.Add("Soyisim", typeof(string));
                dataTable.Columns.Add("Email", typeof(string));
                dataTable.Columns.Add("Adres", typeof(string));
                foreach (Info item in FullData)
                {

                    dataTable.Rows.Add(new object[] { item.Name, item.SurName, item.Email, item.Address });

                }


                data.Tables.Add(dataTable);

            }

            var workbook = new ExcelFile();
            foreach (DataTable dataTable in data.Tables)
            {
                ExcelWorksheet worksheet = workbook.Worksheets.Add(dataTable.TableName);

                // Insert DataTable to an Excel worksheet.
                worksheet.InsertDataTable(dataTable,
                    new InsertDataTableOptions()
                    {
                        ColumnHeaders = true
                    });
            }

            workbook.Save("C:\\Users\\PC\\Desktop\\Sheets\\new.xlsx");
            return RedirectToAction("Index");
            
        }
        
    }
}
