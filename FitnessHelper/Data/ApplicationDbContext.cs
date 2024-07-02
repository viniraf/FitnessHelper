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

    public DbSet<ExerciseModel> Exercises { get; set; }

    public DbSet<TrainingHistoryModel> TrainingHistories { get; set; }

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

        modelBuilder.Entity<ExerciseModel>(model => 
        {
            model.ToTable("Exercises");
            model.HasKey(exercise =>  exercise.Id);
            model.Property(exercise => exercise.Id).ValueGeneratedOnAdd();
            model.Property(exercise => exercise.Exercise).IsRequired().HasColumnType("varchar(50)");
            model.Property(exercise => exercise.QtySets).IsRequired().HasColumnType("int");
            model.Property(exercise => exercise.QtyReps).IsRequired().HasColumnType("int");
            model.Property(exercise => exercise.IsActive).IsRequired().HasColumnType("bit");

            // Defines the relationship with the "Trainings" table
            model.HasOne(exercise => exercise.Training)
                .WithMany(training => training.Exercises) // Indicates that a training can have multiple exercises
                .HasForeignKey(exercise => exercise.TrainingId); // Foreign Key for TrainingId
        });

        modelBuilder.Entity<TrainingHistoryModel>(model =>
        {
            model.ToTable("TrainingHistory");
            model.HasKey(trainingHistory =>  trainingHistory.Id);
            model.Property(trainingHistory => trainingHistory.Date).IsRequired();

            model.HasOne(trainingHistory => trainingHistory.Training)
                .WithMany(training => training.TrainingHistories)
                .HasForeignKey(trainingHistory => trainingHistory.TrainingId);
        });

        modelBuilder.Entity<WeighingHistoryModel>(model =>
        {
            model.ToTable("WeighingHistory");
            model.HasKey(weighingHistory =>  weighingHistory.Id);
            model.Property(weighingHistory => weighingHistory.Date).IsRequired();
            model.Property(weighingHistory => weighingHistory.Weight).IsRequired().HasColumnType("decimal(4,2)");
        });
    }
}
