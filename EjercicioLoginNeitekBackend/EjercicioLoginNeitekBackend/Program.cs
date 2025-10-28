using EjercicioLoginNeitekBackend.Models;
using EjercicioLoginNeitekBackend.Repository;
using EjercicioLoginNeitekBackend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<UserContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UsersConnection")));

builder.Services.AddScoped<IRepository<User, Guid>, UserRepository>();
builder.Services.AddScoped<IRepository<UserType, int>, UserTypeRepository>();
builder.Services.AddKeyedScoped<IUserService, UserService>("UserService");
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddEndpointsApiExplorer();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();

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
