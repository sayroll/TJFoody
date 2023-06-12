using TJFoody.Client.Pages;
using TJFoody.Shared;


namespace TJFoody.Client.Services.ReviewService
{
    public class ReviewService : IReviewService
    {

        private readonly HttpClient _http;
        public List<SellerReview> sellerReviews { get; set; }
        public List<CuisineReview> cuisineReviews { get; set; }
        public List<SellerReviewModel> sellerReviewModels { get; set; }



        public ReviewService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<CuisineReview>> addCuisineReview(CuisineReview cuisineReview)
        {
            var response = await _http.PostAsJsonAsync("Review/addCuisineReview", cuisineReview);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<CuisineReview>>();
        }

        public async Task<ServiceResponse<SellerReview>> addSerllerReview(SellerReview serllerReview)
        {
            var response = await _http.PostAsJsonAsync("Review/addSellerReview", serllerReview);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<SellerReview>>();
        }

        public async Task<List<CuisineReview>> getAllCuisineReviews()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<CuisineReview>>>("Review/get/cuisine");
            return response.Data;
        }

        public async Task<List<SellerReview>> getAllSellerReviews()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<SellerReview>>>("Review/get/seller");
            return response.Data;
        }

        public async Task getReviews()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<SellerReview>>>("Review/get/seller");
            if (result != null && result.Data != null)
            {
                sellerReviews = result.Data;
            }
            foreach(var item in sellerReviews)
            {
                item.Rate = (int) item.Rate;
            }
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<CuisineReview>>>("Review/get/cuisine");
            if(response != null && response.Data != null)
            {
                cuisineReviews = response.Data;
            }
            foreach(var item in cuisineReviews)
            {
                item.Rate = (int)(item.Rate);
            }
        }

        public async Task getSellerReview()
        {
            foreach (var review in sellerReviews)
            {
                string phone = review.UserId;
                var response = await _http.GetFromJsonAsync<ServiceResponse<User>>($"User/getByPhone/{phone}");
                User reviewer = response.Data;
                if(reviewer == null)
                {
                    reviewer = new User
                    {
                        Name = "匿名",
                        Avartar = "https://ts1.cn.mm.bing.net/th/id/R-C.0bab160015bf9e56450d5fded33bd448?rik=VFMstq3mAZG1pg&riu=http%3a%2f%2fwww.qzqn8.com%2fwp-content%2fuploads%2f2020%2f02%2f3-9.jpg&ehk=pnkhUlGCDYmxisEuCwYL4zXW92froAxt%2f0B5i9AYAkY%3d&risl=&pid=ImgRaw&r=0"
                    };
                }
                SellerReviewModel model = new SellerReviewModel
                {
                    UserName = reviewer.Name,
                    Date = review.Date,
                    Content = review.Content,
                    Avartar = reviewer.Avartar,
                    Rate = (int)review.Rate
                };

                sellerReviewModels.Add(model);
            }
        }

        public double calculateSellerRate(int sellerID)
        {
            int number = 0;
            double sum = 0;
            foreach(var review in sellerReviews )
            {
                if(review.SellerId == sellerID)
                {
                    number++;
                    sum += review.Rate.Value;
                }
            }
            double result;
            if (number == 0)
            {
                result = 0;
            }
            else
            {
                result = sum / number;
            }
            return result;
        }

        public double calculateCuisineRate(int cuisineID)
        {
            int number = 0;
            double sum = 0;
            foreach(var review in cuisineReviews )
            {
                if(review.CuisineId == cuisineID)
                {
                    number++;
                    sum += review.Rate.Value;
                }
            }
            double result;
            if( number == 0 )
            {
                result = 0;
            }
            else
            {
                result = sum / number;
            }
            return result;
        }
    }
}
