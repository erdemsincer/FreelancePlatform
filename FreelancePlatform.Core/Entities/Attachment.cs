namespace FreelancePlatform.Core.Entities
{
    public class Attachment
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public DateTime UploadedAt { get; set; }

        public Project Project { get; set; }
    }
}
