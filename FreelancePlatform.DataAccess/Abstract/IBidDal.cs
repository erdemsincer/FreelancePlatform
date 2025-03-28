using FreelancePlatform.Core.DTOs.BidDtos;
using FreelancePlatform.Core.Entities;

namespace FreelancePlatform.DataAccess.Abstract
{
    public interface IBidDal : IGenericDal<Bid>
    {
        Task<List<Bid>> GetBidsByEmployerIdAsync(int employerId);
        Task<Bid> GetBidWithProjectAsync(int bidId);
        Task<List<ResultBidWithProjectDto>> GetBidsByFreelancerIdAsync(int freelancerId);




    }
}
