using FreelancePlatform.Core.Entities;

namespace FreelancePlatform.Services.Abstract
{
    public interface IReviewService : IGenericService<Review>
    {
        Task<List<Review>> GetReviewsByUserIdAsync(int userId);
        Task<List<Review>> GetReviewsByRevieweeIdAsync(int revieweeId);

    }
}
