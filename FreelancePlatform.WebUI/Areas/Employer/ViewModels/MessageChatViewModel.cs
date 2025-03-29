using FreelancePlatform.Core.DTOs.MessageDtos;

namespace FreelancePlatform.WebUI.Areas.Employer.ViewModels
{
    public class MessageChatViewModel
    {
        public List<ResultMessageDto> Messages { get; set; }
        public CreateMessageDto NewMessage { get; set; }
    }
}
