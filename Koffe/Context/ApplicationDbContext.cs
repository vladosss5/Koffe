using System;
using System.Collections.Generic;
using Koffe.Entities;
using Microsoft.EntityFrameworkCore;

namespace Koffe.Context;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dish> Dishes { get; set; }

    public virtual DbSet<DishList> DishLists { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Purveyor> Purveyors { get; set; }

    public virtual DbSet<Raw> Raws { get; set; }

    public virtual DbSet<RawOnDish> RawOnDishes { get; set; }

    public virtual DbSet<Supply> Supplies { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Server=localhost;port=5432;user id=postgres;password=toor;database=Koffe;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dish>(entity =>
        {
            entity.HasKey(e => e.IdDish).HasName("dishes_pk");

            entity.ToTable("Dishes", "Koffe");

            entity.Property(e => e.IdDish).UseIdentityAlwaysColumn();
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<DishList>(entity =>
        {
            entity.HasKey(e => e.IdList).HasName("DishList_pk");

            entity.ToTable("DishLists", "Koffe");

            entity.Property(e => e.IdList).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.IdDishNavigation).WithMany(p => p.DishLists)
                .HasForeignKey(d => d.IdDish)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DishList_Dishes_null_fk");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.DishLists)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DishList_Orders_null_fk");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("Orders_pk");

            entity.ToTable("Orders", "Koffe");

            entity.Property(e => e.IdOrder).UseIdentityAlwaysColumn();
            entity.Property(e => e.Date).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Purveyor>(entity =>
        {
            entity.HasKey(e => e.IdPurveyor).HasName("Purveyor_pk");

            entity.ToTable("Purveyors", "Koffe");

            entity.Property(e => e.IdPurveyor).UseIdentityAlwaysColumn();
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(12)
                .IsFixedLength();
        });

        modelBuilder.Entity<Raw>(entity =>
        {
            entity.HasKey(e => e.IdRaw).HasName("Raw_pk");

            entity.ToTable("Raws", "Koffe");

            entity.Property(e => e.IdRaw).UseIdentityAlwaysColumn();
            entity.Property(e => e.Name).HasColumnType("character varying");
        });

        modelBuilder.Entity<RawOnDish>(entity =>
        {
            entity.HasKey(e => e.IdList).HasName("RawOnDishes_pk");

            entity.ToTable("RawOnDishes", "Koffe");

            entity.Property(e => e.IdList).UseIdentityAlwaysColumn();
            entity.Property(e => e.Count).HasColumnName("count");

            entity.HasOne(d => d.IdDishesNavigation).WithMany(p => p.RawOnDishes)
                .HasForeignKey(d => d.IdDishes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RawOnDishes_Dishes_null_fk");

            entity.HasOne(d => d.IdRawNavigation).WithMany(p => p.RawOnDishes)
                .HasForeignKey(d => d.IdRaw)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RawOnDishes_Raw_null_fk");
        });

        modelBuilder.Entity<Supply>(entity =>
        {
            entity.HasKey(e => e.IdRaw).HasName("supply_pk");

            entity.ToTable("supply", "Koffe");

            entity.Property(e => e.IdRaw).ValueGeneratedNever();
            entity.Property(e => e.Date).HasColumnType("timestamp without time zone");
            entity.Property(e => e.IdSupply)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();

            entity.HasOne(d => d.IdPurveyorNavigation).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.IdPurveyor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("supply_Purveyor_null_fk");

            entity.HasOne(d => d.IdRawNavigation).WithOne(p => p.Supply)
                .HasForeignKey<Supply>(d => d.IdRaw)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("supply_Raw_null_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("users_pk");

            entity.ToTable("Users", "Koffe");

            entity.Property(e => e.IdUser).UseIdentityAlwaysColumn();
            entity.Property(e => e.Login).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Password).HasMaxLength(20);
            entity.Property(e => e.Patronymic).HasMaxLength(20);
            entity.Property(e => e.Post).HasMaxLength(20);
            entity.Property(e => e.Surname).HasMaxLength(20);
        });
        modelBuilder.HasSequence("Koffe");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
