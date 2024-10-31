using BookingProject.Domain.Entities;
using BookingProject.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BookingProject.Infrastructure
{
    public static class Seed
    {
        public static void DbInitializer(BookingContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Clients.Any())
            {
                var clients = new List<Client>
                {
                    new Client { Name = "Cliente1", Email  = "cliente3@gmail.com" },
                    new Client { Name = "Cliente2", Email  = "cliente4@gmail.com" },
                    new Client { Name = "Cliente3", Email  = "cliente5@gmail.com" }
                };

                context.Clients.AddRange(clients);
                context.SaveChanges();
            }

            if (!context.Services.Any())
            {
                var services = new List<Service>
                {
                    new Service { ServiceName = "Servicio1", Price = 1000 },
                    new Service { ServiceName = "Servicio2", Price = 300 },
                    new Service { ServiceName = "Servicio3", Price = 450 }
                };

                context.Services.AddRange(services);
                context.SaveChanges();
            }
        }
    }
}
