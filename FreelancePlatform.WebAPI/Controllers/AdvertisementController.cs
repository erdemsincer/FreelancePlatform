using AutoMapper;
using FreelancePlatform.Core.DTOs.AdvertisementDtos;
using FreelancePlatform.Core.Entities;
using FreelancePlatform.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FreelancePlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly IAdvertisementService _advertisementService;
        private readonly IMapper _mapper;

        public AdvertisementController(IAdvertisementService advertisementService, IMapper mapper)
        {
            _advertisementService = advertisementService;
            _mapper = mapper;
        }

        // ✅ Tüm ilanları getir (Category ve User dahil)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var adverts = await _advertisementService.TGetAllWithIncludesAsync();
            var dtoList = _mapper.Map<List<ResultAdvertisementDto>>(adverts);
            return Ok(dtoList);
        }

        // ✅ Tek ilanı ID'ye göre getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var advert = await _advertisementService.TGetByIdAsync(id);
            if (advert == null)
                return NotFound();

            var dto = _mapper.Map<ResultAdvertisementDto>(advert);
            return Ok(dto);
        }

        // ✅ Yeni ilan ekle
        [HttpPost]
        public async Task<IActionResult> Create(CreateAdvertisementDto dto)
        {
            var advert = _mapper.Map<Advertisement>(dto);
            advert.CreatedAt = DateTime.UtcNow;

            await _advertisementService.TAddAsync(advert);
            return Ok("İlan başarıyla eklendi.");
        }

        // ✅ İlan güncelle
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAdvertisementDto dto)
        {
            var advert = _mapper.Map<Advertisement>(dto);
            await _advertisementService.TUpdateAsync(advert);
            return Ok("İlan başarıyla güncellendi.");
        }

        // ✅ İlan sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var advert = await _advertisementService.TGetByIdAsync(id);
            if (advert == null)
                return NotFound();

            await _advertisementService.TDeleteAsync(advert);
            return Ok("İlan başarıyla silindi.");
        }
        [HttpGet("freelancer/{freelancerId}")]
        public async Task<IActionResult> GetByFreelancer(int freelancerId)
        {
            var ads = await _advertisementService.GetAdvertisementsByFreelancerIdAsync(freelancerId);
            var result = _mapper.Map<List<ResultAdvertisementDto>>(ads);
            return Ok(result);
        }

    }
}
