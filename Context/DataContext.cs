using InstrumentsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InstrumentsApp.Context {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<ItemEntry> ItemEntry { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Instrument>().HasData(
                new Instrument {
                    Id = 1,
                    Name = "Piano",
                    Price = 1500.00m,
                    ImagePath = "images/piano.jpg",
                    Stock = 15
                },
                new Instrument {
                    Id = 2,
                    Name = "Guitar",
                    Price = 500.00m,
                    ImagePath = "images/guitar.jpg",
                    Stock = 20
                },
                new Instrument {
                    Id = 3,
                    Name = "Violin",
                    Price = 800.00m,
                    ImagePath = "images/violin.jpg",
                    Stock = 7
                },
                new Instrument {
                    Id = 4,
                    Name = "Drums",
                    Price = 1200.00m,
                    ImagePath = "images/drums.jpg",
                    Stock = 5
                },
                new Instrument {
                    Id = 5,
                    Name = "Electric Guitar",
                    Price = 1000.00m,
                    ImagePath = "images/electricGuitar.jpg",
                    Stock = 7
                },
                new Instrument {
                    Id = 6,
                    Name = "Bass Guitar",
                    Price = 900.00m,
                    ImagePath = "images/bassGuitar.jpg",
                    Stock = 10
                },
                new Instrument {
                    Id = 7,
                    Name = "Keyboard",
                    Price = 950.00m,
                    ImagePath = "images/keyboard.jpg",
                    Stock = 25
                },
                new Instrument {
                    Id = 8,
                    Name = "Accordion",
                    Price = 600.00m,
                    ImagePath = "images/accordion.jpg",
                    Stock = 77
                }
            );
        }
    }
}