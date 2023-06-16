namespace TJFoody.Client.Services.ReviewService
{
    public interface IReviewService
    {
        
        List<SellerReview> sellerReviews { get; set; }
        List<CuisineReview> cuisineReviews { get;set; }
        Task<ServiceResponse<SellerReview>> addSerllerReview(SellerReview serllerReview);

        Task<ServiceResponse<CuisineReview>> addCuisineReview(CuisineReview cuisineReview);

        Task<List<SellerReview>> getAllSellerReviews();

        Task<List<CuisineReview>> getAllCuisineReviews();

        Task<List<SellerReview>> getSellerReviewsByUserId(string userId);

        Task<List<CuisineReview>> getCuisineReviewsByUserId(string userId);
        Task<ServiceResponse<SellerReview>> DeleteSellerReview(int Id);

        Task<ServiceResponse<CuisineReview>> DeleteCuisineReview(int Id);

        Task getReviews();

        double calculateSellerRate(int sellerID);
        double calculateCuisineRate(int cuisineID);

    }
}
