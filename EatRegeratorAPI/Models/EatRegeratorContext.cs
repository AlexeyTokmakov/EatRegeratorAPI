using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace EatRegeratorAPI
{
  public partial class EatRegeratorContext : DbContext
  {
    public EatRegeratorContext()
    {
    }

    public EatRegeratorContext(DbContextOptions<EatRegeratorContext> options)
        : base(options)
    {
    }

    private static string ConnectionString { get; set; }
    public virtual DbSet<Dish> Dishes { get; set; }
    public virtual DbSet<Product2Dish> Product2Dishs { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Recipe> Recipes { get; set; }
    public virtual DbSet<TypeDish> TypeDishes { get; set; }



    public static void SetConnectionString(string connectionString)
    {
      if (connectionString == null) throw new ArgumentException();
      ConnectionString = connectionString;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseSqlServer(ConnectionString);
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Dish>(entity =>
      {
        entity.HasKey(e => e.DishGuid);

        entity.Property(e => e.DishGuid)
                  .HasColumnName("dishGUID")
                  .ValueGeneratedNever();

        entity.Property(e => e.CookingTime).HasColumnName("cookingTime");

        entity.Property(e => e.Title)
                  .IsRequired()
                  .HasColumnName("title")
                  .HasMaxLength(50);

        entity.Property(e => e.TypeGuid).HasColumnName("typeGUID");

        entity.HasOne(d => d.Type)
                  .WithMany(p => p.Dishes)
                  .HasForeignKey(d => d.TypeGuid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK__Dishes__typeGUID__300424B4");
      });

      modelBuilder.Entity<Product2Dish>(entity =>
      {
        entity.HasNoKey();

        entity.Property(e => e.DishGuid).HasColumnName("dishGUID");

        entity.Property(e => e.ProductGuid).HasColumnName("productGUID");

        entity.HasOne(d => d.DishGu)
                  .WithMany()
                  .HasForeignKey(d => d.DishGuid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK__Product2D__dishG__2B3F6F97");

        entity.HasOne(d => d.ProductGu)
                  .WithMany()
                  .HasForeignKey(d => d.ProductGuid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK__Product2D__produ__2A4B4B5E");
      });

      modelBuilder.Entity<Product>(entity =>
      {
        entity.HasKey(e => e.ProductGuid);

        entity.Property(e => e.ProductGuid)
                  .HasColumnName("productGUID")
                  .ValueGeneratedNever();

        entity.Property(e => e.Name)
                  .IsRequired()
                  .HasColumnName("name")
                  .HasMaxLength(100);
      });

      modelBuilder.Entity<Recipe>(entity =>
      {
        entity.HasKey(e => e.RecipeGuid);

        entity.Property(e => e.RecipeGuid)
                  .HasColumnName("recipeGUID")
                  .ValueGeneratedNever();

        entity.Property(e => e.DishGuid).HasColumnName("dishGUID");

        entity.Property(e => e.Order).HasColumnName("order");

        entity.Property(e => e.PictureUrl)
                  .HasColumnName("pictureURL")
                  .HasMaxLength(50);

        entity.Property(e => e.Text).HasColumnName("text");

        entity.Property(e => e.Title)
                  .HasColumnName("title")
                  .HasMaxLength(50);

        entity.HasOne(d => d.Dish)
                  .WithMany(p => p.Recipes)
                  .HasForeignKey(d => d.DishGuid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK__Recipes__dishGUI__2C3393D0");
      });

      modelBuilder.Entity<TypeDish>(entity =>
      {
        entity.HasKey(e => e.TypeGuid);

        entity.Property(e => e.TypeGuid)
                  .HasColumnName("typeGUID")
                  .ValueGeneratedNever();

        entity.Property(e => e.Code).HasColumnName("code");

        entity.Property(e => e.Title)
                  .IsRequired()
                  .HasColumnName("title")
                  .HasMaxLength(50);
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
