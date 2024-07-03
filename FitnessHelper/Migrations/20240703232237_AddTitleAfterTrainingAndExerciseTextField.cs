using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessHelper.Migrations
{
    /// <inheritdoc />
    public partial class AddTitleAfterTrainingAndExerciseTextField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Trainings",
                newName: "TrainingTitle");

            migrationBuilder.RenameColumn(
                name: "Exercise",
                table: "Exercises",
                newName: "ExerciseTitle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrainingTitle",
                table: "Trainings",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "ExerciseTitle",
                table: "Exercises",
                newName: "Exercise");
        }
    }
}
