
using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Security.Claims;
using System.Text;
using WebSport24hNews.Application.AutoMapper.ConfigureService;
using WebSport24hNews.Application.Command.Handlerr._24hImage;
using WebSport24hNews.Application.Validations.ConfigureServices;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Add services to the container.
// DbContext

builder.Services.AddDbContext<HoangNamWebContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("HoangNamChepCode"));
});

//builder.Services.AddDbContextFactory<HoangNamWebContext>(options =>
//{
//    options.UseOracle(builder.Configuration.GetConnectionString("HoangNamChepCode"));
//});

// IDbConnection
builder.Services.AddScoped<IDbConnection>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("HoangNamChepCode");
    return new OracleConnection(connectionString);
});

//Logger
builder.Services.AddScoped<IAuditLogger, AuditLogger>();


builder.Services.AddScoped<UploadImageCommandHandler>();


//Auto Mapper
builder.Services.AddMapper();


//MeDiatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

//DI
builder.Services.AddScoped<IRepositoryService, RepositoryService>();
builder.Services.AddScoped<IDapperCore, RepositoryService>();

//Authori
builder.Services.AddScoped<IAuthorizeExtensionService, AuthorizeExtensionService>();


//FluentValidation
builder.Services.AddValidator();

//Passwork
builder.Services.AddScoped<IPasswordHasher<User24h>, PasswordHasher<User24h>>();


//c?n ??c
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.DefaultApiVersion = new ApiVersion(1, 0); // S? d?ng ApiVersion t? Asp.Versioning
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader(); // Ho?c b? ??c phiên b?n khác
    options.RouteConstraintName = "apiVersion"; // Tên constraint cho route
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddHttpContextAccessor(); // cung c?p instance ?? truy c?p vào httpContext hi?n t?i. HttpContext ch?a thông tin v? request HTTP headers, body, user, session, v.v.
builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<SwaggerFileOperationFilter>();
    c.EnableAnnotations();
    c.SupportNonNullableReferenceTypes();
});
builder.Services.AddEndpointsApiExplorer();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors();


builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = actionContext =>
    {
        var errors = actionContext.ModelState
        .Where(x => x.Value.Errors.Count > 0)
        .SelectMany(x => x.Value.Errors)
        .Select(x => x.ErrorMessage).ToArray();

        var toResult = new
        {
            Errors = errors
        };
        return new BadRequestObjectResult(toResult);
    };
});

//JwtBearer is used to authenticate(xác th?c) users using JWT -> 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) // thêm d?ch v? xác tbhuwcj vào d?ch v? c?a ?ng d?ng
    .AddJwtBearer(options => // thêm c?u hình
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidateIssuer = true,
            ValidateAudience = false
        };
    });


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins(builder.Configuration["JWT:ClientUrl"]) // ??m b?o URL này kh?p v?i frontend c?a b?n
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

builder.Services.AddAuthorization(options =>
{
    // ??nh ngh?a m?t policy có tên "AdminOnly"
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireClaim(ClaimTypes.Role, "Admin"));


    // ??nh ngh?a policy yêu c?u ng??i dùng ?ã xác th?c và thu?c nhóm "User"
    options.AddPolicy("UserAccess", policy =>
        policy.RequireAuthenticatedUser()
              .RequireRole("User"));

    // Policy yêu c?u ng??i dùng có claim "Department" v?i giá tr? "IT"
    //options.AddPolicy("ITDepartment", policy =>
    //    policy.RequireClaim("Department", "IT"));
});


var app = builder.Build();



// Configure the HTTP request pipeline.

app.UseStaticFiles(); //// Cho phép truy c?p file t?nh nh? index.html, css, js


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseStaticFiles() ???c g?i 1 l?n ?? ph?c v? th? m?c wwwroot
app.UseCors("AllowSpecificOrigin");



app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();
app.MapFallbackToFile("index.html");
app.Run();
