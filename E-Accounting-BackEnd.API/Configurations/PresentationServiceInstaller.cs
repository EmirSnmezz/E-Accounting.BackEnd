using E_Accounting.Persistance.AssemblyReferance;
using E_Accounting_BackEnd.API.Configurations.Abstraction;
using E_Accounting_BackEnd.API.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace E_Accounting_BackEnd.API.Configurations
{
    public class PresentationServiceInstaller : IServiceRegistration
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ExceptionMiddleware>();

            services.AddControllers().AddApplicationPart(typeof(AssemblyManager).Assembly);

            services.AddSwaggerGen(setup => // Swager yapılanmasını özelleştirmek için bir lambda ifadesi kullandık
        {
            var jwtSecuritySheme = new OpenApiSecurityScheme // OpenApiSecurityScheme -> Swagger yapılanması için bir güvenlik şeması oluşturur. swagger/OpeApi belgelerinde kullanılan güvenlik şemasını temsil eder.
                                                             // Güvenlik şeması Bir Apinin güvenlik şeması API'ye erişim ve kullanım sırasında uygulanan güvenlik kurallarını tanımlar. Bu kurallar API'a kimlerin nasıl erişebileceğini belirler. Örneğin kullanıcıların kimlik doğrulaması yapması gerekiyor mu hangi kimlik doğrulama yöntemini kullanması gerekiyor gibi vs
                                                             // Swagger/Open/Apı belgelerinde API'nin güvenlik gereksinimlerini tanımlamak için kullabnılan bir bileşendir. Güvenlik şemaları, API'nin güvenliğinin nasıl sağlandığı ve güvenlik işlemlerinin nasıl gerçekleştirildiğini açıklar. Swagger/OpenApi belgeleri apinin kullanıcılar tarafından nasıl kullanılacağını dökümante etmek için kullanılır ve güvenlik şemaları da bu belgelerde yer alarak API'ın gücenlik yönünü açıklar.
                                                             //JWT WebToken ve Güvenlik Şeması -> JWT, kullanıcıların kimliklerini doğrulamak ve yetkilendirmek için kullanılan bir token türüdür. JWT genelliklle Bir Api'ye erişrken kimlik doğrulamasının sağlanması amacıyla kullanılır

            // OpenApiSecurityScheme : OpenApi SecurityScheme classı, Swagger/OpenApi belgelerinde güvenlik şemalarını tanımlamak için kullanılır. 
            {
                BearerFormat = "JWT", // BearerFormat özelliği/değeri bu güvenlik şemasının Berar Token Formatta token kullanacağını belirtir. ve Aldığı değer ile JWT formatında olduğunu ifade eder.
                Name = "JWT Authorize", // Swagger kullanıcı arayüzünde bu kimlik doğrulama şemasının adını belirtir. kullanıcılar bu ad ile JWT doğrulama seçeneğini tanıyacaktır
                In = ParameterLocation.Header, // JWT Token'ın nerede bulunacağını bildirir. burada Header değeri ile JWT Token'ın HTTP isteklerinin başlığında(header'ında -> Authorization başlığı gibi) gönderileceğini belirttik. Yani Yoken Http isteğinin Header'ında bulunur.
                Type = SecuritySchemeType.Http, // Bu güvenlik şemasının bir HTTP tabalı kimlik doğrılama şeması olduğunu belirtir.
                Scheme = JwtBearerDefaults.AuthenticationScheme,//kullanılan güvenlik şemasının adını belirtir  jwtBearerDefaults.AuthenticationScheme, genellikle berarer olarak ayarlanır ve bu JW token doğrulamasının hangi şemayı kullanacağını bildirir.
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

        }
    }
}
