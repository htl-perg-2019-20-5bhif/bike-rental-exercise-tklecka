using Microsoft.EntityFrameworkCore.Migrations;

namespace bike_rental_exercise_tklecka.Migrations
{
    public partial class fix01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PriceHour",
                table: "Bikes",
                type: "decimal(1,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceAddHour",
                table: "Bikes",
                type: "decimal(1,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PriceHour",
                table: "Bikes",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(1,2)");

            migrationBuilder.AlterColumn<double>(
                name: "PriceAddHour",
                table: "Bikes",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(1,2)");
        }
    }
}
