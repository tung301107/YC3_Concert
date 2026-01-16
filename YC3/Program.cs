using Microsoft.EntityFrameworkCore;
using YC3.Data;
using YC3.Interfaces;
using YC3.Services;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình các dịch vụ cơ bản
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Kết nối Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddTransient<IPriceCalculator, PriceCalculator>();
builder.Services.AddSingleton<IStatisticsService, StatisticsService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Cấu hình HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Lưu ý: Đã lược bỏ app.UseAuthentication()
app.UseAuthorization();

app.MapControllers();
app.Run();