namespace FreelancePlatform.Core.DTOs.ReviewDtos
{
    public class ResultReviewDto
    {
        public int Id { get; set; }
        public string ReviewerName { get; set; }
        public string RevieweeName { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public string ProjectTitle { get; set; }
    }
}
