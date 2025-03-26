using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using ToDoApi.ToDoApi.Api.Filter;
using ToDoApi.ToDoApi.Application.Service;
using ToDoApi.ToDoApi.Application.Service.Impl;
using ToDoApi.ToDoApi.Application.Shared;
using ToDoApi.ToDoApi.Application.UseCase.Auth;
using ToDoApi.ToDoApi.Application.UseCase.Auth.Impl;
using ToDoApi.ToDoApi.Application.UseCase.Item;
using ToDoApi.ToDoApi.Application.UseCase.Item.Impl;
using ToDoApi.ToDoApi.Application.UseCase.User;
using ToDoApi.ToDoApi.Application.UseCase.User.Impl;
using ToDoApi.ToDoApi.Domain.Repository;
using ToDoApi.ToDoApi.Infrastructure.Middleware;
using ToDoApi.ToDoApi.Infrastructure.Persistence;
using ToDoApi.ToDoApi.Infrastructure.Persistence.Repository;
using ToDoApi.ToDoApi.Infrastructure.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register AppDbContext using environment variable config
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpContextAccessor();

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

// Use cases
builder.Services.AddScoped<IGetUserByEmailUseCase, GetUserByEmailUseCase>();
builder.Services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
builder.Services.AddScoped<ILogInUseCase, LogInUseCase>();
builder.Services.AddScoped<IGetUserByIdUseCase, GetUserByIdUseCase>();
builder.Services.AddScoped<IGetAuthenticatedUserUseCase, GetAuthenticatedUserUseCase>();
builder.Services.AddScoped<IGetItemsByAuthenticatedUserUseCase, GetItemsByAuthenticatedUserUseCase>();
builder.Services.AddScoped<IGetItemByIdUseCase, GetItemByIdUseCase>();
builder.Services.AddScoped<ICreateItemUseCase, CreateItemUseCase>();
builder.Services.AddScoped<IUpdateItemUseCase, UpdateItemUseCase>();
builder.Services.AddScoped<IDeleteItemUseCase, DeleteItemUseCase>();

// Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IItemService, ItemService>();

// Middlewares
builder.Services.AddScoped<AuthenticationMiddleware>();

// Shared
builder.Services.AddScoped<IPasswordHasher, BcryptPasswordHasher>();
builder.Services.AddScoped<ITokenManager, TokenManager>();
builder.Services.AddScoped<ISessionContext, SessionContext>();

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers(options => { options.Filters.Add<HttpExceptionFilter>(); }).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

var app = builder.Build();

// Apply migrations and ensure uuid extension
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.ExecuteSqlRaw("CREATE EXTENSION IF NOT EXISTS \"uuid-ossp\";");
    dbContext.Database.Migrate(); // Applies all migrations
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<AuthenticationMiddleware>();
app.MapControllers();

app.Run();