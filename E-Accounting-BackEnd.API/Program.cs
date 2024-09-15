using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting_BackEnd.API.Configurations;
using E_Accounting_BackEnd.API.Configurations.Abstraction;
using E_Accounting_BackEnd.API.Middleware;
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

app.UseExceptionMiddleware();

app.UseAuthorization();

app.UseAuthentication(); // JWT kullanabilmemiz için Authentication yapýsnýn kurulmuþ olmasý gerekmektedir.

app.MapControllers();

app.UseCors();

using (var scoped = app.Services.CreateScope())
{
    var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    
    if(!userManager.Users.Any())
    {

        AppUser user = new ()
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "admin",
            UserFirstAndLastName = "emrsnmezz",
            Email = "emircan_snmez@outlook.com",
        };

         var result = await userManager.CreateAsync(user, "Emir123.").WaitAsync(new CancellationToken());
    }
        
}

app.Run();
