using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Museum_Locator.Data.Migrations
{
    /// <inheritdoc />
    public partial class museumfacility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FacilityMuseum",
                columns: table => new
                {
                    FacilitiesFacility_Id = table.Column<int>(type: "int", nullable: false),
                    MuseumsMuseum_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityMuseum", x => new { x.FacilitiesFacility_Id, x.MuseumsMuseum_Id });
                    table.ForeignKey(
                        name: "FK_FacilityMuseum_Facilities_FacilitiesFacility_Id",
                        column: x => x.FacilitiesFacility_Id,
                        principalTable: "Facilities",
                        principalColumn: "Facility_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilityMuseum_Museums_MuseumsMuseum_Id",
                        column: x => x.MuseumsMuseum_Id,
                        principalTable: "Museums",
                        principalColumn: "Museum_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacilityMuseum_MuseumsMuseum_Id",
                table: "FacilityMuseum",
                column: "MuseumsMuseum_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacilityMuseum");
        }
    }
}
