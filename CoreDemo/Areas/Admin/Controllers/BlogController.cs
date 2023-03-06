using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;

namespace CoreDemo.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1, 1).Value = "Blog ID";
                workSheet.Cell(1, 2).Value = "Blog Adı";

                // ilk satırda başlıklar oldugu icin 2 den basladım
                int blogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    workSheet.Cell(blogRowCount, 1).Value = item.Id;
                    workSheet.Cell(blogRowCount, 1).Value = item.BlogName;
                    blogRowCount++;
                }
                using var stream = new MemoryStream();
                workBook.SaveAs(stream);
                var content = stream.ToArray();
                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calısma1.xlsx");
            }
        }

        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogModel = new List<BlogModel>
            {
                new BlogModel{Id=1,BlogName="C# programlama"},
                new BlogModel{Id=2,BlogName="Twsla Araç"},
                new BlogModel{Id=3,BlogName="2020 Olimpiyatlar"},
            };
            return blogModel;
        }
    }
}
