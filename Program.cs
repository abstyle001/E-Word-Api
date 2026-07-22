using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using E_Word_Api.Datas;
using E_Word_Api.Models;
using E_Word_Api.Repositories;
using E_Word_Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddDbContext<EWordDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAuthorization();
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<EWordDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddTransient<IEmailSender<AppUser>, AppUserEmailSender>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
        options.DefaultChallengeScheme =
            options.DefaultForbidScheme =
                options.DefaultScheme =
                    options.DefaultSignInScheme =
                        options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"] ?? string.Empty)
        ),
        RoleClaimType = ClaimTypes.Role
    };
});

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<WordRepository>();
builder.Services.AddScoped<CET6BookRepository>();
builder.Services.AddScoped<ProgressRepository>();
builder.Services.AddScoped<UserBookRepository>();
builder.Services.AddScoped<UserSessionRepository>();
builder.Services.AddScoped<UserWordRepository>();
builder.Services.AddScoped<CoinRepository>();

var app = builder.Build();

// 自动执行 EF Core 数据库迁移（Docker 启动时）
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EWordDbContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 容器内只跑 HTTP，HTTPS 重定向由反向代理（Nginx/Ingress）处理
if (!bool.TryParse(builder.Configuration["DISABLE_HTTPS_REDIRECT"], out var disable) || !disable)
{
    app.UseHttpsRedirection();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ResponseWrapperMiddleware>();
app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "Statics")
    ),
    RequestPath = "/statics"
});

app.Run();