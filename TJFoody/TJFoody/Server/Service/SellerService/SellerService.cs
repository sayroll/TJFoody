using Microsoft.EntityFrameworkCore;
using TJFoody.Server.Models;

namespace TJFoody.Server.Service.SellerService
{
    public class SellerService : ISellerService
    {
        private readonly infoContext _context;
        public SellerService(infoContext infoContext)
        {
            _context = infoContext;
        }
        public async Task<ServiceResponse<List<Seller>>> GetSellersAsync()
        {
            var response = new ServiceResponse<List<Seller>>
            {
                Data = await _context.Sellers.ToListAsync()
            };
            return response;
        }
    }
}
