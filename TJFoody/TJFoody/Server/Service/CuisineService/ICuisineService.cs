using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TJFoody.Server.Service.CuisineService
{
    public interface ICuisineService
    {
        Task<ServiceResponse<EntityEntry<Cuisine>>> AddCuisineAsync(Cuisine cuisine);
        Task<ServiceResponse<Cuisine>> GetCuisineByIDAsync(int id);

        Task<ServiceResponse<List<Cuisine>>> GetCuisineBySellerIDAsync(int id);
    }
}
