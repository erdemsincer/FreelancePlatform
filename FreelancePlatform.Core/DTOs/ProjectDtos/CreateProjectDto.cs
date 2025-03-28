using System.Text.Json.Serialization;

namespace FreelancePlatform.Core.DTOs.ProjectDtos
{
    public class CreateProjectDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Budget { get; set; }
        public int CategoryId { get; set; }
        public int EmployerId { get; set; }
        public DateTime? Deadline { get; set; }
       
        public string Status { get; set; } = "Open";
    }
}
