using AutoMapper;
using FreelancePlatform.Core.DTOs.ProjectTaskDtos;
using FreelancePlatform.Core.Entities;
using FreelancePlatform.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreelancePlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTaskController : ControllerBase
    {
        private readonly IProjectTaskService _projectTaskService;
        private readonly IMapper _mapper;

        public ProjectTaskController(IProjectTaskService projectTaskService, IMapper mapper)
        {
            _projectTaskService = projectTaskService;
            _mapper = mapper;
        }

        // ✅ Tüm task'leri getir
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _projectTaskService.TGetListAllAsync();
            var resultDtos = _mapper.Map<List<ResultProjectTaskDto>>(tasks);
            return Ok(resultDtos);
        }

        // ✅ Belirli task getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _projectTaskService.TGetByIdAsync(id);
            if (task == null) return NotFound("Proje görevi bulunamadı!");
            var resultDto = _mapper.Map<ResultProjectTaskDto>(task);
            return Ok(resultDto);
        }

        // ✅ Yeni task oluştur
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProjectTaskDto dto)
        {
            var task = _mapper.Map<ProjectTask>(dto);
           
            await _projectTaskService.TAddAsync(task);
            return Ok(new { message = "Proje görevi başarıyla oluşturuldu!" });
        }

        // ✅ Task güncelle
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProjectTaskDto dto)
        {
            var task = await _projectTaskService.TGetByIdAsync(dto.Id);
            if (task == null) return NotFound("Proje görevi bulunamadı!");

            _mapper.Map(dto, task);
            await _projectTaskService.TUpdateAsync(task);
            return Ok(new { message = "Proje görevi başarıyla güncellendi!" });
        }

        // ✅ Task sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _projectTaskService.TGetByIdAsync(id);
            if (task == null) return NotFound("Proje görevi bulunamadı!");

            await _projectTaskService.TDeleteAsync(task);
            return Ok(new { message = "Proje görevi başarıyla silindi!" });
        }
        [HttpGet("project/{projectId}")]
        public async Task<IActionResult> GetTasksByProject(int projectId)
        {
            var tasks = await _projectTaskService.GetTasksByProjectIdAsync(projectId);
            return Ok(_mapper.Map<List<ResultProjectTaskDto>>(tasks));
        }
    }
}
