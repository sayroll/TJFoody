using Microsoft.EntityFrameworkCore.ChangeTracking;
using TJFoody.Shared;

namespace TJFoody.Server.Service.ReviewService
{
    public interface IReviewService
    {
        Task<ServiceResponse<EntityEntry<SellerReview>>> AddSellerReview(SellerReview sellerReview);
    }
}
