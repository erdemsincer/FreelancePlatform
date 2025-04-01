namespace FreelancePlatform.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Project> Projects { get; set; }
        // User.cs
        public ICollection<Advertisement> Advertisements { get; set; }

    }
}
