namespace FreelancePlatform.Core.DTOs.BidDtos
{
    public class CreateBidDto
    {
        public int ProjectId { get; set; }
        public int FreelancerId { get; set; }
        public decimal OfferAmount { get; set; }
        public string Message { get; set; }
    }
}
