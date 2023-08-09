using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using WatiInterviewTest.Web.Models;

namespace WatiInterviewTest.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClient; 

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SumNumbers([FromBody]SumForm sumForm)
        {
            try
            {
                var client = _httpClient.CreateClient("MethOperation");
                client.BaseAddress = new Uri("https://localhost:44380/");
                var data = new
                {
                    Num1 = sumForm.Num1,
                    Num2 = sumForm.Num2,
                };

                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponse = await client.PostAsync("Add", content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    string res = await httpResponse.Content.ReadAsStringAsync();

                    return Json(res);
                }
                else
                {
                    return Json(httpResponse.Content);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Json(ex.ToString());
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}