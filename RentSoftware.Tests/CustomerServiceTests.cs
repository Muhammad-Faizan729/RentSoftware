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
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;
        private readonly CustomerService _customerService;

        public CustomerServiceTests()
        {
            _mockCustomerRepository = new Mock<ICustomerRepository>();
            _customerService = new CustomerService(_mockCustomerRepository.Object);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task AddCustomerAsync_Should_Add_customer()
        {
            //Arrange
            var _mockCustomerRepository = new Mock<ICustomerRepository>();
            var _customerService = new CustomerService(_mockCustomerRepository.Object);

            var mockCustomer = new Customer()
            {
                CustomerName = "fake-customer"
            };

            //Act
            await _customerService.AddCustomerAsync(mockCustomer);

            //Assert
            _mockCustomerRepository.Verify(a => a.AddCustomerAsync(It.Is<Customer>(ag => ag.CustomerName == "fake-customer")), Times.Once);
        }

        [Test]
        public async Task GetCustomerrByIdAsync_should_return_customer()
        {
            //Arrange
            var Customers = new List<Customer>()
            {
                new Customer() { CustomerId = 1, CustomerName = "fake-first-customer" },
                new Customer() { CustomerId = 2, CustomerName = "fake-second-customer" },
                new Customer() { CustomerId = 3, CustomerName = "fake-third-customer" }
            };

            _mockCustomerRepository.Setup(a => a.GetAllCustomerAsync()).ReturnsAsync(Customers);
            _mockCustomerRepository.Setup(a => a.GetCustomerByIdAsync(1)).ReturnsAsync(Customers.First(a => a.CustomerId == 1));

            //Act
            var result = await _customerService.GetCustomerByIdAsync(1);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.CustomerId, Is.EqualTo(1));
            Assert.That(result.CustomerName, Is.EqualTo("fake-first-customer"));
        }

        [Test]
        public async Task GetTaskAsync_should_return_customers()
        {
            //Arrange
            var Customers = new List<Customer>()
            {
                new Customer() { CustomerId = 1, CustomerName = "fake-first-customer" },
                new Customer() { CustomerId = 2, CustomerName = "fake-second-customer" },
                new Customer() { CustomerId = 3, CustomerName = "fake-third-customer" }
            };

            _mockCustomerRepository.Setup(a => a.GetAllCustomerAsync()).ReturnsAsync(Customers);

            //Act
            var result = await _customerService.GetAllCustomerAsync();

            _mockCustomerRepository.Verify(a => a.GetAllCustomerAsync(), Times.Once);

            //Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task DeleteCustomerAsync_should_delete_customer()
        {
            //Arrange
            var RemovedCustomer = new Customer()
            {
                CustomerName = "test"
            };

            //Act
            await _customerService.DeleteCustomerAsync(RemovedCustomer);

            //Assert
            _mockCustomerRepository.Verify(a => a.DeleteCustomerAsync(RemovedCustomer), Times.Once);
        }
    }
}
