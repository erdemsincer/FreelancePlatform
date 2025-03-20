namespace FreelancePlatform.Core.DTOs.ProjectTaskDtos
{
    public class ResultProjectTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; }
    }
}
