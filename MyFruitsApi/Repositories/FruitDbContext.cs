using System.Data.Entity;

namespace FruitInfoApp
{
    public class FruitDbContext : DbContext
    {
        public FruitDbContext() : base("name=FruitDbContext")
        {
        }
        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<FruitMetadata> FruitMetadata { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fruit>()
             .HasMany(f => f.Metadata)
             .WithOne(m => m.Fruit)
             .HasForeignKey(m => m.FruitId);

            modelBuilder.Entity<Fruit>()
                .HasIndex(f => f.Name)
                .IsUnique();

            modelBuilder.Entity<Fruit>().ToTable("Fruits", "fruit_info");
            modelBuilder.Entity<FruiMetadata>().ToTable("NutritionFacts", "fruit_info");
            base.OnModelCreating(modelBuilder);
        }
    }
}