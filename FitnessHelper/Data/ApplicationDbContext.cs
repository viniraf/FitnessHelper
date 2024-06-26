using FitnessHelper.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessHelper.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<UserModel> Users { get; set; }

    public DbSet<TrainingModel> Trainings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>(model =>
        {
            model.ToTable("Users");
            model.HasKey(user => user.Id);
            model.Property(user => user.Id).ValueGeneratedOnAdd();
            model.Property(user => user.Name).IsRequired().HasColumnType("varchar(50)");
            model.Property(user => user.Username).IsRequired().HasColumnType("varchar(50)");
            model.Property(user => user.PasswordHash).IsRequired().HasColumnType("varchar(50)");
        });

        modelBuilder.Entity<TrainingModel>(model => 
        { 
            model.ToTable("Trainings"); 
            model.HasKey(training => training.Id); 
            model.Property(training => training.Id).ValueGeneratedOnAdd(); 
            model.Property(training => training.Title).IsRequired().HasColumnType("varchar(50)"); 
            model.Property(training => training.CreateDate).IsRequired().HasColumnType("datetime"); 
            model.Property(training => training.IsActive).IsRequired().HasColumnType("bit");
        });
    }
}
