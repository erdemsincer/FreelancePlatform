namespace FreelancePlatform.Core.DTOs.MessageDtos
{
    public class ResultMessageDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public bool IsRead { get; set; }
    }
}
