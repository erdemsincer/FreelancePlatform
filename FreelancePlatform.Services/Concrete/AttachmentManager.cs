using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.Services.Abstract;

namespace FreelancePlatform.Services.Concrete
{
    public class AttachmentManager : IAttachmentService
    {
        private readonly IAttachmentDal _attachmentDal;

        public AttachmentManager(IAttachmentDal attachmentDal)
        {
            _attachmentDal = attachmentDal;
        }

        public async Task TAddAsync(Attachment entity)
        {
            await _attachmentDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(Attachment entity)
        {
            await _attachmentDal.DeleteAsync(entity);
        }

        public async Task<Attachment> TGetByIdAsync(int id)
        {
           return await _attachmentDal.GetByIdAsync(id);
        }

        public async Task<List<Attachment>> TGetListAllAsync()
        {
            return await _attachmentDal.GetListAllAsync();
        }

        public async Task TUpdateAsync(Attachment entity)
        {
            await _attachmentDal.UpdateAsync(entity);
        }
    }
}
