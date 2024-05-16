using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPerson.Controllers;
using WebApiPerson.Context;
using WebApiPerson.Model;
using Xunit;

namespace UnitTest
{
    public class CustomerControllerTests
    {
        private readonly DbContextOptions<PersonDbContext> _options;

        public CustomerControllerTests()
        {
            _options = new DbContextOptionsBuilder<PersonDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Fact]
        public async Task GetPersons_ReturnsAllPersons()
        {
            // Arrange
            using (var context = new PersonDbContext(_options))
            {
                context.Persons.Add(new Customer { Id = 1, Name = "John", LastName = "Doe", AccountNumber = "1234567890" });
                context.Persons.Add(new Customer { Id = 2, Name = "Alice", LastName = "Pringle", AccountNumber = "1234567899" });
                context.SaveChanges();
            }

            using (var context = new PersonDbContext(_options))
            {
                var controller = new CustomerController(context);

                // Act
                var result = await controller.GetPersons();

                // Assert
                var okResult = Assert.IsType<ActionResult<IEnumerable<Customer>>>(result);
                var customers = Assert.IsAssignableFrom<IEnumerable<Customer>>(okResult.Value);
                Assert.Equal(2, customers.Count());
            }
        }

        [Fact]
        public async Task GetPerson_ReturnsNotFound_ForInvalidId()
        {
            // Arrange
            using (var context = new PersonDbContext(_options))
            {
                context.Persons.Add(new Customer { Id = 1, Name = "John", LastName = "Doe", AccountNumber = "1234567890" });
                context.SaveChanges();
            }

            using (var context = new PersonDbContext(_options))
            {
                var controller = new CustomerController(context);

                // Act
                var result = await controller.GetPerson(2);

                // Assert
                Assert.IsType<NotFoundResult>(result.Result);
            }
        }

        [Fact]
        public async Task PutPerson_ReturnsBadRequest_ForMismatchedId()
        {
            // Arrange
            using (var context = new PersonDbContext(_options))
            {
                context.Persons.Add(new Customer { Id = 1, Name = "John", LastName = "Doe", AccountNumber = "1234567890" });
                context.SaveChanges();
            }

            using (var context = new PersonDbContext(_options))
            {
                var controller = new CustomerController(context);

                // Act
                var result = await controller.PutPerson(2, new Customer { Id = 3, Name = "Alice", LastName = "Doe", AccountNumber = "1234567890" });

                // Assert
                Assert.IsType<BadRequestResult>(result);
            }
        }

        [Fact]
        public async Task PostPerson_CreatesNewPerson()
        {
            // Arrange
            using (var context = new PersonDbContext(_options))
            {
                var controller = new CustomerController(context);

                // Act
                var result = await controller.PostPerson(new Customer { Id = 1, Name = "John", LastName = "Doe", AccountNumber = "1234567890" });

                // Assert
                var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
                var customer = Assert.IsType<Customer>(createdAtActionResult.Value);
                Assert.Equal("John", customer.Name);
            }
        }

        [Fact]
        public async Task DeletePerson_RemovesExistingPerson()
        {
            // Arrange
            using (var context = new PersonDbContext(_options))
            {
                context.Persons.Add(new Customer { Id = 1, Name = "John", LastName = "Doe", AccountNumber = "1234567890" });
                context.SaveChanges();
            }

            using (var context = new PersonDbContext(_options))
            {
                var controller = new CustomerController(context);

                // Act
                var result = await controller.DeletePerson(1);

                // Assert
                Assert.IsType<NoContentResult>(result);
            }

            using (var context = new PersonDbContext(_options))
            {
                // Assert
                Assert.Empty(context.Persons);
            }
        }

        private async Task<Customer> SeedTestDataAsync(PersonDbContext context)
        {
            var customer = new Customer { Id = 1, Name = "John", LastName = "Doe", AccountNumber = "1234567890" };
            context.Persons.Add(customer);
            await context.SaveChangesAsync();
            return customer;
        }
    }
}
