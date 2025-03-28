using FreelancePlatform.Core.DTOs.BidDtos;
using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.Services.Abstract;

namespace FreelancePlatform.Services.Concrete
{
    public class BidManager : IBidService
    {
        private readonly IBidDal _bidDal;

        public BidManager(IBidDal bidDal)
        {
            _bidDal = bidDal;
        }

        public async Task TAddAsync(Bid entity)
        {
            await _bidDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(Bid entity)
        {
            await _bidDal.DeleteAsync(entity);
        }

        public async Task<Bid> TGetByIdAsync(int id)
        {
            return await _bidDal.GetByIdAsync(id);
        }

        public async Task<List<Bid>> TGetListAllAsync()
        {
            return await _bidDal.GetListAllAsync();
        }

        public async Task TUpdateAsync(Bid entity)
        {
            await _bidDal.UpdateAsync(entity);
        }
       

    }
}
