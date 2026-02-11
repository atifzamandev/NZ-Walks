using Microsoft.AspNetCore.Mvc;
using NZWalks.UI.Models;
using NZWalks.UI.Models.Dto;
using System.Text;
using System.Text.Json;

namespace NZWalks.UI.Controllers
{
    public class RegionController:Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public RegionController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            List<RegionDto> response = new List<RegionDto>();
            IEnumerable<RegionDto>? resFromApi = null;

            try
            {
                var client = httpClientFactory.CreateClient();
                var httpResponseMessage = await client.GetAsync("https://localhost:7036/api/regions");
                httpResponseMessage.EnsureSuccessStatusCode();

                resFromApi = await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<RegionDto>>();

                if(resFromApi != null) response.AddRange(resFromApi);
            }
            catch(Exception ex)
            {
            }

            return View(response);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRegionViewModel regionModel)
        {
            var httpClient = httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7036/api/regions"),
                Content = new StringContent(JsonSerializer.Serialize(regionModel), Encoding.UTF8, "application/json")
            };

            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            httpResponseMessage.EnsureSuccessStatusCode();


            var resFromApi = await httpResponseMessage.Content.ReadFromJsonAsync<RegionDto>();

            if(resFromApi is not null)
            {
                return RedirectToAction("Index", "Region");
            }

            return View();
        }

        [HttpGet]

        public async Task<IActionResult> Edit(Guid id)
        {
            var httpClient = httpClientFactory.CreateClient();

            var httpResposne = await httpClient.GetFromJsonAsync<RegionDto>($"https://localhost:7036/api/regions/{id.ToString()}");
            if(httpResposne is not null)
            {
                return View(httpResposne);
            }

            return View(null);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegionDto request)
        {
            var httpClient = httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:7036/api/regions/{request.Id}"),
                Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json")
            };

            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();

            var resFromApi = httpResponseMessage.Content.ReadFromJsonAsync<RegionDto>();

            if(resFromApi is not null)
            {
                return RedirectToAction("Index", "Region");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RegionDto region)
        {
            try
            {
                var httpClient = httpClientFactory.CreateClient();

                var httpResponseMessage = await httpClient.DeleteAsync($"https://localhost:7036/api/regions/{region.Id}");
                httpResponseMessage.EnsureSuccessStatusCode();

                return RedirectToAction("Index", "Region");
            }
            catch(Exception ex)
            {
                //Console
            }
            return View("Edit");

        }
    }
}
