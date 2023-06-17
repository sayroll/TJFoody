namespace TJFoody.Client.Services.SellerService
{
    public interface ISellerService
    {
        List<Seller> sellers { get; set; }
        Task GetSellers();

        Task<ServiceResponse<Seller>> addSeller(Seller seller);
        Task<ServiceResponse<Seller>> modifySeller(Seller seller);
        Task<ServiceResponse<Seller>> DeleteSeller(int id);
    }
}
