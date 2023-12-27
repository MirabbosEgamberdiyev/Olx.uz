using AutoMapper;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccesLayer.Datas;
using DataAccesLayer.Interfaces;
using DataAccesLayer.Repositories;
using DTO;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options
             => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalSqlServer")));
// Add AutoMepper

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMepperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddTransient<IAdsElonInterface, AdsElonRepository>();
builder.Services.AddTransient<ICategoryInterface, CategoryRepository>();

builder.Services.AddTransient<IChatInterface, ChatRepository>();
builder.Services.AddTransient<IImageInterface, ImageRepository>();

builder.Services.AddTransient<IMessageInterface, MessageRepository>();
builder.Services.AddTransient<IRegionInterface, RegionRepository>();

builder.Services.AddTransient<ISubCategoryInterface, SubCategoryRepository>();
builder.Services.AddTransient<ISubRegionInterface, SubRegionRepository>();

builder.Services.AddTransient<IUserInterface, UserRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Add Services
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ISubCategoryService, SubCategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
