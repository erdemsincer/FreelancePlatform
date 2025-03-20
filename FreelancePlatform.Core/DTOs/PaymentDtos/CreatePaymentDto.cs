namespace FreelancePlatform.Core.DTOs.PaymentDtos
{
    public class CreatePaymentDto
    {
        public int ProjectId { get; set; }
        public int FreelancerId { get; set; }
        public decimal Amount { get; set; }
    }
}
