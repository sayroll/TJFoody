using System.Net.Http.Json;
using TJFoody.Client.Pages;

namespace TJFoody.Client.Services.CuisineService
{
    public class CuisineService : ICuisineService
    {
        private readonly HttpClient _http;

        public CuisineService(HttpClient http)
        {
            _http = http;
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
    }
}
