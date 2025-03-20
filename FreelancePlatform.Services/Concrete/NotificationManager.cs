using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.Services.Abstract;

namespace FreelancePlatform.Services.Concrete
{
    public class NotificationManager : INotificationService
    { 
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public async Task TAddAsync(Notification entity)
        {
            await _notificationDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(Notification entity)
        {
            await _notificationDal.DeleteAsync(entity);
        }

        public async Task<Notification> TGetByIdAsync(int id)
        {
            return await _notificationDal.GetByIdAsync(id);
        }

        public async Task<List<Notification>> TGetListAllAsync()
        {
            return await _notificationDal.GetListAllAsync();
        }

        public async Task TUpdateAsync(Notification entity)
        {
            await _notificationDal.UpdateAsync(entity);
        }
    }
}
