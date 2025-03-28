using AutoMapper;
using FreelancePlatform.Core.DTOs.BidDtos;
using FreelancePlatform.Core.Entities;
using FreelancePlatform.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreelancePlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly IBidService _bidService;
        private readonly IMapper _mapper;

        public BidController(IBidService bidService, IMapper mapper)
        {
            _bidService = bidService;
            _mapper = mapper;
        }

        // ✅ Tüm teklifleri getir
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bids = await _bidService.TGetListAllAsync();
            var resultDtos = _mapper.Map<List<ResultBidDto>>(bids);
            return Ok(resultDtos);
        }

        // ✅ Teklif getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var bid = await _bidService.TGetByIdAsync(id);
            if (bid == null) return NotFound("Teklif bulunamadı!");
            var resultDto = _mapper.Map<ResultBidDto>(bid);
            return Ok(resultDto);
        }

        // ✅ Belirli projeye ait teklifleri getir
        [HttpGet("project/{projectId}")]
        public async Task<IActionResult> GetBidsByProjectId(int projectId)
        {
            var bids = await _bidService.GetBidsByProjectIdAsync(projectId);
            var resultDtos = _mapper.Map<List<ResultBidDto>>(bids);
            return Ok(resultDtos);
        }

        // ✅ Belirli freelancer'a ait teklifleri getir
        [HttpGet("freelancer/{freelancerId}")]
        public async Task<IActionResult> GetBidsByFreelancerId(int freelancerId)
        {
            var bids = await _bidService.GetBidsByFreelancerIdAsync(freelancerId);
            var resultDtos = _mapper.Map<List<ResultBidWithProjectDto>>(bids);
            return Ok(resultDtos);
        }

        // ✅ Teklif oluştur
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBidDto dto)
        {
            var bid = _mapper.Map<Bid>(dto);
            bid.CreatedAt = DateTime.UtcNow;
            await _bidService.AddBidAndUpdateProjectStatusAsync(bid);
            return Ok(new { message = "Teklif başarıyla eklendi!" });
        }

        // ✅ Teklif güncelle
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBidDto dto)
        {
            var bid = await _bidService.TGetByIdAsync(dto.Id);
            if (bid == null) return NotFound("Teklif bulunamadı!");

            _mapper.Map(dto, bid);
            await _bidService.TUpdateAsync(bid);
            return Ok(new { message = "Teklif başarıyla güncellendi!" });
        }

        // ✅ Teklif sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var bid = await _bidService.TGetByIdAsync(id);
            if (bid == null) return NotFound("Teklif bulunamadı!");

            await _bidService.TDeleteAsync(bid);
            return Ok(new { message = "Teklif başarıyla silindi!" });
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddBid([FromBody] CreateBidDto dto)
        {
            var bid = _mapper.Map<Bid>(dto);
            bid.CreatedAt = DateTime.UtcNow;
            await _bidService.AddBidAndUpdateProjectStatusAsync(bid);
            return Ok(new { message = "Teklif verildi ve proje durumu güncellendi." });
        }

        [HttpPost("accept/{bidId}")]
        public async Task<IActionResult> AcceptBid(int bidId)
        {
            await _bidService.AcceptBidAsync(bidId);
            return Ok(new { message = "Teklif kabul edildi!" });
        }
        [HttpGet("by-employer/{employerId}")]
        public async Task<IActionResult> GetBidsByEmployer(int employerId)
        {
            var bids = await _bidService.GetBidsByEmployerIdAsync(employerId);
            return Ok(bids);
        }

    }
}
