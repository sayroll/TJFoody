namespace TJFoody.Client.Services.CuisineService
{
    public interface ICuisineService
    {
        List<Cuisine> cuisine { get; set; }
        Task GetCuisines();
        Task<List<Cuisine>> GetCuisinesBySellerId(int id);

        Task<Cuisine> GetCuisineById(int id);

        Task<ServiceResponse<Cuisine>> AddCuisine(Cuisine cuisine);
        Task<ServiceResponse<Cuisine>> ModifyCuisine(Cuisine cuisine);

        Task<ServiceResponse<Cuisine>> DeleteCuisine(int id);
    }
}
