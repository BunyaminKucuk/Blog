using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(WritersList);
            return Json(jsonWriters);
        }

        public IActionResult GetWriterById(int writerId)
        {
            var findWriter = WritersList.FirstOrDefault(x => x.Id == writerId);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }
        public static List<WriterModel> WritersList = new List<WriterModel>
        {
            new WriterModel
            {
                Id = 1,
                Name = "Mehmet"
            },
            new WriterModel
            {
                Id = 2,
                Name = "Buse"
            },
            new WriterModel
            {
                Id = 3,
                Name = "Naz"
            },
        };

        [HttpPost]
        public IActionResult AddWriter(WriterModel writerModel)
        {
            WritersList.Add(writerModel);
            var jsonWriters = JsonConvert.SerializeObject(WritersList);
            return Json(jsonWriters);
        }

        public IActionResult DeleteWriter(int id)
        {
            var writer = WritersList.FirstOrDefault(x => x.Id == id);
            WritersList.Remove(writer);
            return Json(writer);
        }

        public IActionResult UpdateWriter(WriterModel writerModel)
        {
            var writer = WritersList.FirstOrDefault(x => x.Id == writerModel.Id);
            writer.Name = writerModel.Name;
            var jsonWriter = JsonConvert.SerializeObject(writerModel);
            return Json(jsonWriter);
        }
    }
}
