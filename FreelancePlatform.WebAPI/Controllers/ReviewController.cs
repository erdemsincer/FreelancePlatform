﻿using AutoMapper;
using FreelancePlatform.Core.DTOs.ReviewDtos;
using FreelancePlatform.Core.Entities;
using FreelancePlatform.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreelancePlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public ReviewController(IReviewService reviewService, IMapper mapper)
        {
            _reviewService = reviewService;
            _mapper = mapper;
        }

        // ✅ Tüm değerlendirmeleri getir
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviews = await _reviewService.TGetListAllAsync();
            var resultDtos = _mapper.Map<List<ResultReviewDto>>(reviews);
            return Ok(resultDtos);
        }

        // ✅ Belirli değerlendirmeyi getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var review = await _reviewService.TGetByIdAsync(id);
            if (review == null) return NotFound("Değerlendirme bulunamadı!");
            var resultDto = _mapper.Map<ResultReviewDto>(review);
            return Ok(resultDto);
        }

        // ✅ Yeni değerlendirme ekle
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReviewDto dto)
        {
            if (dto == null || dto.ProjectId == 0 || dto.ReviewerId == 0 || dto.RevieweeId == 0)
                return BadRequest("Eksik bilgi!");

            var review = _mapper.Map<Review>(dto);
            await _reviewService.TAddAsync(review);
            return Ok(new { message = "Yorum başarıyla eklendi." });
        }

        // ✅ Değerlendirme sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var review = await _reviewService.TGetByIdAsync(id);
            if (review == null) return NotFound("Değerlendirme bulunamadı!");

            await _reviewService.TDeleteAsync(review);
            return Ok(new { message = "Değerlendirme başarıyla silindi!" });
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetReviewsForUser(int userId)
        {
            var reviews = await _reviewService.GetReviewsByUserIdAsync(userId);
            var result = reviews.Select(r => new ResultReviewDto
            {
                Id = r.Id,
                Comment = r.Comment,
                Rating = r.Rating,
                ReviewerName = $"{r.Reviewer.FirstName} {r.Reviewer.LastName}",
                ProjectTitle = r.Project.Title
            }).ToList();

            return Ok(result);
        }
        [HttpGet("freelancer/{freelancerId}")]
        public async Task<IActionResult> GetReviewsByFreelancer(int freelancerId)
        {
            var reviews = await _reviewService.GetReviewsByRevieweeIdAsync(freelancerId);
            var result = _mapper.Map<List<ResultReviewDto>>(reviews);
            return Ok(result);
        }

    }
}
