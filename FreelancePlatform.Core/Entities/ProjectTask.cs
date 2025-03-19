namespace FreelancePlatform.Core.Entities
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // ToDo / InProgress / Done

        public Project Project { get; set; }
    }
}
