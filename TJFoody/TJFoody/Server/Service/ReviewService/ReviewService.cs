using Microsoft.EntityFrameworkCore;
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

        public async Task<ServiceResponse<CuisineReview>> AddCuisineReview(CuisineReview cuisineReview)
        {
            var result = new ServiceResponse<CuisineReview>();
            try
            {
                await _context.CuisineReviews.AddAsync(cuisineReview);
                await _context.SaveChangesAsync();

                result.Message = "成功";
                result.Data = cuisineReview;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "添加菜品评论时发生错误：" + ex.Message;
            }

            return result;
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
                result.Message = "添加商家评论时发生错误：" + ex.Message;
            }

            return result;
        }

        public async Task<ServiceResponse<CuisineReview>> getCuisineReviewByID(int id)
        {
            var response = new ServiceResponse<CuisineReview>();
            try
            {
                response.Data = await _context.CuisineReviews.FindAsync(id);
                if(response.Data == null)
                {
                    response.Success = false;
                    response.Message = "没有找到对应的菜品，请检查ID";
                }
                else
                {
                    response.Message = "成功找到ID对应的菜品评价";
                }
            }
            catch
            {
                response.Success = false;
                response.Message = "查询菜品失败";
            }
            return response;

        }

        public async Task<ServiceResponse<List<CuisineReview>>> GetCuisineReviews()
        {
            var response = new ServiceResponse<List<CuisineReview>>();

            try
            {
                response.Data = await _context.CuisineReviews.ToListAsync();
                response.Message = "获得所有菜品评价";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "获得菜品评价失败，原因为："+ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<SellerReview>> getSellerReviewByID(int id)
        {
            var response = new ServiceResponse<SellerReview>();
            try
            {
                response.Data = await _context.SellerReviews.FindAsync(id);
                if (response.Data == null)
                {
                    response.Success = false;
                    response.Message = "没有找到对应的菜品，请检查ID";
                }
                else
                {
                    response.Message = "成功找到ID对应的菜品评价";
                }
            }
            catch
            {
                response.Success = false;
                response.Message = "查询菜品失败";
            }
            return response;
        }

        public async Task<ServiceResponse<List<SellerReview>>> GetSellerReviews()
        {
            var response = new ServiceResponse<List<SellerReview>>();

            try
            {
                response.Data = await _context.SellerReviews.ToListAsync();
                response.Message = "获得所有商家评价";
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = "获得商家评价失败，原因为："+ex.Message;
            }

            return response;
        }

        async Task<ServiceResponse<CuisineReview>> IReviewService.DeleteCuisineReview(int id)
        {
            ServiceResponse<CuisineReview> response = new ServiceResponse<CuisineReview>();

            try
            {
                // Find the cuisine review by id in the database
                CuisineReview reviewToDelete = _context.CuisineReviews.FirstOrDefault(review => review.Id == id);

                if (reviewToDelete != null)
                {
                    // Remove the cuisine review from the database
                    _context.CuisineReviews.Remove(reviewToDelete);
                    await _context.SaveChangesAsync();

                    response.Data = reviewToDelete;
                    response.Success = true;
                    response.Message = "Cuisine review deleted successfully.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Cuisine review not found.";
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                response.Success = false;
                response.Message = "Error deleting cuisine review: " + ex.Message;
            }

            return response;
        }

        async Task<ServiceResponse<SellerReview>> IReviewService.DeleteSellerReview(int id)
        {
            ServiceResponse<SellerReview> response = new ServiceResponse<SellerReview>();

            try
            {
                // Find the seller review by id in the database
                SellerReview reviewToDelete = _context.SellerReviews.FirstOrDefault(review => review.Id == id);
                Console.WriteLine(id);
                if (reviewToDelete != null)
                {
                    // Remove the seller review from the database
                    _context.SellerReviews.Remove(reviewToDelete);
                    await _context.SaveChangesAsync();

                    response.Data = reviewToDelete;
                    response.Success = true;
                    response.Message = "Seller review deleted successfully.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Seller review not found.";
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                response.Success = false;
                response.Message = "Error deleting seller review: " + ex.Message;
            }

            return response;
        }

        Task<ServiceResponse<List<CuisineReview>>> IReviewService.GetCuisineReviewByUserId(string userId)
        {
            ServiceResponse<List<CuisineReview>> response = new ServiceResponse<List<CuisineReview>>();

            try
            {
                // Find cuisine reviews by userId in the database
                List<CuisineReview> reviews = _context.CuisineReviews
                    .Where(review => review.UserId == userId)
                    .ToList();

                response.Data = reviews;
                response.Success = true;
                response.Message = "Cuisine reviews retrieved successfully.";
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                response.Success = false;
                response.Message = "Error retrieving cuisine reviews: " + ex.Message;
            }

            return Task.FromResult(response);
        }

        Task<ServiceResponse<List<SellerReview>>> IReviewService.GetSellerReviewByUserId(string userId)
        {
            ServiceResponse<List<SellerReview>> response = new ServiceResponse<List<SellerReview>>();

            try
            {
                // Find cuisine reviews by userId in the database
                List<SellerReview> reviews = _context.SellerReviews
                    .Where(review => review.UserId == userId)
                    .ToList();

                response.Data = reviews;
                response.Success = true;
                response.Message = "Cuisine reviews retrieved successfully.";
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                response.Success = false;
                response.Message = "Error retrieving cuisine reviews: " + ex.Message;
            }

            return Task.FromResult(response);
        }
    }
}
