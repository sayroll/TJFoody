using BootstrapBlazor.Components;
using System.Net.Http.Json;
using TJFoody.Client.Pages;
using TJFoody.Shared;

namespace TJFoody.Client.Services.CuisineService
{
    public class CuisineService : ICuisineService
    {
        private readonly HttpClient _http;

        public CuisineService(HttpClient http)
        {
            _http = http;
        }

        public List<Cuisine> cuisine { get; set; } = new List<Cuisine>();

        async public Task GetCuisines()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Cuisine>>>("Cuisine/get");
            if (result != null && result.Data != null)
                cuisine = result.Data;
        }

        async Task<ServiceResponse<Cuisine>> ICuisineService.AddCuisine(Cuisine cuisine)
        {
            var response = await _http.PostAsJsonAsync("Cuisine/add", cuisine);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<Cuisine>>();
        }

        async Task<ServiceResponse<Cuisine>> ICuisineService.DeleteCuisine(int id)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<Cuisine>>($"Cuisine/DeleteCuisine/{id}");
            return response;
        }

        async Task<Cuisine> ICuisineService.GetCuisineById(int id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Cuisine>>($"Cuisine/GetCuisineByID/{id}");
            return result.Data;
        }

        async Task<List<Cuisine>> ICuisineService.GetCuisinesBySellerId(int id)
        {
            //var data = new
            //{
            //    id = id
            //};
            //var result = await _http.PostAsJsonAsync("Cuisine/GetCuisineBySellerID",data);
            //var cuisineList = (await result.Content.ReadFromJsonAsync<List<Cuisine>>());
            //return cuisineList;

            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Cuisine>>>($"Cuisine/{id}");
            return result.Data;
        }

        async Task<ServiceResponse<Cuisine>> ICuisineService.ModifyCuisine(Cuisine cuisine)
        {
            var response = await _http.PostAsJsonAsync("Cuisine/modify", cuisine);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<Cuisine>>();
        }
    }
}
