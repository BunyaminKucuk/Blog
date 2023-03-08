using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using var workBook = new XLWorkbook();
            var workSheet = workBook.Worksheets.Add("Blog Listesi");
            workSheet.Cell(1, 1).Value = "Blog ID";
            workSheet.Cell(1, 2).Value = "Blog Adı";

            // ilk satırda başlıklar oldugu icin 2 den basladım
            int blogRowCount = 2;
            foreach (var item in GetBlogList())
            {
                workSheet.Cell(blogRowCount, 1).Value = item.Id;
                workSheet.Cell(blogRowCount, 2).Value = item.BlogName;
                blogRowCount++;
            }
            using var stream = new MemoryStream();
            workBook.SaveAs(stream);
            var content = stream.ToArray();
            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BlogListesi.xlsx");
        }

        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogModels = new List<BlogModel>();
            using var context = new Context();
            blogModels = context.Blogs.Select(x => new BlogModel
            {
                Id = x.BlogId,
                BlogName = x.BlogTitle
            }).ToList();
            return blogModels;
        }

        public IActionResult BlogListExcel()
        {

            return View();
        }
    }
}
