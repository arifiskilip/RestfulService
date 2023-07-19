using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _http;

        public HomeController(IHttpClientFactory http)
        {
            _http = http;
        }

        public async Task<IActionResult> Index()
        {
            var client = _http.CreateClient();
            var response =  await client.GetAsync("https://localhost:44339/api/Products");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ProductModel>>(json);
                return View(result);
            }
            return View();
        }
        
        public async Task<IActionResult> Update(int id)
        {
            var client = _http.CreateClient();
            var response = await client.GetAsync($"https://localhost:44339/api/Products/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProductModel>(json);
                return View(result);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductModel model)
        {
            var client = _http.CreateClient();
            var json = JsonConvert.SerializeObject(model);
            StringContent content = new(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:44339/api/Products",content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductModel model)
        {
            var client = _http.CreateClient();
            var json = JsonConvert.SerializeObject(model);
            StringContent content = new(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"https://localhost:44339/api/Products", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _http.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:44339/api/Products/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public async Task<IActionResult> GetCategories()
        {
            // Normalde component ile yapılması gerekir. Bu yöntem hatalı bir yaklaşımdır.
            var client = _http.CreateClient();
            var response = await client.GetAsync("https://localhost:44339/api/Categories");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<CategoryModel>>(json);
                TempData["result"] = result;
                return View();
            }
            return View();
        }
    }
}
