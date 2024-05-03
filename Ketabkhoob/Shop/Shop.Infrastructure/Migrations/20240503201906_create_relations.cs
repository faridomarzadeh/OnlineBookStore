using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    public partial class create_relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE [Seller].Inventories
                ADD CONSTRAINT FK_Inventories_Products_ProductId
                FOREIGN KEY (ProductId) REFERENCES [Product].Products(Id);
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE [Order].Items
                ADD CONSTRAINT FK_Items_Inventories_InventoryId
                FOREIGN KEY (InventoryId) REFERENCES [Seller].Inventories(Id);
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
