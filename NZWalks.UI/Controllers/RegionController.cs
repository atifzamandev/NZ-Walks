using Microsoft.AspNetCore.Mvc;
using NZWalks.UI.Models.Dto;

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
    }
}
