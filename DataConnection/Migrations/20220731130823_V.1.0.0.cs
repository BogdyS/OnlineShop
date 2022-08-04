using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataConnection.Migrations
{
    public partial class V100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Orders_Status_Enum",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "Products",
                newName: "Price");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Orders_Status_Enum",
                table: "Orders",
                sql: "[Status] IN (0, 1, 2, 3, 4, 5)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Orders_Status_Enum",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "Cost");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Orders_Status_Enum",
                table: "Orders",
                sql: "[Status] IN (0, 1, 2, 3, 4)");
        }
    }
}
