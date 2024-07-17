using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessHelper.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnTypeOfQty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "QtyProt",
                table: "Foods",
                type: "decimal(8,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "QtyFat",
                table: "Foods",
                type: "decimal(8,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "QtyCarb",
                table: "Foods",
                type: "decimal(8,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "QtyCal",
                table: "Foods",
                type: "decimal(8,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Qty",
                table: "Foods",
                type: "decimal(8,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,4)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "QtyProt",
                table: "Foods",
                type: "decimal(8,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "QtyFat",
                table: "Foods",
                type: "decimal(8,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "QtyCarb",
                table: "Foods",
                type: "decimal(8,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "QtyCal",
                table: "Foods",
                type: "decimal(8,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Qty",
                table: "Foods",
                type: "decimal(8,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");
        }
    }
}
