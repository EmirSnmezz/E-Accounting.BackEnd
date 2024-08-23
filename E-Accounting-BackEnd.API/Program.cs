using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting_BackEnd.API.Configurations;
using E_Accounting_BackEnd.API.Configurations.Abstraction;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();

builder.Services.InstallService(builder.Configuration, typeof(IServiceRegistration).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication(); // JWT kullanabilmemiz için Authentication yapýsnýn kurulmuþ olmasý gerekmektedir.

app.MapControllers();

using (var scoped = app.Services.CreateScope())
{
    var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    
    if(!userManager.Users.Any())
    {
        userManager.CreateAsync(new AppUser
        {
            UserName = "admin",
            UserFirstAndLastName = "emrsnmezz",
            Email = "emircan_snmez@outlook.com",
            Id = Guid.NewGuid().ToString(),
        },"Password12"
            ).Wait();
    }
        
}

app.Run();
