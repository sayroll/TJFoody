using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TJFoody.Server.Service.CuisineService
{
    public interface ICuisineService
    {
        Task<ServiceResponse<List<Cuisine>>> GetCuisinesAsync();
        Task<ServiceResponse<EntityEntry<Cuisine>>> AddCuisineAsync(Cuisine cuisine);
        Task<ServiceResponse<Cuisine>> GetCuisineByIDAsync(int id);

        Task<ServiceResponse<List<Cuisine>>> GetCuisineBySellerIDAsync(int id);

        Task<ServiceResponse<Cuisine>> ModifyCuisine(Cuisine cuisine);
        Task<ServiceResponse<Cuisine>> DeleteCuisine(int id);
    }
}
