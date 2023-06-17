using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TJFoody.Server.Models;
using TJFoody.Shared;

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

        async Task<ServiceResponse<List<Cuisine>>> ICuisineService.GetCuisinesAsync()
        {
            var response = new ServiceResponse<List<Cuisine>>
            {
                Data = await _context.Cuisines.ToListAsync()
            };
            return response;
        }

        async Task<ServiceResponse<Cuisine>> ICuisineService.ModifyCuisine(Cuisine cuisine)
        {
            ServiceResponse<Cuisine> response = new ServiceResponse<Cuisine>();

            try
            {
                // Find the user in the Users table based on the phone number
                Cuisine cuisineToUpdate = _context.Cuisines.FirstOrDefault(u => u.Id == cuisine.Id);

                if (cuisineToUpdate != null)
                {
                    // Update the user information
                    cuisineToUpdate.Name = cuisine.Name;
                    cuisineToUpdate.SellerId = cuisine.SellerId;
                    cuisineToUpdate.Description = cuisine.Description;
                    cuisineToUpdate.ImageUrl = cuisine.ImageUrl;

                    // Save the changes to the database
                    await _context.SaveChangesAsync();

                    response.Data = cuisineToUpdate;
                    response.Success = true;
                    response.Message = "cuisine information updated successfully.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "cuisine not found.";
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                response.Success = false;
                response.Message = "Error updating cuisine information: " + ex.Message;
            }

            return response;
        }

        async public Task<ServiceResponse<Cuisine>> DeleteCuisine(int id)
        {
            ServiceResponse<Cuisine> response = new ServiceResponse<Cuisine>();

            try
            {
                // Find the Cuisine by ID in the database
                Cuisine cuisineToDelete = await _context.Cuisines.FindAsync(id);

                if (cuisineToDelete != null)
                {
                    // Remove the Cuisine from the database
                    _context.Cuisines.Remove(cuisineToDelete);

                    // Find and remove all related CuisineReviews
                    List<CuisineReview> reviewsToDelete = _context.CuisineReviews
                        .Where(review => review.CuisineId == id)
                        .ToList();

                    _context.CuisineReviews.RemoveRange(reviewsToDelete);
                    await _context.SaveChangesAsync();

                    response.Data = cuisineToDelete;
                    response.Success = true;
                    response.Message = "Cuisine deleted successfully.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Cuisine not found.";
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                response.Success = false;
                response.Message = "Error deleting cuisine: " + ex.Message;
            }

            return response;
        }
    }
}
