namespace FreelancePlatform.Core.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int ReviewerId { get; set; }
        public int RevieweeId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; } // 1-5

        public Project Project { get; set; }
        public User Reviewer { get; set; }
        public User Reviewee { get; set; }
    }
}
