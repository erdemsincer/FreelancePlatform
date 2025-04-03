using AutoMapper;
using FreelancePlatform.Core.DTOs.ProjectDtos;
using FreelancePlatform.Core.Entities;
using FreelancePlatform.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreelancePlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }
       
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProjectDto dto)
        {
            var project = _mapper.Map<Project>(dto);
            project.CreatedAt = DateTime.UtcNow;
            await _projectService.TAddAsync(project);
            return Ok(new { message = "Proje başarıyla eklendi!" });
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProjectDto dto)
        {
            var project = await _projectService.TGetByIdAsync(dto.Id);
            if (project == null) return NotFound("Proje bulunamadı!");

            _mapper.Map(dto, project);
            await _projectService.TUpdateAsync(project);
            return Ok(new { message = "Proje başarıyla güncellendi!" });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _projectService.TGetByIdAsync(id);
            if (project == null) return NotFound("Proje bulunamadı!");

            await _projectService.TDeleteAsync(project);
            return Ok(new { message = "Proje başarıyla silindi!" });
        }
        [HttpGet("detailed")]
        public async Task<IActionResult> GetAllDetailed()
        {
            var allProjects = await _projectService.GetAllDetailedProjectsAsync();
            var openProjects = allProjects.Where(p => p.Status == "Açık").ToList();
            return Ok(openProjects);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectDetailById(int id)
        {
            var project = await _projectService.GetProjectByIdWithIncludeAsync(id);
            if (project == null)
                return NotFound("Proje bulunamadı.");

            var dto = _mapper.Map<ResultProjectDto>(project);
            return Ok(dto);
        }

        [HttpGet("employer/{employerId}")]
        public async Task<IActionResult> GetProjectsByEmployerId(int employerId)
        {
            var projects = await _projectService.GetProjectsByEmployerIdAsync(employerId);
            var result = _mapper.Map<List<ResultProjectDto>>(projects);
            return Ok(result);
        }
        [HttpPut("update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateProjectStatusDto dto)
        {
            var project = await _projectService.TGetByIdAsync(dto.ProjectId);
            if (project == null) return NotFound("Proje bulunamadı!");

            project.Status = dto.NewStatus;
            await _projectService.TUpdateAsync(project);

            return Ok(new { message = "Proje durumu güncellendi!" });
        }
        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetProjectsByCategory(int categoryId)
        {
            var projects = await _projectService.GetAllProjectsWithCategoryAsync();
            var filtered = projects.Where(p => p.CategoryId == categoryId && p.Status == "Açık").ToList();
            var result = _mapper.Map<List<ResultProjectDto>>(filtered);
            return Ok(result);
        }







    }
}
