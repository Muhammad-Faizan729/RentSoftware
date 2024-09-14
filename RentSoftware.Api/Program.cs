using Microsoft.EntityFrameworkCore;
using RentSoftware.Core.Repositories;
using RentSoftware.Core.RepositoriesSP;
using RentSoftware.Core.Services;
using RentSoftware.Core.SevicesSP;
using RentSoftware.Repository;
using RentSoftware.Repository_StoredProcedure_;
using RentSoftware.Service;
using RentSoftware.Service_StoredProcedure_;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ConfigureServices(builder.Services);


builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCors", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("MyCors");
//app.UseCors("AllowAngularApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();

static void ConfigureServices(IServiceCollection serviceCollection)
{
    serviceCollection.AddTransient<IAgentService, AgentService>();
    serviceCollection.AddTransient<ICustomerService, CustomerService>();
    serviceCollection.AddTransient<ICarService, CarService>();
    serviceCollection.AddTransient<IRentService, RentService>();

    serviceCollection.AddTransient<IAgentRepository, AgentRepository>();
    serviceCollection.AddTransient<ICustomerRepository, CustomerRepository>();
    serviceCollection.AddTransient<ICarRepository, CarRepository>();
    serviceCollection.AddTransient<IRentRepository, RentRepository>();    

    serviceCollection.AddTransient<IAgentRepositorySP, AgentRepositorySP>();
    serviceCollection.AddTransient<IAgentServiceSP, AgentServiceSP>();

    serviceCollection.AddDbContext<RentSoftwareDbContext>(options =>
        options.UseSqlServer("Server=.\\SQLEXPRESS; Database=RentSoftware; Trusted_Connection=true; TrustServerCertificate=true;"));
    
}
