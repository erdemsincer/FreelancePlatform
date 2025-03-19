namespace FreelancePlatform.Core.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int FreelancerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; } // Pending / Completed

        public Project Project { get; set; }
        public User Freelancer { get; set; }
    }
}
