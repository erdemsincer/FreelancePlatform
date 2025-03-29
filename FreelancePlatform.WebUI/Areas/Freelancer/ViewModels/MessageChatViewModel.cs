using FreelancePlatform.Core.DTOs.MessageDtos;

namespace FreelancePlatform.WebUI.Areas.Freelancer.ViewModels
{
    public class MessageChatViewModel
    {
        public List<ResultMessageDto> Messages { get; set; }
        public CreateMessageDto NewMessage { get; set; }
    }
}
