using Microsoft.EntityFrameworkCore.ChangeTracking;
using TJFoody.Shared;

namespace TJFoody.Server.Service.ReviewService
{
    public interface IReviewService
    {
        Task<ServiceResponse<SellerReview>> AddSellerReview(SellerReview sellerReview);

        Task<ServiceResponse<CuisineReview>> AddCuisineReview(CuisineReview cuisineReview);

        Task<ServiceResponse<List<SellerReview>>> GetSellerReviews();
        Task<ServiceResponse<List<CuisineReview>>> GetCuisineReviews();

        Task<ServiceResponse<SellerReview>> getSellerReviewByID(int id);
        Task<ServiceResponse<CuisineReview>> getCuisineReviewByID(int id);

        Task<ServiceResponse<List<SellerReview>>> GetSellerReviewByUserId(string userId);
        Task<ServiceResponse<List<CuisineReview>>> GetCuisineReviewByUserId(string userId);

        Task<ServiceResponse<SellerReview>> DeleteSellerReview(int id);
        Task<ServiceResponse<CuisineReview>> DeleteCuisineReview(int id);


    }
}
