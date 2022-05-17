using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.DBContexts
{
    public class BandAlbumContext : DbContext
    {
        public BandAlbumContext(DbContextOptions<BandAlbumContext> options):
            base(options)
        {

        }
        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Band>().HasData(
                new Band()
                {
                    Id = Guid.Parse("77e0a4a9-0038-4114-8740-cc031f38e222"),
                    Name = "A",
                    Founded = new DateTime(1999, 1, 2),
                    MainGenre = "Disco"
                },
                 new Band()
                 {
                     Id = Guid.NewGuid(),
                     Name = "New",
                     Founded = new DateTime(1999, 1, 2),
                     MainGenre = "Disco"
                 },
                 new Band()
                 {
                     Id = Guid.Parse("efc3f365-1797-4b9e-be9b-aefd7a3f533f"),
                     Name = "B",
                     Founded = new DateTime(1999, 1, 2),
                     MainGenre = "Rock"
                 },
                  new Band()
                  {
                      Id = Guid.Parse("487142e9-5f83-4e65-9ebc-975bb42018a5"),
                      Name = "C",
                      Founded = new DateTime(1999, 1, 2),
                      MainGenre = "Pop"
                  },
                   new Band()
                   {
                       Id = Guid.Parse("adcac28c-703c-4eca-9ef7-9a0c29478c5f"),
                       Name = "D",
                       Founded = new DateTime(1999, 1, 2),
                       MainGenre = "Disco"
                   });
            modelBuilder.Entity<Album>().HasData(
                new Album()
                {
                    Id = Guid.Parse("13936f36-4830-4e71-a83c-212a494b62be"),
                    Title = "New 1",
                    Description = "Description 1",
                    BandId = Guid.Parse("77e0a4a9-0038-4114-8740-cc031f38e222"),
                },
                new Album()
                {
                    Id = Guid.Parse("ca014910-8d1c-4904-b3a0-6870cca54522"),
                    Title = "New 1",
                    Description = "Description 1",
                    BandId = Guid.Parse("efc3f365-1797-4b9e-be9b-aefd7a3f533f"),
                },
                new Album()
                {
                    Id = Guid.Parse("12278022-8c57-4b82-81a1-abe59a5fef92"),
                    Title = "New 1",
                    Description = "Description 1",
                    BandId = Guid.Parse("77e0a4a9-0038-4114-8740-cc031f38e222"),
                });


            base.OnModelCreating(modelBuilder);


        }
    }
}
