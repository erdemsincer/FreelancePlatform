using FreelancePlatform.Core.DTOs.BidDtos;
using FreelancePlatform.Core.Entities;

namespace FreelancePlatform.Services.Abstract
{
    public interface IBidService: IGenericService<Bid>
    {
        Task<List<Bid>> GetBidsByProjectIdAsync(int projectId);
        Task<List<ResultBidWithProjectDto>> GetBidsByFreelancerIdAsync(int freelancerId);
        Task AcceptBidAsync(int bidId);
        Task<List<ResultBidWithProjectDto>> GetBidsByEmployerIdAsync(int employerId);
        Task AddBidAsync(Bid bid);

    }
}
