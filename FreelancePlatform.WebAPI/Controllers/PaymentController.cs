using AutoMapper;
using FreelancePlatform.Core.DTOs.PaymentDtos;
using FreelancePlatform.Core.Entities;
using FreelancePlatform.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreelancePlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        // ✅ Tüm ödemeleri getir
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var payments = await _paymentService.TGetListAllAsync();
            var resultDtos = _mapper.Map<List<ResultPaymentDto>>(payments);
            return Ok(resultDtos);
        }

        // ✅ Belirli ödemeyi getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var payment = await _paymentService.TGetByIdAsync(id);
            if (payment == null) return NotFound("Ödeme kaydı bulunamadı!");
            var resultDto = _mapper.Map<ResultPaymentDto>(payment);
            return Ok(resultDto);
        }

        // ✅ Ödeme kaydı oluştur
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePaymentDto dto)
        {
            var payment = _mapper.Map<Payment>(dto);
            payment.PaymentDate = DateTime.UtcNow;
            await _paymentService.TAddAsync(payment);
            return Ok(new { message = "Ödeme kaydı başarıyla oluşturuldu!" });
        }

        // ✅ Ödeme kaydını güncelle
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CreatePaymentDto dto)
        {
            var payment = await _paymentService.TGetByIdAsync(dto.FreelancerId);
            if (payment == null) return NotFound("Ödeme kaydı bulunamadı!");

            _mapper.Map(dto, payment);
            await _paymentService.TUpdateAsync(payment);
            return Ok(new { message = "Ödeme kaydı başarıyla güncellendi!" });
        }

        // ✅ Ödeme kaydını sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var payment = await _paymentService.TGetByIdAsync(id);
            if (payment == null) return NotFound("Ödeme kaydı bulunamadı!");

            await _paymentService.TDeleteAsync(payment);
            return Ok(new { message = "Ödeme kaydı başarıyla silindi!" });
        }
    }
}
