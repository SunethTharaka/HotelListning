using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListning2.Data
{
    public class DatabaseContaxt : DbContext
    {
        public DatabaseContaxt(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
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

            builder.Entity<Hotel>().HasData(
               new Hotel
               {
                   Id = 1,
                   Name = "Galle Face Hotel",
                   Address = "2, Galle Road, Kollupitiya, 00100 Colombo, Sri Lanka",
                   CountryId = 1,
                   Rating = 5

               }, new Hotel
               {
                   Id = 2,
                   Name = "Shangri-La",
                   Address = "1 Galle Face, Colombo 02 , 00200 Colombo, Sri Lanka",
                   CountryId = 1,
                   Rating = 5

               }, new Hotel
               {
                   Id = 3,
                   Name = "Marino Beach Colombo",
                   Address = "590 Marine Drive, 00300 Colombo, Sri Lanka ",
                   CountryId = 1,
                   Rating = 5

               }, new Hotel
               {
                   Id = 4,
                   Name = "Hotel Indigo Singapore Katong",
                   Address = "86 East Coast Road, Katong, 428788 Singapore, Singapore",
                   CountryId = 2,
                   Rating = 5

               }, new Hotel
               {
                   Id = 5,
                   Name = "One Farrer Hotel",
                   Address = "1 Farrer Park Station Road, Farrer Park, 217562 Singapore, Singapore",
                   CountryId = 2,
                   Rating = 5

               }, new Hotel
               {
                   Id = 6,
                   Name = "PARKROYAL COLLECTION Pickering",
                   Address = "3 Upper Pickering Street, Chinatown, 058289 Singapore, Singapore",
                   CountryId = 2,
                   Rating = 5

               }, new Hotel
               {
                   Id = 7,
                   Name = "Cordis, Auckland by Langham Hospitality Group",
                   Address = "83 Symonds Street, 1140 Auckland, New Zealand",
                   CountryId = 3,
                   Rating = 5

               }, new Hotel
               {
                   Id = 8,
                   Name = "Hotel Grand Windsor MGallery by Sofitel",
                   Address = "58-60 Queen Street, 1001 Auckland, New Zealand ",
                   CountryId = 3,
                   Rating = 5

               });
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
