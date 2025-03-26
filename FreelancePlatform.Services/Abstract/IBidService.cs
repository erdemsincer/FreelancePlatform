using FreelancePlatform.Core.Entities;

namespace FreelancePlatform.Services.Abstract
{
    public interface IBidService: IGenericService<Bid>
    {
        Task<List<Bid>> GetBidsByProjectIdAsync(int projectId);
        Task<List<Bid>> GetBidsByFreelancerIdAsync(int freelancerId);
    }
}
