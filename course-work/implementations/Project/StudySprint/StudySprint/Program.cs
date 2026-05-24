using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using StudySprint.Data.Data;
using StudySprint.Repository;
using StudySprint.Repository.Interfaces;
using StudySprint.Services;
using StudySprint.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "StudySprint API",

        Version = "v1",

        Description =
            "StudySprint is a distributed study planning system that allows users to manage study sessions and study goals. The API supports CRUD operations, validation and structured data management.",

        Contact = new OpenApiContact
        {
            Name = "Dian Yordanov"
        }
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration
            .GetConnectionString(
                "DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStudySessionService, StudySessionService>();
builder.Services.AddScoped<IStudyGoalService, StudyGoalService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();