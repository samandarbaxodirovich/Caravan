using Caravan.Api.Configuration;
using Caravan.Api.Configuration.LayerConfigurations;
using Caravan.Api.Middlewares;
using Caravan.DataAccess.Interfaces.Common;
using Caravan.DataAccess.Repositories.Common;
using Caravan.Service.Common.Helpers;
using Caravan.Service.Common.Security;
using Caravan.Service.Interfaces;
using Caravan.Service.Interfaces.Common;
using Caravan.Service.Interfaces.Security;
using Caravan.Service.Services;
using Caravan.Service.Services.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

//-> Services
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();


builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthManager, AuthManager>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.ConfigurAuth();
builder.Services.AddScoped<IPaginatorService, PaginatorService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ITruckService, TruckService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddMemoryCache();

builder.Services.ConfigureSwaggerAuthorize();
//database
builder.ConfigureDataAccess();


//Mapper
builder.Services.AddAutoMapper(typeof(MappingConfiguration));


//Middlewares
var app = builder.Build();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseStaticFiles();

if (app.Services.GetService<IHttpContextAccessor>() != null)
    HttpContextHelper.Accessor = app.Services.GetRequiredService<IHttpContextAccessor>();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
