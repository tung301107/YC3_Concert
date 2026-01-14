using YC3.Interfaces;
using YC3.Services;
using YC3.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
// --- ??NG KÝ DI T?I ?ÂY ---
// Thêm vào file Program.cs
// Program.cs
builder.Services.AddSingleton<IStatisticsService, StatisticsService>(); // Singleton cho th?ng kê
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IEventService, EventService>();               // Scoped cho qu?n lý s? ki?n
builder.Services.AddScoped<IUserService, UserService>();                 // Scoped cho khách hàng            // T?o m?i m?i Request
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();