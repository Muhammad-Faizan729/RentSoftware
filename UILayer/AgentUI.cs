using RentSoftware.Core.Entities;
using RentSoftware.Core.Services;
using RentSoftware.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace UILayer
{
    public class AgentUI
    {
        private readonly IAgentService _agentService;
        private readonly ICarService _carService;
        private readonly IRentService _rentService;
        private readonly ICustomerService _customerService;

        public AgentUI(IAgentService agentService, ICarService carService, IRentService rentService, ICustomerService customerService)
        {
            _agentService = agentService;
            _carService = carService;
            _rentService = rentService;
            _customerService = customerService;
        }

        public async Task DisplayAgentMenu()
        {
            Console.WriteLine("Agent Management:");
            Console.WriteLine("1. Add Agent");
            Console.WriteLine("2. Update Agent");
            Console.WriteLine("3. Delete Agent");
            Console.WriteLine("4. View All Agents");
            Console.WriteLine("5. Add Car");
            Console.WriteLine("6. Add Rent");
            Console.WriteLine("Select an option:");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await AddNewAgent();
                    break;
                case "2":
                    // UpdateAgent logic here
                    break;
                case "3":
                    // DeleteAgent logic here
                    break;
                case "4":
                    // ViewAllAgents logic here
                    break;
                case "5":
                    await AddNewCar();
                    break;
                case "6":
                    await AddRent();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        private async Task AddNewAgent()
        {
            Console.WriteLine("Enter Agent Name : ");
            string agentName = Console.ReadLine();

            var agent = new Agent
            {
                Name = agentName
            };

            await _agentService.AddAgentAsync(agent);
            Console.WriteLine("Agent added successfully.");
        }

        private async Task UpdateAgent()
        {

        }

        private async Task AddNewCar()
        {
            Console.WriteLine("Enter Car Model : ");
            string carModel = Console.ReadLine();

            var car = new Car
            {
                CarModel = carModel
            };

            await _carService.AddCarAsync(car);
            Console.WriteLine("Car added successfully.");
        }

        private async Task AddRent()
        {
            Customer selectedCustomer = null;
            Console.WriteLine("Here are some available cars : ");
            var AvailableCars = await _carService.GetAllCarAsync();

            foreach (var car in AvailableCars)
            {
                Console.WriteLine($"Car ID: {car.CarId}, Model: {car.CarModel}");
            }

            Console.WriteLine("Enter the Car ID you want to choose:");
            int selectedId = Convert.ToInt32(Console.ReadLine());

            var selectedCarWithId = await _carService.GetCarByIdAsync(selectedId);

            Console.WriteLine("Enter Agent Id : ");
            int agentId = Convert.ToInt32(Console.ReadLine());

            var selectedAgent = await _agentService.GetAgentByIdAsync(agentId);
            if (selectedAgent == null)
            {
                Console.WriteLine("Invalid Agent ID.");
                return;
            }

            Console.WriteLine("\nPress 1 : Adding Rent for existing customer \n Press 2 : Adding Rent For New Customer");
            int CustomerSelection = Convert.ToInt32(Console.ReadLine());

            switch (CustomerSelection)
            {
                case 1:
                    Console.WriteLine("Here are Registered Customers");
                    var RegisteredCustomers = await _customerService.GetAllCustomerAsync();

                    foreach (var customer in RegisteredCustomers)
                    {
                        Console.WriteLine($"Customer ID: {customer.CustomerId}, Model: {customer.CustomerName}");
                    }

                    Console.WriteLine("Enter the Customer ID you want to choose:");
                    int SelectedCustomerId = Convert.ToInt32(Console.ReadLine());

                    selectedCustomer = await _customerService.GetCustomerByIdAsync(SelectedCustomerId);

                    break;
                case 2:
                    Console.WriteLine("Enter Customer Name:");
                    string customerName = Console.ReadLine();

                    var newCustomer = new Customer
                    {
                        CustomerName = customerName
                    };

                    await _customerService.AddCustomerAsync(newCustomer);
                    Console.WriteLine("New customer added successfully.");
                    selectedCustomer = newCustomer;
                    break;
                default:
                    break;
            }

            var rent = new Rent
            {
                RentDate = DateTime.Now,
                CustomerId = selectedCustomer.CustomerId,
                CarId = selectedCarWithId.CarId,
                AgentId = selectedAgent.AgentId
            };
           await _rentService.AddRentAsync(rent);
            Console.WriteLine("Rent added successfully.");
        }
    }
}
