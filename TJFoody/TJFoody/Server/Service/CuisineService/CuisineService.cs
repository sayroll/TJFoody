using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TJFoody.Server.Models;

namespace TJFoody.Server.Service.CuisineService
{
    public class CuisineService : ICuisineService
    {
        private readonly infoContext _context;
        public CuisineService(infoContext infoContext)
        {
            _context = infoContext;
        }

        public async Task<ServiceResponse<EntityEntry<Cuisine>>> AddCuisineAsync(Cuisine cuisine)
        {
            var response = new ServiceResponse<EntityEntry<Cuisine>>();
            
            try
            {
                await _context.Cuisines.AddAsync(cuisine);
                await _context.SaveChangesAsync();

                response.Message = "成功";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "添加菜品时发生错误：" + ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Cuisine>>> GetCuisineBySellerIDAsync(int id)
        {
            var response = new ServiceResponse<List<Cuisine>>
            {
                Data = await _context.Cuisines.Where(c => c.SellerId == id).ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<Cuisine>> GetCuisineByIDAsync(int id)
        {
            var response = new ServiceResponse<Cuisine>();

            try
            {
                response.Data = await _context.Cuisines.FindAsync(id);
                response.Message = "成功找到了对应菜品";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "在查找菜品时发生了错误：" + ex.Message;
            }
            return response;
        }

    }
}
