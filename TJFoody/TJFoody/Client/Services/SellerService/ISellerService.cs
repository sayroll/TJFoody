namespace TJFoody.Client.Services.SellerService
{
    public interface ISellerService
    {
        List<Seller> sellers { get; set; }
        Task GetSellers();
    }
}
