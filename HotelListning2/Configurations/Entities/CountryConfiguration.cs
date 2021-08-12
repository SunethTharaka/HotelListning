using HotelListning2.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListning2.Configurations.Entities
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                  new Country
                  {
                      Id = 1,
                      Name = "Sri Lanka",
                      ShortName = "SL"
                  }, new Country
                  {
                      Id = 2,
                      Name = "Singapore",
                      ShortName = "SI"

                  }, new Country
                  {
                      Id = 3,
                      Name = "New Zealand",
                      ShortName = "NZ"
                  });
        }
    }
}
