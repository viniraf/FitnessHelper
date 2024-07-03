using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessHelper.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdInWeighingHistoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "WeighingHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WeighingHistory_UserId",
                table: "WeighingHistory",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeighingHistory_Users_UserId",
                table: "WeighingHistory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeighingHistory_Users_UserId",
                table: "WeighingHistory");

            migrationBuilder.DropIndex(
                name: "IX_WeighingHistory_UserId",
                table: "WeighingHistory");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WeighingHistory");
        }
    }
}
