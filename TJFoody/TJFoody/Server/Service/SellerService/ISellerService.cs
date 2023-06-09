
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TJFoody.Server.Service.SellerService
{
    public interface ISellerService
    {
        Task<ServiceResponse<List<Seller>>> GetSellersAsync();

        Task<ServiceResponse<EntityEntry<Seller>>> AddSellerAsync(Seller seller);
    }
}
