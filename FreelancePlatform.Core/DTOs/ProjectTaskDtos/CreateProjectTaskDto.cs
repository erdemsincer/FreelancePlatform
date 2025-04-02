namespace FreelancePlatform.Core.DTOs.ProjectTaskDtos
{
    public class CreateProjectTaskDto
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } = "ToDo";
    }
}
