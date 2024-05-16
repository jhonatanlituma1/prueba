using Microsoft.EntityFrameworkCore;
using WebApiPerson.Model;

namespace WebApiPerson.Context
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options): base(options)
        {
            
        }

        public DbSet<Customer> Persons { get; set; }
    }
}
