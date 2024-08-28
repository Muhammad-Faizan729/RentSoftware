using Moq;
using RentSoftware.Core.Entities;
using RentSoftware.Core.Repositories;
using RentSoftware.Core.Services;
using RentSoftware.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UILayer;

namespace RentSoftware.Tests
{
    [TestFixture]
    public class CustomerServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task AddCustomerAsync_whenCalled_SendAgentToRepository()
        {
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var agentService = new CustomerService(mockCustomerRepository.Object);

            var mockCustomer = new Customer()
            {
                CustomerName = "test"
            };

            await agentService.AddCustomerAsync(mockCustomer);

            mockCustomerRepository.Verify(a => a.AddCustomerAsync(It.Is<Customer>(ag => ag.CustomerName == "test")), Times.Once);
        }

        [Test]
        public async Task GetCustomerrByIdAsync_PassedIdOne_ReturnCustomerWithIdOne()
        {
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var customerService = new CustomerService(mockCustomerRepository.Object);

            var Customers = new List<Customer>()
            {
                new Customer() { CustomerId = 1, CustomerName = "FirstCustomer" },
                new Customer() { CustomerId = 2, CustomerName = "SecondCustomer" },
                new Customer() { CustomerId = 3, CustomerName = "ThirdCustomer" }
            };

            mockCustomerRepository.Setup(a => a.GetAllCustomerAsync()).ReturnsAsync(Customers);
            mockCustomerRepository.Setup(a => a.GetCustomerByIdAsync(1)).ReturnsAsync(Customers.First(a => a.CustomerId == 1));

            var result = await customerService.GetCustomerByIdAsync(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.CustomerId, Is.EqualTo(1));
            Assert.That(result.CustomerName, Is.EqualTo("FirstCustomer"));
        }

        [Test]
        public async Task GetTaskAsync_whenCalled_ReturnAllCustomers()
        {
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var customerService = new CustomerService(mockCustomerRepository.Object);

            var Customers = new List<Customer>()
            {
                new Customer() { CustomerId = 1, CustomerName = "FirstCustomer" },
                new Customer() { CustomerId = 2, CustomerName = "SecondCustomer" },
                new Customer() { CustomerId = 3, CustomerName = "ThirdCustomer" }
            };

            mockCustomerRepository.Setup(a => a.GetAllCustomerAsync()).ReturnsAsync(Customers);

            var result = await customerService.GetAllCustomerAsync();

            mockCustomerRepository.Verify(a => a.GetAllCustomerAsync(), Times.Once);

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task DeleteCustomerAsync_WhenCalledOrPassCustomerToDelete_RemovedCustomer()
        {
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var customerService = new CustomerService(mockCustomerRepository.Object);

            var RemovedCustomer = new Customer()
            {
                CustomerName = "test"
            };

            await customerService.DeleteCustomerAsync(RemovedCustomer);

            mockCustomerRepository.Verify(a => a.DeleteCustomerAsync(RemovedCustomer), Times.Once);
        }
    }
}
