using Newtonsoft.Json;
using RentReview.Models.ViewModels.Property;

namespace RentReview.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient client = new HttpClient();
        private string url = "https://localhost:44315/api";

        public async Task<List<ViewPropertyViewModel>> GetAllPropertiesAsync(string action)
        {
            var result = await client.GetAsync(url+action);

            var resultAsJson = await result.Content.ReadAsStringAsync();

            var value = JsonConvert.DeserializeObject<List<ViewPropertyViewModel>>(resultAsJson);

            return value;
        }
    }
}
