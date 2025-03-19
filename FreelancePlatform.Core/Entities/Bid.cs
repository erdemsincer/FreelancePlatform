namespace FreelancePlatform.Core.Entities
{
    public class Bid
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int FreelancerId { get; set; }
        public decimal OfferAmount { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }

        public Project Project { get; set; }
        public User Freelancer { get; set; }
    }
}
