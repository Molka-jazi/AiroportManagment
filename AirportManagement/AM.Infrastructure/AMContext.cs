using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AM.Infrastructure
{
    public class AMContext: DbContext
    {

        public  DbSet<Plane> Planes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //lazy loading maaneha kif yebda yaayet el classe may3ayetch lel les jointure maaha na3emlou hathy bich ywali y3ayet lel kol
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
              Initial Catalog=AirportManagementDB;Integrated Security=true;
                MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
//najmou neketbou houni fy oudh ma na3lm plane configuration
          //  modelBuilder.Entity<Plane>().ToTable("MyPlanes");
           // modelBuilder.Entity<Plane>().Property(p => p.Capacity).HasColumnName("PlaneCapacity");
        

        modelBuilder.ApplyConfiguration(new FlightConfiguration());
            //configuer heritage  TPT (table par type)
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("Travellers");
            //configurer la table porteuse de donnée
            modelBuilder.Entity<Ticket>().HasKey(t =>new { t.PassangerFK, t.FlightFK });


            modelBuilder.ApplyConfiguration(new PassengerConfiguration());

    }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
        //    // Pre-convention model configuration goes here
        //    configurationBuilder
        //        .Properties<string>()
        //        .HaveMaxLength(50);
        //configurationBuilder
        //    .Properties<decimal>()
        //        .HavePrecision(8,3);
        //kol ma yal9a date y7othom fy colones esemha date
            configurationBuilder
              .Properties<DateTime>()
                  .HaveColumnType("date");
        }



    }
}
