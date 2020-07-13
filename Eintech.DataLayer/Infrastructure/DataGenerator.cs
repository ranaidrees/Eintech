using Eintech.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Eintech.DataLayer.Infrastructure
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EintechDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<EintechDbContext>>()))
            {
                if (context.Persons.Any())
                {
                    return;   // Data was already seeded
                }

                context.Persons.AddRange(
                    new Person
                    {
                        FirstName = "Andrew",
                        LastName = "Armstrong",
                        Created = new DateTime(2020, 06, 11)
                    },
                    new Person
                    {
                        FirstName = "Peter",
                        LastName = "Celver",
                        Created = new DateTime(2020, 06, 10)
                    }); ;

                context.SaveChanges();
            }
        }
    }
}
