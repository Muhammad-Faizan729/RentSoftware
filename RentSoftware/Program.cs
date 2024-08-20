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
            var dbContext = new RentSoftwareDbContext();

            var agentRepository = new AgentRepository(dbContext);
            var agentService = new AgentService(agentRepository);

            var customerRepository = new CustomerRepository(dbContext);
            var customerService = new CustomerService(customerRepository);
            var customerUI = new CustomerUI(customerService);

            var carRepository = new CarRepository(dbContext);
            var carService = new CarService(carRepository);

            var rentRepository = new RentRepository(dbContext);
            var rentService = new RentService(rentRepository);

            var agentUI = new AgentUI(agentService, carService, rentService, customerService);


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

       
    }
}
