using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {  //type detenu par la classe passanger maaneha mouch bich ya3emlelha classe wahadha fel base
            builder.OwnsOne(p => p.FullName //full name type apparteuient lel passanger
            , fullName => //configuration mta3 el prop full namr
            {
                fullName.Property(f => f.FirstName).HasColumnName("PassFirstName").HasMaxLength(30);
                fullName.Property(f => f.LastName).HasColumnName("PassLastName").IsRequired();
            });

            //Configurer l'heritage Table par hiearchy (
        /*    builder.HasDiscriminator<int>("IsTraveller") //discriminateur colone par default fel base de donnée te5dem kima el role najmou na3emlouha configuration aala haseb howa ma yheb
                .HasValue<Passenger>(0)
                .HasValue<Traveller>(1)
                .HasValue<Staff>(2); */

        }
    }
}
