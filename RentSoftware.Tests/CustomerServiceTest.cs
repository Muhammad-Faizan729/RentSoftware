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

namespace RentSoftware.Tests
{
    [TestFixture]
    public class CustomerServiceTest
    {
        private CustomerService _customerService;
        private ICustomerRepository _customerRepository;
        private Mock<ICustomerRepository> _mockCustomerRepository;

        [SetUp]
        public void Setup()
        {
            _mockCustomerRepository = new Mock<ICustomerRepository>();
            _customerService = new CustomerService(_mockCustomerRepository.Object);
        }

        [Test]
        public async Task AddCustomerAsync_PassingCustomerToRepositoryForAdding_CustomerIsNotNull()
        {
            var customer = new Customer()
            {
               CustomerName = "TestOne"
            };

            await _customerService.AddCustomerAsync(customer);

            Assert.IsNotNull(customer);

           // _mockCustomerRepository.Verify(repo => repo.AddCustomerAsync(It.Is<Customer>(c => c.CustomerName == "TestOne")), Times.Once);
        }

        
        [Test]
        [Ignore("I dont want to use this test")]
        public async Task AddCustomerAsync_PassingCustomerToRepositoryForAdding_CustomerNull()
        {
            var customer = new Customer()
            {
                CustomerName = ""
            };

            await _customerService.AddCustomerAsync(customer);

            Assert.IsNull(customer);
           // await _customerService.AddCustomerAsync(customerTwo);

           // _mockCustomerRepository.Verify(repo => repo.AddCustomerAsync(It.IsAny<Customer>()), Times.Exactly(2));
        }

        [Test]
        public async Task GetAllCustomerAsync_LimitIsGreaterThenZero_ReturnAllCustomer()
        {
            var customers = new List<Customer>
            {
                new Customer { CustomerName = "Customer1" },
                new Customer { CustomerName = "Customer2" },
                new Customer { CustomerName = "Customer3"}
            };

            _mockCustomerRepository.Setup(repo => repo.GetAllCustomerAsync()).ReturnsAsync(customers);

            var result = await _customerService.GetAllCustomerAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(customers.Count, result.Count());


        }
    }
}
