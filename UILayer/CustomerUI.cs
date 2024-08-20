using RentSoftware.Core.Entities;
using RentSoftware.Core.Services;
using RentSoftware.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UILayer
{
    public class CustomerUI
    {
        private readonly ICustomerService _customerService;

        public CustomerUI(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task DisplayCustomerMenu()
        {
            Console.WriteLine("Customer Management:");
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Update Customer");
            Console.WriteLine("3. Delete Customer");
            Console.WriteLine("4. View All Customers");
            Console.WriteLine("Select an option:");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await AddNewCustomer();
                    break;
                case "2":
                    // UpdateCustomer logic here
                    break;
                case "3":
                    // DeleteCustomer logic here
                    break;
                case "4":
                    // ViewAllCustomers logic here
                    break;
                case "5":
                   
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        private async Task AddNewCustomer()
        {
            Console.WriteLine("Enter Customer Name : ");
            string Name = Console.ReadLine();

            var customer = new Customer
            {
                CustomerName = Name,
            };

            await _customerService.AddCustomerAsync(customer);
            Console.WriteLine("Customer added successfully.");
        }
    }
}
