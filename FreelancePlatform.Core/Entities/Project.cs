namespace FreelancePlatform.Core.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Budget { get; set; }
        public int CategoryId { get; set; }
        public int EmployerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? Deadline { get; set; }
        public string Status { get; set; } = "Açık";

        public Category Category { get; set; }
        public User Employer { get; set; }
        public ICollection<Bid> Bids { get; set; }
        public ICollection<ProjectTask> Tasks { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
    }
}
