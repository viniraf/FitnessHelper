using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessHelper.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdInTrainingHistoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TrainingHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingHistory_UserId",
                table: "TrainingHistory",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingHistory_Users_UserId",
                table: "TrainingHistory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingHistory_Users_UserId",
                table: "TrainingHistory");

            migrationBuilder.DropIndex(
                name: "IX_TrainingHistory_UserId",
                table: "TrainingHistory");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TrainingHistory");
        }
    }
}
