using BarberShop.DAL.Entities;
using BarberShop.DAL.Extensions;
using Microsoft.EntityFrameworkCore;


namespace BarberShop.DAL.Persistence;

public class BarberShopDbContext : DbContext
{
    public BarberShopDbContext()
    {
    }

    public BarberShopDbContext(DbContextOptions<BarberShopDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Barber> Barbers { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasOne(c => c.Image)
            .WithMany(ci => ci.CategoryImages)
            .HasForeignKey(c => c.ImageId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasOne(i => i.Image)
            .WithMany(c => c.ServiceImages)
            .HasForeignKey(i => i.ImageId)
            .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(i => i.Category)
            .WithMany(c => c.CategoryServices)
            .HasForeignKey(i => i.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Barber>()
           .HasOne(c => c.Image)
           .WithMany(bi => bi.BarberImages)
           .HasForeignKey(c => c.ImageId)
           .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasOne(i => i.Image)
            .WithMany(c => c.ServiceImages)
            .HasForeignKey(i => i.ImageId)
            .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(i => i.Category)
            .WithMany(c => c.CategoryServices)
            .HasForeignKey(i => i.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Order>(entity =>
        {

            entity.HasOne(o => o.Service)
            .WithMany(s => s.ServiceOrder)
            .HasForeignKey(o => o.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(i => i.Barber)
            .WithMany(c => c.OrederBarber)
            .HasForeignKey(i => i.BarberId)
            .OnDelete(DeleteBehavior.Cascade);


            entity.HasOne(i => i.User)
            .WithMany(c => c.UserOrder)
            .HasForeignKey(i => i.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.SeedData();
    }
}
