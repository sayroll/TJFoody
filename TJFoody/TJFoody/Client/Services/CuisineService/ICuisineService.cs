namespace TJFoody.Client.Services.CuisineService
{
    public interface ICuisineService
    {
        Task<List<Cuisine>> GetCuisinesBySellerId(int id);
    }
}
