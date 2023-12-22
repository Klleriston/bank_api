using Microsoft.EntityFrameworkCore.Migrations;

public partial class InitialMigration : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new 
            {
                Id = table.Column<int>(nullable: false),
                Name = table.Column<string>(nullable: false),
                Type = table.Column<string>(nullable: false),
                Balance = table.Column<decimal>(nullable: false)
            },
            constraints: table => 
            {
                table.PrimaryKey("PK_Users", x => x.Id);
            }
        );
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Users"
        );
    }
}