namespace FreelancePlatform.Core.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } // Admin / Employer / Freelancer

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
