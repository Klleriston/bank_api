using System.Reflection.Metadata;
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
            FirstName = table.Column<string>(nullable: false),
            LastName = table.Column<string>(nullable: false),
            Type = table.Column<string>(nullable: false),
            Document = table.Column<string>(nullable:false),
            Email = table.Column<string>(nullable:false),
            Password = table.Column<string>(nullable:false),
            Balance = table.Column<decimal>(nullable: false)
        },
        constraints: table => 
        {
            table.PrimaryKey("PK_Users", x => x.Id);
            table.UniqueConstraint("UKey_Document", x => x.Document);
            table.UniqueConstraint("UKey_Email", x => x.Email);
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