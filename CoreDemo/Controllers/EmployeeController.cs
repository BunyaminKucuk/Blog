using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<IActionResult> Index()
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:44332/api/Default");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<EmployeeClass>>(jsonString);
            return View(values);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeClass employeeClass)
        {
            var jsonEmployee = JsonConvert.SerializeObject(employeeClass);
            var stringContent = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync("https://localhost:44332/api/Default", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Employee");
            }

            return View(employeeClass);
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:44332/api/Default/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<EmployeeClass>(jsonEmployee);
                return View(values);
            }

            return RedirectToAction("Index", "Employee");
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(EmployeeClass employeeClass)
        {
            var jsonEmployee = JsonConvert.SerializeObject(employeeClass);
            var stringContent = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PutAsync("https://localhost:44332/api/Default/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Employee");
            }

            return View(employeeClass);
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var responseMessage = await _httpClient.DeleteAsync("https://localhost:44332/api/Default/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Employee");
            }

            return View();
        }

    }

    public class EmployeeClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}

