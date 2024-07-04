﻿// <auto-generated />
using System;
using FitnessHelper.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitnessHelper.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FitnessHelper.Models.ExerciseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ExerciseTitle")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("QtyReps")
                        .HasColumnType("int");

                    b.Property<int>("QtySets")
                        .HasColumnType("int");

                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrainingId");

                    b.HasIndex("UserId");

                    b.ToTable("Exercises", (string)null);
                });

            modelBuilder.Entity("FitnessHelper.Models.TrainingHistoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrainingId");

                    b.HasIndex("UserId");

                    b.ToTable("TrainingHistories", (string)null);
                });

            modelBuilder.Entity("FitnessHelper.Models.TrainingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("CreateDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("TrainingTitle")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Trainings", (string)null);
                });

            modelBuilder.Entity("FitnessHelper.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("FitnessHelper.Models.WeighingHistoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(4,2)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WeighingHistories", (string)null);
                });

            modelBuilder.Entity("FitnessHelper.Models.ExerciseModel", b =>
                {
                    b.HasOne("FitnessHelper.Models.TrainingModel", "Training")
                        .WithMany("Exercises")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessHelper.Models.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Training");
                });

            modelBuilder.Entity("FitnessHelper.Models.TrainingHistoryModel", b =>
                {
                    b.HasOne("FitnessHelper.Models.TrainingModel", "Training")
                        .WithMany("TrainingHistories")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessHelper.Models.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Training");
                });

            modelBuilder.Entity("FitnessHelper.Models.TrainingModel", b =>
                {
                    b.HasOne("FitnessHelper.Models.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FitnessHelper.Models.WeighingHistoryModel", b =>
                {
                    b.HasOne("FitnessHelper.Models.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FitnessHelper.Models.TrainingModel", b =>
                {
                    b.Navigation("Exercises");

                    b.Navigation("TrainingHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
