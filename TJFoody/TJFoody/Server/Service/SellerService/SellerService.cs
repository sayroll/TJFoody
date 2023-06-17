using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TJFoody.Server.Models;
using TJFoody.Shared;

namespace TJFoody.Server.Service.SellerService
{
    public class SellerService : ISellerService
    {
        private readonly infoContext _context;
        public SellerService(infoContext infoContext)
        {
            _context = infoContext;
        }

        public async Task<ServiceResponse<EntityEntry<Seller>>> AddSellerAsync(Seller seller)
        {
            var response = new ServiceResponse<EntityEntry<Seller>>();

            try
            {
                await _context.Sellers.AddAsync(seller);
                await _context.SaveChangesAsync();

                response.Message = "成功";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "添加商家时发生错误：" + ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<Seller>> GetSellerByID(int id)
        {
            var response = new ServiceResponse<Seller>();

            try
            {
                response.Data = await _context.Sellers.FindAsync(id);

                response.Message = "成功找到了对应商家";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "在查找商家时发生了错误：" + ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Seller>>> GetSellersAsync()
        {
            var response = new ServiceResponse<List<Seller>>
            {
                Data = await _context.Sellers.ToListAsync()
            };
            return response;
        }

        async Task<ServiceResponse<Seller>> ISellerService.ModifySeller(Seller seller)
        {
            ServiceResponse<Seller> response = new ServiceResponse<Seller>();

            try
            {
                // Find the user in the Users table based on the phone number
                Seller sellerToUpdate = _context.Sellers.FirstOrDefault(u => u.Id == seller.Id);

                if (sellerToUpdate != null)
                {
                    // Update the user information
                    sellerToUpdate.Name = seller.Name;
                    sellerToUpdate.Location = seller.Location;
                    sellerToUpdate.Poi = seller.Poi;
                    sellerToUpdate.ImageUrl = seller.ImageUrl;

                    // Save the changes to the database
                    await _context.SaveChangesAsync();

                    response.Data = sellerToUpdate;
                    response.Success = true;
                    response.Message = "seller information updated successfully.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "seller not found.";
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                response.Success = false;
                response.Message = "Error updating seller information: " + ex.Message;
            }

            return response;
        }
    }
}
