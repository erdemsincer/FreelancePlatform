using FreelancePlatform.Core.DTOs.BidDtos;
using FreelancePlatform.Core.Entities;

namespace FreelancePlatform.DataAccess.Abstract
{
    public interface IBidDal : IGenericDal<Bid>
    {
        Task<List<Bid>> GetBidsByProjectIdAsync(int projectId);
        Task<List<ResultBidWithProjectDto>> GetBidsByFreelancerIdAsync(int freelancerId);
      
        Task AcceptBidAsync(int bidId);
        Task<List<ResultBidWithProjectDto>> GetBidsByEmployerIdAsync(int employerId);


    }
}
