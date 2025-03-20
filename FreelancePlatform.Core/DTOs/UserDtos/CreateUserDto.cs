namespace FreelancePlatform.Core.DTOs.UserDtos
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string ProfileImageUrl { get; set; }
    }
}
