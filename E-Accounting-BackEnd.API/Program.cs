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
builder.Services.AddSwaggerGen(setup => // Swager yap�lanmas�n� �zelle�tirmek i�in bir lambda ifadesi kulland�k
{
    var jwtSecuritySheme = new OpenApiSecurityScheme // OpenApiSecurityScheme -> Swagger yap�lanmas� i�in bir g�venlik �emas� olu�turur. swagger/OpeApi belgelerinde kullan�lan g�venlik �emas�n� temsil eder.
                                                     // G�venlik �emas� Bir Apinin g�venlik �emas� API'ye eri�im ve kullan�m s�ras�nda uygulanan g�venlik kurallar�n� tan�mlar. Bu kurallar API'a kimlerin nas�l eri�ebilece�ini belirler. �rne�in kullan�c�lar�n kimlik do�rulamas� yapmas� gerekiyor mu hangi kimlik do�rulama y�ntemini kullanmas� gerekiyor gibi vs
                                                     // Swagger/Open/Ap� belgelerinde API'nin g�venlik gereksinimlerini tan�mlamak i�in kullabn�lan bir bile�endir. G�venlik �emalar�, API'nin g�venli�inin nas�l sa�land��� ve g�venlik i�lemlerinin nas�l ger�ekle�tirildi�ini a��klar. Swagger/OpenApi belgeleri apinin kullan�c�lar taraf�ndan nas�l kullan�laca��n� d�k�mante etmek i�in kullan�l�r ve g�venlik �emalar� da bu belgelerde yer alarak API'�n g�cenlik y�n�n� a��klar.
                                                     //JWT WebToken ve G�venlik �emas� -> JWT, kullan�c�lar�n kimliklerini do�rulamak ve yetkilendirmek i�in kullan�lan bir token t�r�d�r. JWT genelliklle Bir Api'ye eri�rken kimlik do�rulamas�n�n sa�lanmas� amac�yla kullan�l�r

    // OpenApiSecurityScheme : OpenApi SecurityScheme class�, Swagger/OpenApi belgelerinde g�venlik �emalar�n� tan�mlamak i�in kullan�l�r. 
    {
        BearerFormat = "JWT", // BearerFormat �zelli�i/de�eri bu g�venlik �emas�n�n Berar Token Formatta token kullanaca��n� belirtir. ve Ald��� de�er ile JWT format�nda oldu�unu ifade eder.
        Name = "JWT Authorize", // Swagger kullan�c� aray�z�nde bu kimlik do�rulama �emas�n�n ad�n� belirtir. kullan�c�lar bu ad ile JWT do�rulama se�ene�ini tan�yacakt�r
        In = ParameterLocation.Header, // JWT Token'�n nerede bulunaca��n� bildirir. burada Header de�eri ile JWT Token'�n HTTP isteklerinin ba�l���nda(header'�nda -> Authorization ba�l��� gibi) g�nderilece�ini belirttik. Yani Yoken Http iste�inin Header'�nda bulunur.
        Type = SecuritySchemeType.Http, // Bu g�venlik �emas�n�n bir HTTP tabal� kimlik do�r�lama �emas� oldu�unu belirtir.
        Scheme = JwtBearerDefaults.AuthenticationScheme,//kullan�lan g�venlik �emas�n�n ad�n� belirtir  jwtBearerDefaults.AuthenticationScheme, genellikle berarer olarak ayarlan�r ve bu JW token do�rulamas�n�n hangi �emay� kullanaca��n� bildirir.
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
