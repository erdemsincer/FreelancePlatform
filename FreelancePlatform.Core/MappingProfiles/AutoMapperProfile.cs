﻿using AutoMapper;
using FreelancePlatform.Core.Entities;
using FreelancePlatform.Core.DTOs.UserDtos;
using FreelancePlatform.Core.DTOs.ProjectDtos;
using FreelancePlatform.Core.DTOs.CategoryDtos;
using FreelancePlatform.Core.DTOs.BidDtos;
using FreelancePlatform.Core.DTOs.MessageDtos;
using FreelancePlatform.Core.DTOs.PaymentDtos;
using FreelancePlatform.Core.DTOs.NotificationDtos;
using FreelancePlatform.Core.DTOs.ReviewDtos;
using FreelancePlatform.Core.DTOs.AttachmentDtos;
using FreelancePlatform.Core.DTOs.SkillDtos;
using FreelancePlatform.Core.DTOs.UserSkillDtos;
using FreelancePlatform.Core.DTOs.RoleDtos;
using FreelancePlatform.Core.DTOs.UserRoleDtos;
using FreelancePlatform.Core.DTOs.ProjectTaskDtos;

namespace FreelancePlatform.Core.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, ResultUserDto>().ReverseMap();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();

            CreateMap<Project, ResultProjectDto>().ReverseMap();
            CreateMap<CreateProjectDto, Project>();
            CreateMap<UpdateProjectDto, Project>();

            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();

            CreateMap<Bid, ResultBidDto>().ReverseMap();
            CreateMap<CreateBidDto, Bid>();
            CreateMap<UpdateBidDto, Bid>();

            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<CreateMessageDto, Message>();

            CreateMap<Payment, ResultPaymentDto>().ReverseMap();
            CreateMap<CreatePaymentDto, Payment>();

            CreateMap<Notification, ResultNotificationDto>().ReverseMap();

            CreateMap<Review, ResultReviewDto>().ReverseMap();
            CreateMap<CreateReviewDto, Review>();

            CreateMap<Attachment, ResultAttachmentDto>().ReverseMap();
            CreateMap<CreateAttachmentDto, Attachment>();
            CreateMap<UpdateAttachmentDto, Attachment>();

            CreateMap<Skill, ResultSkillDto>().ReverseMap();
            CreateMap<CreateSkillDto, Skill>();

            CreateMap<UserSkill, ResultUserSkillDto>().ReverseMap();
            CreateMap<CreateUserSkillDto, UserSkill>();

            CreateMap<Role, ResultRoleDto>().ReverseMap();
            CreateMap<CreateRoleDto, Role>();

            CreateMap<UserRole, ResultUserRoleDto>().ReverseMap();
            CreateMap<CreateUserRoleDto, UserRole>();

            CreateMap<ProjectTask, ResultProjectTaskDto>().ReverseMap();
            CreateMap<CreateProjectTaskDto, ProjectTask>();
            CreateMap<UpdateProjectTaskDto, ProjectTask>();
        }
    }
}