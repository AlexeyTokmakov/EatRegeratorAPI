using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
    public virtual DbSet<Dishes> Dishes { get; set; }
    public virtual DbSet<Product2Dishs> Product2Dishs { get; set; }
    public virtual DbSet<Products> Products { get; set; }
    public virtual DbSet<Recipes> Recipes { get; set; }
    public virtual DbSet<TypeDishes> TypeDishes { get; set; }
    public virtual DbSet<TypeKitchen> TypeKitchen { get; set; }
    public virtual DbSet<TypeMenu> TypeMenu { get; set; }

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
      modelBuilder.Entity<Dishes>(entity =>
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

        entity.Property(e => e.TypeKitchenGuid).HasColumnName("typeKitchenGUID");

        entity.Property(e => e.TypeMenuGuid).HasColumnName("typeMenuGUID");

        entity.HasOne(d => d.TypeGu)
                  .WithMany(p => p.Dishes)
                  .HasForeignKey(d => d.TypeGuid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK__Dishes__typeGUID__300424B4");

        entity.HasOne(d => d.TypeKitchenGu)
                  .WithMany(p => p.Dishes)
                  .HasForeignKey(d => d.TypeKitchenGuid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK__Dishes__typeKitc__38996AB5");

        entity.HasOne(d => d.TypeMenuGu)
                  .WithMany(p => p.Dishes)
                  .HasForeignKey(d => d.TypeMenuGuid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK__Dishes__typeMenu__398D8EEE");
      });

      modelBuilder.Entity<Product2Dishs>(entity =>
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

      modelBuilder.Entity<Products>(entity =>
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

      modelBuilder.Entity<Recipes>(entity =>
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

        entity.HasOne(d => d.DishGu)
                  .WithMany(p => p.Recipes)
                  .HasForeignKey(d => d.DishGuid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK__Recipes__dishGUI__2C3393D0");
      });

      modelBuilder.Entity<TypeDishes>(entity =>
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

      modelBuilder.Entity<TypeKitchen>(entity =>
      {
        entity.HasKey(e => e.KitchenTypeGuid);

        entity.Property(e => e.KitchenTypeGuid)
                  .HasColumnName("kitchenTypeGUID")
                  .ValueGeneratedNever();

        entity.Property(e => e.Code).HasColumnName("code");

        entity.Property(e => e.Title)
                  .IsRequired()
                  .HasColumnName("title")
                  .HasMaxLength(50);
      });

      modelBuilder.Entity<TypeMenu>(entity =>
      {
        entity.HasKey(e => e.TypeMenuGuid);

        entity.Property(e => e.TypeMenuGuid)
                  .HasColumnName("typeMenuGUID")
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
