using DigitalArs_copia.DataAccess;
using DigitalArs_copia.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextDB>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("Administrator", policy => policy.RequireClaim(ClaimTypes.Role, "1"));

    option.AddPolicy("Consultant", policy => policy.RequireClaim(ClaimTypes.Role, "2"));


    option.AddPolicy("AdministratorAndConsultant", policy =>
    {
        policy.RequireClaim(ClaimTypes.Role, "1", "2");
    });

});
//Apply  dependency injection
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IUnitOfWork, UnitOfWorkService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
           {
               ValidateIssuerSigningKey = true,
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
               ValidateIssuer = false,
               ValidateAudience = false
           }); ;

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
        });
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWorkService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
