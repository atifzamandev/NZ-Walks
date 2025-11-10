using Microsoft.EntityFrameworkCore;
using NZ_Walks.API.Models.Domain;

namespace NZ_Walks.API.Data
    {
    public class NZWalksDbContext:DbContext
        {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions)
            {

            }


        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            base.OnModelCreating(modelBuilder);

            var difficulty = new List<Difficulty>() {
                new Difficulty()
                {
                    Id= Guid.Parse("1bfe5a7a-dc63-4862-95c2-29840d347d29") ,
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id= Guid.Parse("800a1ada-b582-4616-ba9d-473c9dd1b3bc"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id= Guid.Parse("88b0109f-6c7e-4a4a-ad29-d7df9109073a"),
                    Name = "Heigh"
                },
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulty);

            var regions = new List<Region>() {


               new Region()
                {
                    Id= Guid.Parse( "10064c86-6d6f-466a-854b-0ed8ae8bf928"),
                    Code= "NZ-C",
                    Name= "Canterbury",
                    RegionImageUrl= "https://picsum.photos/id/22/2500/1667"
                  },
        new Region()
        {
        Id= Guid.Parse( "6f6a4160-46dd-41f9-919c-1be39412b321"),
    Code= "NZ-WC",
    Name= "West Coast",
    RegionImageUrl= "https://picsum.photos/id/21/2500/1667"
  },
        new Region()
        {
        Id=Guid.Parse( "d8c8f4cf-6964-4d4b-a6a7-1c1cbecb3e79"),
    Code= "NZ-O",
    Name= "Otago",
    RegionImageUrl= "https://picsum.photos/id/23/2500/1667"
  },
        new Region()
        {
        Id= Guid.Parse("cb6b437f-e406-4fc1-b841-1c3769af8ebc"),
    Code= "NZ-WG",
    Name= "Wellington",
    RegionImageUrl= "https://picsum.photos/id/18/2500/1667"
  },
        new Region()
        {
        Id= Guid.Parse("091e60bd-844f-47e6-a675-2ba12248a4d4"),
    Code= "NZ-MB",
    Name= "Marlborough",
    RegionImageUrl= "https://picsum.photos/id/20/2500/1667"
  },
        new Region()
        {
        Id=Guid.Parse( "86b70ec5-540e-4479-826f-4eac1ef41a62"),
    Code= "NZ-A",
    Name= "Auckland",
    RegionImageUrl= "https://picsum.photos/id/11/2500/1667"
  },
        new Region()
        {
        Id=Guid.Parse( "3390fc2c-2bc1-40ce-9ec8-755338ee1d4c"),
    Code= "NZ-NS",
    Name= "Nelson",
    RegionImageUrl= "https://picsum.photos/id/19/2500/1667"
  },
        new Region()
        {
        Id= Guid.Parse("5494c18a-1fbf-40e2-82d6-87c7af6d0460"),
    Code= "NZ-W",
    Name= "Waikato",
    RegionImageUrl= "https://picsum.photos/id/12/2500/1667"
  },
        new Region()
        {
        Id= Guid.Parse("62e4c92c-4482-4b3e-ab4b-a2394b69509f"),
    Code= "NZ-M",
    Name= "Manawatu-Wanganui",
    RegionImageUrl= "https://picsum.photos/id/17/2500/1667"
  },
        new Region()
        {
        Id= Guid.Parse("3497b1cc-d0d7-4f09-a57e-a55cf30166b9"),
    Code= "NZ-T",
    Name= "Taranaki",
    RegionImageUrl= "https://picsum.photos/id/16/2500/1667"
  },
        new Region()
        {
        Id= Guid.Parse("f4c674b6-be9f-4d3c-a2c0-b10465d5a470"),
    Code= "NZ-B",
    Name= "Bay of Plenty",
    RegionImageUrl= "https://picsum.photos/id/13/2500/1667"
  },
        new Region()
        {
        Id= Guid.Parse("a552f961-2409-4ef5-8851-d9abcd26e289"),
    Code= "NZ-S",
    Name= "Southland",
    RegionImageUrl= "https://picsum.photos/id/24/2500/1667"
  },
        new Region()
        {
        Id= Guid.Parse("c0b7f81a-d615-470d-998e-dbc4541a9faa"),
    Code= "NZ-G",
    Name= "Gisborne",
    RegionImageUrl= "https://picsum.photos/id/14/2500/1667"
  },
        new Region()
        {
        Id= Guid.Parse("4b2b2bf3-ed64-471b-940e-e70df2693cca"),
    Code= "NZ-N",
    Name= "Northland",
    RegionImageUrl= "https://picsum.photos/id/10/2500/1667"
  },
        new Region()
        {
        Id= Guid.Parse("f28646ca-9331-40cf-a525-fe2abe7c6829"),
        Code= "NZ-H",
        Name= "Hawke's Bay",
        RegionImageUrl= "https://picsum.photos/id/15/2500/1667"
  }

    };

            modelBuilder.Entity<Region>().HasData(regions);


            }

        }
    }
