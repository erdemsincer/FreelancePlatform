namespace FreelancePlatform.Core.DTOs.MessageDtos
{
    public class ResultMessageDto
    {
        public int Id { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
    }
}
