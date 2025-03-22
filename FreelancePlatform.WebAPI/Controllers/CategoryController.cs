using AutoMapper;
using FreelancePlatform.Core.DTOs.CategoryDtos;
using FreelancePlatform.Core.Entities;
using FreelancePlatform.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreelancePlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // ✅ Tüm kategorileri getir
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.TGetListAllAsync();
            var resultDtos = _mapper.Map<List<ResultCategoryDto>>(categories);
            return Ok(resultDtos);
        }

        // ✅ Kategori getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.TGetByIdAsync(id);
            if (category == null) return NotFound("Kategori bulunamadı!");
            var resultDto = _mapper.Map<ResultCategoryDto>(category);
            return Ok(resultDto);
        }

        // ✅ Kategori oluştur
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _categoryService.TAddAsync(category);
            return Ok(new { message = "Kategori başarıyla eklendi!" });
        }

        // ✅ Kategori güncelle
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryDto dto)
        {
            var category = await _categoryService.TGetByIdAsync(dto.Id);
            if (category == null) return NotFound("Kategori bulunamadı!");

            _mapper.Map(dto, category);
            await _categoryService.TUpdateAsync(category);
            return Ok(new { message = "Kategori başarıyla güncellendi!" });
        }

        // ✅ Kategori sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.TGetByIdAsync(id);
            if (category == null) return NotFound("Kategori bulunamadı!");

            await _categoryService.TDeleteAsync(category);
            return Ok(new { message = "Kategori başarıyla silindi!" });
        }
    }
    }
