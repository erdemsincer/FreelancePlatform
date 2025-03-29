namespace FreelancePlatform.Core.DTOs.MessageDtos
{
    public class CreateMessageDto
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Content { get; set; }
        public List<ResultMessageDto> PreviousMessages { get; set; } = new();
    }
}
