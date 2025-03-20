using FreelancePlatform.Core.Configuration;
using FreelancePlatform.Core.MappingProfiles;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.DataAccess.Contexts;
using FreelancePlatform.DataAccess.EntityFramework;
using FreelancePlatform.Services.Abstract;
using FreelancePlatform.Services.Concrete;
using FreelancePlatform.Services.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Dependency Injection - Dallar ve Servisler
builder.Services.AddScoped<IUserDal, EFUserDal>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IProjectDal, EFProjectDal>();
builder.Services.AddScoped<IProjectService, ProjectManager>();
builder.Services.AddScoped<ICategoryDal, EFCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IBidDal, EFBidDal>();
builder.Services.AddScoped<IBidService, BidManager>();
builder.Services.AddScoped<IMessageDal, EFMessageDal>();
builder.Services.AddScoped<IMessageService, MessageManager>();
builder.Services.AddScoped<IPaymentDal, EFPaymentDal>();
builder.Services.AddScoped<IPaymentService, PaymentManager>();
builder.Services.AddScoped<IReviewDal, EFReviewDal>();
builder.Services.AddScoped<IReviewService, ReviewManager>();
builder.Services.AddScoped<INotificationDal, EFNotificationDal>();
builder.Services.AddScoped<INotificationService, NotificationManager>();
builder.Services.AddScoped<IAttachmentDal, EFAttachmentDal>();
builder.Services.AddScoped<IAttachmentService, AttachmentManager>();
builder.Services.AddScoped<ISkillDal, EFSkillDal>();
builder.Services.AddScoped<ISkillService, SkillManager>();
builder.Services.AddScoped<IUserSkillDal, EFUserSkillDal>();
builder.Services.AddScoped<IUserSkillService, UserSkillManager>();
builder.Services.AddScoped<IRoleDal, EFRoleDal>();
builder.Services.AddScoped<IRoleService, RoleManager>();
builder.Services.AddScoped<IUserRoleDal, EFUserRoleDal>();
builder.Services.AddScoped<IUserRoleService, UserRoleManager>();
builder.Services.AddScoped<IProjectTaskDal, EFProjectTaskDal>();
builder.Services.AddScoped<IProjectTaskService, ProjectTaskManager>();

// JWT Config ve TokenHelper
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddScoped<TokenHelper>();

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// JWT Authentication Middleware
var jwtConfig = builder.Configuration.GetSection("JwtSettings").Get<JwtConfig>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtConfig.Issuer,
            ValidAudience = jwtConfig.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key))
        };
    });

// Swagger & Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Authentication & Authorization middleware çaðrýlarý (Sýrasý önemli!)
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
