using Microsoft.EntityFrameworkCore;
using WebApiPerson.Context;

namespace WebApiPerson.Extensions
{
    public static class MigrationExtension
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using PersonDbContext personDbContext = scope.ServiceProvider.GetRequiredService<PersonDbContext>();

            personDbContext.Database.Migrate();
        }
    }
}
