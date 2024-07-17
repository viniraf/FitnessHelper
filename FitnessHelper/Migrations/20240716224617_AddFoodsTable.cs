using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessHelper.Migrations
{
    /// <inheritdoc />
    public partial class AddFoodsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    UnitOfMeasurement = table.Column<string>(type: "varchar(25)", nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(8,4)", nullable: false),
                    QtyProt = table.Column<decimal>(type: "decimal(8,4)", nullable: false),
                    QtyCarb = table.Column<decimal>(type: "decimal(8,4)", nullable: false),
                    QtyFat = table.Column<decimal>(type: "decimal(8,4)", nullable: false),
                    QtyCal = table.Column<decimal>(type: "decimal(8,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods");
        }
    }
}
