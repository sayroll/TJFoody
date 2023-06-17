using TJFoody.Shared;

namespace TJFoody.Client.Services.SellerService
{
    public class SellerService : ISellerService
    {
        private readonly HttpClient _http;

        public SellerService(HttpClient http)
        {
            _http = http;
        }
        public List<Seller> sellers { get; set; } = new List<Seller>();

        public async Task GetSellers()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Seller>>>("Seller/get");
            if (result != null && result.Data != null)
                sellers = result.Data;
        }

        async Task<ServiceResponse<Seller>> ISellerService.addSeller(Seller seller)
        {
            var response = await _http.PostAsJsonAsync("Seller/add", seller);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<Seller>>();
        }

        async Task<ServiceResponse<Seller>> ISellerService.modifySeller(Seller seller)
        {
            var response = await _http.PostAsJsonAsync("Seller/modify", seller);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<Seller>>();
        }
    }
}
