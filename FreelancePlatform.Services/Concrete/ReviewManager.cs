using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.Services.Abstract;

namespace FreelancePlatform.Services.Concrete
{
    public class ReviewManager : IReviewService
    {
        private readonly IReviewDal _reviewDal;

        public ReviewManager(IReviewDal reviewDal)
        {
            _reviewDal = reviewDal;
        }

        public Task<List<Review>> GetReviewsByRevieweeIdAsync(int revieweeId)
        {
            return _reviewDal.GetReviewsByRevieweeIdAsync(revieweeId);
        }

        public async Task<List<Review>> GetReviewsByUserIdAsync(int userId)
        {
            return await _reviewDal.GetReviewsByUserIdAsync(userId);
        }

        public async Task TAddAsync(Review entity)
        {
            await _reviewDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(Review entity)
        {
           await _reviewDal.DeleteAsync(entity);
        }

        public async Task<Review> TGetByIdAsync(int id)
        {
            return await _reviewDal.GetByIdAsync(id);
        }

        public async Task<List<Review>> TGetListAllAsync()
        {
            return await _reviewDal.GetListAllAsync();
        }

        public async Task TUpdateAsync(Review entity)
        {
            await _reviewDal.UpdateAsync(entity);
        }
    }
}
