using E_Accounting_BackEnd.API.Configurations;
using E_Accounting_BackEnd.API.Configurations.Abstraction;

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

app.Run();
