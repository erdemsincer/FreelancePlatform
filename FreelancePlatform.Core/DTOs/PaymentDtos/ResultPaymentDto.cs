namespace FreelancePlatform.Core.DTOs.PaymentDtos
{
    public class ResultPaymentDto
    {
        public int Id { get; set; }
        public string ProjectTitle { get; set; }
        public string FreelancerName { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
