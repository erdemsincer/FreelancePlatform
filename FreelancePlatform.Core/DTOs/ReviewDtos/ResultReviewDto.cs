namespace FreelancePlatform.Core.DTOs.ReviewDtos
{
    public class ResultReviewDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; }
        public int ReviewerId { get; set; }
        public string ReviewerName { get; set; } // Bunlar NULL geliyor
        public int RevieweeId { get; set; }
        public string RevieweeName { get; set; } // Bunlar NULL geliyor
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
