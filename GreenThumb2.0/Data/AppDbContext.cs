using GreenThumb2._0.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumb2._0.Data
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public DbSet<PlantModel> Plants { get; set; }
        public DbSet<InstructionModel> Instructions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GreenThumpDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Adding plants
            modelBuilder.Entity<PlantModel>().HasData(
                new PlantModel { PlantId = 1, Name = "Ormbunke" },
                new PlantModel { PlantId = 2, Name = "Ros" },
                new PlantModel { PlantId = 3, Name = "Kaktus" },
                new PlantModel { PlantId = 4, Name = "Lavendel" },
                new PlantModel { PlantId = 5, Name = "Tulpan" },
                new PlantModel { PlantId = 6, Name = "Solros" },
                new PlantModel { PlantId = 7, Name = "Orkidé" },
                new PlantModel { PlantId = 8, Name = "Körsbärsblom" },
                new PlantModel { PlantId = 9, Name = "Lilja" },
                new PlantModel { PlantId = 10, Name = "Vitsippa" }
            );

            // Adding instructions
            modelBuilder.Entity<InstructionModel>().HasData(
                new InstructionModel { InstructionId = 1, Instructions = "Vattna regelbundet", PlantId = 1 },
                new InstructionModel { InstructionId = 2, Instructions = "Undvik direkt solljus", PlantId = 1 },
                new InstructionModel { InstructionId = 3, Instructions = "Vattna sparsamt", PlantId = 2 },
                new InstructionModel { InstructionId = 4, Instructions = "Placera i soligt fönster", PlantId = 3 },
                new InstructionModel { InstructionId = 5, Instructions = "Beskär efter blomning", PlantId = 4 },
                new InstructionModel { InstructionId = 6, Instructions = "Skydda från frost", PlantId = 5 },
                new InstructionModel { InstructionId = 7, Instructions = "Väldränerad jord rekommenderas", PlantId = 6 },
                new InstructionModel { InstructionId = 8, Instructions = "Använd orkidéjord", PlantId = 7 },
                new InstructionModel { InstructionId = 9, Instructions = "Skydda från stark vind", PlantId = 8 },
                new InstructionModel { InstructionId = 10, Instructions = "Kräver minimalt med vatten", PlantId = 9 },
                new InstructionModel { InstructionId = 11, Instructions = "Växer bäst i halvskugga", PlantId = 10 },
                new InstructionModel { InstructionId = 12, Instructions = "Gödsla måttligt", PlantId = 3 }
            );
        }

    }
}
