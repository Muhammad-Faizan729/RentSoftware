using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RentSoftware.Core.Entities;
using RentSoftware.Core.Repositories;
using RentSoftware.Core.Services;
using RentSoftware.Repository;
using RentSoftware.Service;
using System;
using System.Threading.Tasks;
using UILayer;

namespace RentSoftware
{
    class Program
    {
        static async Task Main(string[] args)
        {
            bool isExit  = true;

            var serviceCollection = new ServiceCollection();
            ConfigureService(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var agentService = serviceProvider.GetService<IAgentService>();

            var agentUI = serviceProvider.GetService<AgentUI>();


            while (isExit)
            {
                Console.WriteLine("Please Select One Option : ");
                Console.WriteLine("\n Press 1 : Display-Menu,\n Press 2 : Exit");
                int Choice = Convert.ToInt32(Console.ReadLine());
                switch (Choice)
                {
                    case 1:
                        await agentUI.DisplayAgentMenu();
                        break;
                    case 2:
                        isExit = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input!. Please enter a valid input");
                        break;
                }
            }
        }

        private static void ConfigureService(ServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAgentService, AgentService>();
            serviceCollection.AddTransient<ICustomerService, CustomerService>();
            serviceCollection.AddTransient<ICarService, CarService>();
            serviceCollection.AddTransient<IRentService, RentService>();

            serviceCollection.AddTransient<IAgentRepository, AgentRepository>();
            serviceCollection.AddTransient<ICustomerRepository, CustomerRepository>();
            serviceCollection.AddTransient<ICarRepository, CarRepository>();
            serviceCollection.AddTransient<IRentRepository, RentRepository>();

            serviceCollection.AddTransient<AgentUI>();

            serviceCollection.AddDbContext<RentSoftwareDbContext>(options =>
                options.UseSqlServer("Server=.\\SQLEXPRESS; Database=RentSoftware; Trusted_Connection=true; TrustServerCertificate=true;"));
        }
    }
}
