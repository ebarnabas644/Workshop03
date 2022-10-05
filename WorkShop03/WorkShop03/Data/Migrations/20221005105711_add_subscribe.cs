using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkShop03.Data.Migrations
{
    public partial class add_subscribe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvertisementUser",
                columns: table => new
                {
                    SubscribedId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubscribedUid = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementUser", x => new { x.SubscribedId, x.SubscribedUid });
                    table.ForeignKey(
                        name: "FK_AdvertisementUser_Advertisements_SubscribedUid",
                        column: x => x.SubscribedUid,
                        principalTable: "Advertisements",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertisementUser_AspNetUsers_SubscribedId",
                        column: x => x.SubscribedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementUser_SubscribedUid",
                table: "AdvertisementUser",
                column: "SubscribedUid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertisementUser");
        }
    }
}
