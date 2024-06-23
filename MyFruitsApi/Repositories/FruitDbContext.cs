using System.Data.Entity;

namespace FruitInfoApp
{
    public class FruitDbContext : DbContext
    {
        public FruitDbContext(DbContextOptions<FruitDbContext> options)
            : base(options)
        {
        }
        public DbSet<Fruit> Fruits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fruit>()
             .HasMany(f => f.NutritionFacts)
             .WithOne(nf => nf.Fruit)
             .HasForeignKey(nf => nf.FruitId);

            modelBuilder.Entity<Fruit>()
                .HasIndex(f => f.Name)
                .IsUnique();

            modelBuilder.Entity<Fruit>().ToTable("Fruits", "fruit_info");
            modelBuilder.Entity<NutritionFact>().ToTable("NutritionFacts", "fruit_info");
            base.OnModelCreating(modelBuilder);
        }
    }
}