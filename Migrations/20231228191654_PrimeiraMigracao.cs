using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bank_api.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionID",
                table: "Transactions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionID",
                table: "Transactions",
                column: "TransactionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Transactions_TransactionID",
                table: "Transactions",
                column: "TransactionID",
                principalTable: "Transactions",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Transactions_TransactionID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_TransactionID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionID",
                table: "Transactions");
        }
    }
}
