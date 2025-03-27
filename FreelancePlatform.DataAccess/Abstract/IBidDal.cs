using FreelancePlatform.Core.DTOs.BidDtos;
using FreelancePlatform.Core.Entities;

namespace FreelancePlatform.DataAccess.Abstract
{
    public interface IBidDal : IGenericDal<Bid>
    {
        Task<List<Bid>> GetBidsByProjectIdAsync(int projectId);
        Task<List<Bid>> GetBidsByFreelancerIdAsync(int freelancerId);
        Task AddBidAndUpdateProjectStatusAsync(Bid bid);
        Task AcceptBidAsync(int bidId);
        Task<List<ResultBidWithProjectDto>> GetBidsByEmployerIdAsync(int employerId);

    }
}
