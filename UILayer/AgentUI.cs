using RentSoftware.Core.Entities;
using RentSoftware.Core.RepositoriesSP;
using RentSoftware.Core.Services;
using RentSoftware.Core.SevicesSP;
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
        private readonly IAgentServiceSP _agentServiceSP;
        private readonly IAgentRepositorySP _agentRepositorySP;

        
        public AgentUI(IAgentService agentService, ICarService carService, IRentService rentService, ICustomerService customerService, IAgentRepositorySP agentRepositorySP, IAgentServiceSP agentServiceSP)
        {
            _agentService = agentService;
            _carService = carService;
            _rentService = rentService;
            _customerService = customerService;
            _agentServiceSP = agentServiceSP;
            _agentRepositorySP = agentRepositorySP;
        }
        

        public async Task DisplayAgentMenu()
        {
            Console.WriteLine("Agent Management:");

            Console.WriteLine("1. Add Agent");
            Console.WriteLine("2. Update Agent");
            Console.WriteLine("3. Delete Agent");
            Console.WriteLine("4. View All Agents");

            Console.WriteLine("5. Add Customer");
            Console.WriteLine("6. Update Customer");
            Console.WriteLine("7. Delete Customer");
            Console.WriteLine("8. View All Customers");

            Console.WriteLine("9.  Add Car");
            Console.WriteLine("10. Update Car");
            Console.WriteLine("11. Delete Car");
            Console.WriteLine("12. View All Car");

            Console.WriteLine("13. Add Rent");
            Console.WriteLine("14. View All Rents");

            Console.WriteLine("15. Add Agent Using Technique 'Stored Procedure'");
            Console.WriteLine("16. View All Agent Using Technique 'Stored Procedure'");

            Console.WriteLine("Select an option:");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await AddNewAgent();
                    break;
                case "2":
                    await UpdateAgent();
                    break;
                case "3":
                    await DeleteAgent();
                    break;
                case "4":
                    await ViewAllAgents();
                    break;
                case "5":
                    await AddNewCustomer();
                    break;
                case "6":
                    await UpdateCustomer();
                    break;
                case "7":
                    await DeleteCustomer();
                    break;
                case "8":
                    await ViewAllCustomers();
                    break;
                case "9":
                    await AddNewCar();
                    break;
                case "10":
                    await UpdateCar();
                    break;
                case "11":
                    await DeleteCar();
                    break;
                case "12":
                    await ViewAllCars();
                    break;
                case "13":
                    await AddRent();
                    break;
                case "14":
                    await ViewAllRents();
                    break;
                case "15":
                    await AddNewAgentUsingStoredProcedure();
                    break;
                case "16":
                    await ViewAllAgentsUsingStoredProcedure();
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
            Console.WriteLine("Here are the registered agents:");
            var agents = await _agentService.GetAllAgentAsync();

            foreach (var agent in agents)
            {
                Console.WriteLine($"Agent ID: {agent.AgentId}, Name: {agent.Name}");
            }

            Console.WriteLine("Enter the Agent ID you want to update:");
            int agentId = Convert.ToInt32(Console.ReadLine());

            var selectedAgent = await _agentService.GetAgentByIdAsync(agentId);
            if (selectedAgent == null)
            {
                Console.WriteLine("Invalid Agent ID.");
                return;
            }

            Console.WriteLine($"Current Name: {selectedAgent.Name}");

            Console.WriteLine("Enter the new name for the agent:");
            string newName = Console.ReadLine();

            selectedAgent.Name = newName;

            await _agentService.UpdateAgentAsync(selectedAgent);

            Console.WriteLine("Agent updated successfully.");
        }

        private async Task DeleteAgent()
        {
            Console.WriteLine("Here are the registered agents:");
            var agents = await _agentService.GetAllAgentAsync();

            foreach (var agent in agents)
            {
                Console.WriteLine($"Agent ID: {agent.AgentId}, Name: {agent.Name}");
            }

            Console.WriteLine("Enter the Agent ID you want to update:");
            int agentId = Convert.ToInt32(Console.ReadLine());

            var selectedAgent = await _agentService.GetAgentByIdAsync(agentId);
            if (selectedAgent == null)
            {
                Console.WriteLine("Invalid Agent ID.");
                return;
            }

            Console.WriteLine($"Current Name: {selectedAgent.Name}");

            await _agentService.DeleteAgentAsync(selectedAgent);

            Console.WriteLine("Agent Deleted successfully.");
        }

        private async Task ViewAllAgents()
        {
            Console.WriteLine("Here is List of All Agents");
            var GetAllAgents = await _agentService.GetAllAgentAsync();

            foreach (var agent in GetAllAgents)
            {
                Console.WriteLine($"Agent ID: {agent.AgentId}, Name: {agent.Name}");
            }
        }

        private async Task AddNewCustomer()
        {
            Console.WriteLine("Enter Customer Name : ");
            string customerName = Console.ReadLine();

            var customer = new Customer
            {
                CustomerName = customerName
            };

            await _customerService.AddCustomerAsync(customer);
            Console.WriteLine("Customer added successfully.");
        }

        private async Task UpdateCustomer()
        {
            Console.WriteLine("Here are the registered Customer:");
            var customers = await _customerService.GetAllCustomerAsync();

            foreach (var customer in customers)
            {
                Console.WriteLine($"Customer ID: {customer.CustomerId}, Name: {customer.CustomerName}");
            }

            Console.WriteLine("Enter the Customer ID you want to update:");
            int customerId = Convert.ToInt32(Console.ReadLine());

            var selectedCustomer = await _customerService.GetCustomerByIdAsync(customerId);
            if (selectedCustomer == null)
            {
                Console.WriteLine("Invalid Customer ID.");
                return;
            }

            Console.WriteLine($"Current Name: {selectedCustomer.CustomerName}");

            Console.WriteLine("Enter the new name for the Customer:");
            string newName = Console.ReadLine();

            selectedCustomer.CustomerName = newName;

            await _customerService.UpdateCustomerAsync(selectedCustomer);

            Console.WriteLine("Customer updated successfully.");
        }

        private async Task DeleteCustomer()
        {
            Console.WriteLine("Here are the registered customers:");
            var customers = await _customerService.GetAllCustomerAsync();

            foreach (var customer in customers)
            {
                Console.WriteLine($"Customer ID: {customer.CustomerId}, customer Name: {customer.CustomerName}");
            }

            Console.WriteLine("Enter the Customer ID you want to update:");
            int customerId = Convert.ToInt32(Console.ReadLine());

            var selectedCustomer = await _customerService.GetCustomerByIdAsync(customerId);
            if (selectedCustomer == null)
            {
                Console.WriteLine("Invalid Customer ID.");
                return;
            }

            Console.WriteLine($"Current Name: {selectedCustomer.CustomerName}");

            await _customerService.DeleteCustomerAsync(selectedCustomer);

            Console.WriteLine("Customer Deleted successfully.");
        }

        private async Task ViewAllCustomers()
        {
            Console.WriteLine("Here is list of All Customers");
            var GetAllCustomers = await _customerService.GetAllCustomerAsync();

            foreach (var customer in GetAllCustomers)
            {
                Console.WriteLine($"Customer ID: {customer.CustomerId}, Customer Name: {customer.CustomerName}");
            }
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

        private async Task UpdateCar()
        {
            Console.WriteLine("Here are list of car:");
            var cars = await _carService.GetAllCarAsync();

            foreach (var car in cars)
            {
                Console.WriteLine($"Car ID: {car.CarId}, Car Model : {car.CarModel}");
            }

            Console.WriteLine("Enter the Car ID you want to update:");
            int carId = Convert.ToInt32(Console.ReadLine());

            var selectedCar= await _carService.GetCarByIdAsync(carId);
            if (selectedCar == null)
            {
                Console.WriteLine("Invalid Car ID.");
                return;
            }

            Console.WriteLine($"Current Model: {selectedCar.CarModel}");

            Console.WriteLine("Enter the new Model for the Car:");
            string newName = Console.ReadLine();

            selectedCar.CarModel = newName;

            await _carService.UpdateCarAsync(selectedCar);

            Console.WriteLine("Car updated successfully.");
        }

        private async Task DeleteCar()
        {
            Console.WriteLine("Here are list of car:");
            var cars = await _carService.GetAllCarAsync();

            foreach (var car in cars)
            {
                Console.WriteLine($"Car ID: {car.CarId}, Car Model : {car.CarModel}");
            }

            Console.WriteLine("Enter the Car ID you want to delete:");
            int carId = Convert.ToInt32(Console.ReadLine());

            var selectedCar = await _carService.GetCarByIdAsync(carId);
            if (selectedCar == null)
            {
                Console.WriteLine("Invalid Car ID.");
                return;
            }

            Console.WriteLine($"Current Model: {selectedCar.CarModel}");

            await _carService.DeleteCarAsync(selectedCar);

            Console.WriteLine("Car Deleted successfully.");
        }


        private async Task ViewAllCars()
        {
            Console.WriteLine("Here is list of All Cars");
            var GetAllCars = await _carService.GetAllCarAsync();

            foreach (var car in GetAllCars)
            {
                Console.WriteLine($"Car ID: {car.CarId}, Car Model: {car.CarModel}");
            }
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

        private async Task ViewAllRents()
        {
            Console.WriteLine("Here is list of All Rents");
            var GetAllRents = await _rentService.GetAllRentAsync();

            foreach (var rent in GetAllRents)
            {
                Console.WriteLine($"Rent ID: {rent.RentId}, " +
                         $"Car Model: {rent.Car.CarModel}, " +
                         $"Customer Name: {rent.Customer.CustomerName}, " +
                         $"Agent Name: {rent.Agent.Name}, " +
                         $"Rent Date: {rent.RentDate}");
            }
        }

        private async Task AddNewAgentUsingStoredProcedure()
        {
            Console.WriteLine("Enter Agent Name : ");
            string agentName = Console.ReadLine();

            var agent = new Agent
            {
                Name = agentName
            };

            await _agentServiceSP.AddAgentAsync(agent);

            Console.WriteLine("Agent Added Successfully using Stored Procedure! \n");
        }

        private async Task ViewAllAgentsUsingStoredProcedure()
        {
            Console.WriteLine("Here is List of All Agents");
            var GetAllAgents = await _agentService.GetAllAgentAsync();

            foreach (var agent in GetAllAgents)
            {
                Console.WriteLine($"Agent ID: {agent.AgentId}, Name: {agent.Name}");
            }
        }
    }
}
