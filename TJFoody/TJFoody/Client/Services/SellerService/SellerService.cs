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
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Seller>>>("Seller");
            if (result != null && result.Data != null)
                sellers = result.Data;
        }
    }
}
