﻿namespace FreelancePlatform.Core.DTOs.ProjectDtos
{
    public class UpdateProjectDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Budget { get; set; }
        public int CategoryId { get; set; }
        public string Status { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
