namespace FreelancePlatform.Core.DTOs.BidDtos
{
    public class ResultBidDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; }
        public string Status { get; set; }
        public string FreelancerName { get; set; }
        public decimal OfferAmount { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
