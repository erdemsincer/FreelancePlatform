using FreelancePlatform.Core.DTOs.BidDtos;
using FreelancePlatform.Core.Entities;

namespace FreelancePlatform.Services.Abstract
{
    public interface IBidService: IGenericService<Bid>
    {

        Task<List<Bid>> GetBidsByEmployerIdAsync(int employerId);
        Task<bool> AcceptBidAsync(int bidId);


    }
}
