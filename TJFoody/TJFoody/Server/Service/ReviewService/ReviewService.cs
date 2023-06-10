using Microsoft.EntityFrameworkCore.ChangeTracking;
using TJFoody.Server.Models;
using TJFoody.Shared;
using Ubiety.Dns.Core;

namespace TJFoody.Server.Service.ReviewService
{
    public class ReviewService : IReviewService
    {
        private readonly infoContext _context;
        public ReviewService(infoContext infoContext)
        {
            _context = infoContext;
        }
        async public Task<ServiceResponse<SellerReview>> AddSellerReview(SellerReview sellerReview)
        {
            var result = new ServiceResponse<SellerReview>();
            try
            {
                await _context.SellerReviews.AddAsync(sellerReview);
                await _context.SaveChangesAsync();

                result.Message = "成功";
                result.Data = sellerReview;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "添加评论时发生错误：" + ex.Message;
            }

            return result;
        }
    }
}
