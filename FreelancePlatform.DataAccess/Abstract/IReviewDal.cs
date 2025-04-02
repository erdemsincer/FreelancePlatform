using FreelancePlatform.Core.Entities;

namespace FreelancePlatform.DataAccess.Abstract
{
    public interface IReviewDal : IGenericDal<Review>
    {
        Task<List<Review>> GetReviewsByUserIdAsync(int userId);
        Task<List<Review>> GetReviewsByRevieweeIdAsync(int revieweeId);

    }
}
