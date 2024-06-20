using FitnessHelper.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessHelper.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<UserModel> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>(model =>
        {
            model.ToTable("Users");
            model.HasKey(user => user.Id);
            model.Property(user => user.Id).ValueGeneratedOnAdd();
            model.Property(user => user.Name).IsRequired().HasMaxLength(50);
            model.Property(user => user.Username).IsRequired().HasMaxLength(50);
            model.Property(user => user.PasswordHash).IsRequired().HasMaxLength(50);
        });
    }
}
