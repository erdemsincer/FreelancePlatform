﻿namespace FreelancePlatform.Core.DTOs.NotificationDtos
{
    public class ResultNotificationDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
