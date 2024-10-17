using Newtonsoft.Json;
using RentReview.Models.DataModels.Property;
using RentReview.Models.ViewModels.Property;
using System.Text;

namespace RentReview.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient client = new HttpClient();

        private string url = "https://localhost:44315/api/Property";

        public async Task<List<ViewPropertyViewModel>> GetAllPropertiesAsync()
        {
            var result = await client.GetAsync(url);

            var resultAsJson = await result.Content.ReadAsStringAsync();

            var value = JsonConvert.DeserializeObject<List<ViewPropertyViewModel>>(resultAsJson);

            return value;
        }

        public async Task<List<ViewPropertyViewModel>> GetFilteredPropertiesAsync(FilterPropertyDataModel data, string action)
        {
            var jsonContent = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var result = await client.PostAsync(url + action, content);
            var resultAsJson = await result.Content.ReadAsStringAsync();

            var value = JsonConvert.DeserializeObject<List<ViewPropertyViewModel>>(resultAsJson);
            return value;
        }

        public async Task<bool> Add(AddNewPropertyDataModel data, string userId, string action)
        {
            var jsonContent = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Add("UserId", userId);

            var result = await client.PostAsync(url + action, content);

            if (!result.IsSuccessStatusCode)
            {
                var errors = await result.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject(errors);
            }

            return true;
        }

        public async Task<ViewPropertyViewModel> Edit(string action)
        {
            var result = await client.GetAsync(url + action);

            var jsonString = await result.Content.ReadAsStringAsync();
            var property = JsonConvert.DeserializeObject<ViewPropertyViewModel>(jsonString);

            return property;
        }

        public async Task<bool> Delete(string action)
        {
            var result = await client.DeleteAsync(url + action);

            var jsonString = await result.Content.ReadAsStringAsync();
            var property = JsonConvert.DeserializeObject<bool>(jsonString);

            return property;
        }

        public async Task<bool> Edit(AddNewPropertyDataModel data, string userId, string action)
        {
            var jsonContent = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Add("UserId", userId);
            var result = await client.PostAsync(url + action, content);
            return true;
        }
    }
}
