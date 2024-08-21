using E_Accounting.Application;
using E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.UCAF_Repositories;
using E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Commands.CreateCompany;
using E_Accounting.Application.Services.MasterService;
using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting.Domain.Entities.App_Entites.Identity;
using E_Accounting.Persistance;
using E_Accounting.Persistance.Contexts;
using E_Accounting.Persistance.Repositories.Repositories_Of_Entities.UCAF_Repositories;
using E_Accounting.Persistance.Service.MasterService;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddApplicationPart(typeof(E_Accounting.Persistance.AssemblyReferance.AssemblyManager).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup => // Swager yapýlanmasýný özelleþtirmek için bir lambda ifadesi kullandýk
{
    var jwtSecuritySheme = new OpenApiSecurityScheme // OpenApiSecurityScheme -> Swagger yapýlanmasý için bir güvenlik þemasý oluþturur. swagger/OpeApi belgelerinde kullanýlan güvenlik þemasýný temsil eder.
                                                     // Güvenlik þemasý Bir Apinin güvenlik þemasý API'ye eriþim ve kullaným sýrasýnda uygulanan güvenlik kurallarýný tanýmlar. Bu kurallar API'a kimlerin nasýl eriþebileceðini belirler. Örneðin kullanýcýlarýn kimlik doðrulamasý yapmasý gerekiyor mu hangi kimlik doðrulama yöntemini kullanmasý gerekiyor gibi vs
                                                     // Swagger/Open/Apý belgelerinde API'nin güvenlik gereksinimlerini tanýmlamak için kullabnýlan bir bileþendir. Güvenlik þemalarý, API'nin güvenliðinin nasýl saðlandýðý ve güvenlik iþlemlerinin nasýl gerçekleþtirildiðini açýklar. Swagger/OpenApi belgeleri apinin kullanýcýlar tarafýndan nasýl kullanýlacaðýný dökümante etmek için kullanýlýr ve güvenlik þemalarý da bu belgelerde yer alarak API'ýn gücenlik yönünü açýklar.
                                                     //JWT WebToken ve Güvenlik Þemasý -> JWT, kullanýcýlarýn kimliklerini doðrulamak ve yetkilendirmek için kullanýlan bir token türüdür. JWT genelliklle Bir Api'ye eriþrken kimlik doðrulamasýnýn saðlanmasý amacýyla kullanýlýr

    // OpenApiSecurityScheme : OpenApi SecurityScheme classý, Swagger/OpenApi belgelerinde güvenlik þemalarýný tanýmlamak için kullanýlýr. 
    {
        BearerFormat = "JWT", // BearerFormat özelliði/deðeri bu güvenlik þemasýnýn Berar Token Formatta token kullanacaðýný belirtir. ve Aldýðý deðer ile JWT formatýnda olduðunu ifade eder.
        Name = "JWT Authorize", // Swagger kullanýcý arayüzünde bu kimlik doðrulama þemasýnýn adýný belirtir. kullanýcýlar bu ad ile JWT doðrulama seçeneðini tanýyacaktýr
        In = ParameterLocation.Header, // JWT Token'ýn nerede bulunacaðýný bildirir. burada Header deðeri ile JWT Token'ýn HTTP isteklerinin baþlýðýnda(header'ýnda -> Authorization baþlýðý gibi) gönderileceðini belirttik. Yani Yoken Http isteðinin Header'ýnda bulunur.
        Type = SecuritySchemeType.Http, // Bu güvenlik þemasýnýn bir HTTP tabalý kimlik doðrýlama þemasý olduðunu belirtir.
        Scheme = JwtBearerDefaults.AuthenticationScheme,//kullanýlan güvenlik þemasýnýn adýný belirtir  jwtBearerDefaults.AuthenticationScheme, genellikle berarer olarak ayarlanýr ve bu JW token doðrulamasýnýn hangi þemayý kullanacaðýný bildirir.
        Description = "Put ** _Only_ ** your Jwt Bearer Token On textBox Below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme,
        }
    };
    setup.AddSecurityDefinition(jwtSecuritySheme.Reference.Id, jwtSecuritySheme);
    setup.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {jwtSecuritySheme, Array.Empty<string>() }
    });
});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateCompanyHandler).GetTypeInfo().Assembly));
builder.Services.AddAutoMapper(typeof(E_Accounting.Persistance.AssemblyReferance.AssemblyManager).Assembly);
// Add Db Context
builder.Services.AddDbContext<MasterDbContext>();
//Add DbContext Identity
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<MasterDbContext>();
//Add Dependencies on IoC Container
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUCAFQueryRepository, UCAFQueryRepository>();
builder.Services.AddScoped<IUCAFCommandRepository, UCAFCommandRepository>();
builder.Services.AddScoped<IContextService, ContextService>();

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
