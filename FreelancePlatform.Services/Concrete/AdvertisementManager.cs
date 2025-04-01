using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.Services.Abstract;

namespace FreelancePlatform.Services.Concrete
{
    public class AdvertisementManager : IAdvertisementService
    {
        private readonly IAdvertisementDal _advertisementDal;

        public AdvertisementManager(IAdvertisementDal advertisementDal)
        {
            _advertisementDal = advertisementDal;
        }

        public async Task TAddAsync(Advertisement entity)
        {
            await _advertisementDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(Advertisement entity)
        {
            await _advertisementDal.DeleteAsync(entity);
        }

        public async Task<List<Advertisement>> TGetAllWithIncludesAsync()
        {
            return await _advertisementDal.GetAllWithIncludesAsync();
        }

        public async Task<Advertisement> TGetByIdAsync(int id)
        {
            return await _advertisementDal.GetByIdAsync(id);
        }

        public async Task<List<Advertisement>> TGetListAllAsync()
        {
            return await _advertisementDal.GetListAllAsync();
        }

        public async Task TUpdateAsync(Advertisement entity)
        {
            await _advertisementDal.UpdateAsync(entity);
        }
    }
}
