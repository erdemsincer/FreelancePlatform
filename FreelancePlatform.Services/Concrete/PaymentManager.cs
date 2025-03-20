using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.Services.Abstract;

namespace FreelancePlatform.Services.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public async Task TAddAsync(Payment entity)
        {
            await _paymentDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(Payment entity)
        {
            await _paymentDal.DeleteAsync(entity);
        }

        public async Task<Payment> TGetByIdAsync(int id)
        {
           return await _paymentDal.GetByIdAsync(id);
        }

        public async Task<List<Payment>> TGetListAllAsync()
        {
            return await  _paymentDal.GetListAllAsync();
        }

        public async Task TUpdateAsync(Payment entity)
        {
           await _paymentDal.UpdateAsync(entity);
        }
    }
}
