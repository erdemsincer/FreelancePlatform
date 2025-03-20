namespace FreelancePlatform.Core.DTOs.ReviewDtos
{
    public class CreateReviewDto
    {
        public int ProjectId { get; set; }
        public int ReviewerId { get; set; }
        public int RevieweeId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; } 
    }
}
