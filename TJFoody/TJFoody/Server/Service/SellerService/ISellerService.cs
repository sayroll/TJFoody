﻿
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TJFoody.Server.Service.SellerService
{
    public interface ISellerService
    {
        Task<ServiceResponse<List<Seller>>> GetSellersAsync();

        Task<ServiceResponse<EntityEntry<Seller>>> AddSellerAsync(Seller seller);

        Task<ServiceResponse<Seller>> GetSellerByID(int id);

        Task<ServiceResponse<Seller>> ModifySeller(Seller seller);
        Task<ServiceResponse<Seller>> DeleteSeller(int id);
    }
}
