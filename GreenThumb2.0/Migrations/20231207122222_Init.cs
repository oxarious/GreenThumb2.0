using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GreenThumb2._0.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    PlantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.PlantId);
                });

            migrationBuilder.CreateTable(
                name: "Instructions",
                columns: table => new
                {
                    InstructionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructions", x => x.InstructionId);
                    table.ForeignKey(
                        name: "FK_Instructions_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "PlantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "Name" },
                values: new object[,]
                {
                    { 1, "Ormbunke" },
                    { 2, "Ros" },
                    { 3, "Kaktus" },
                    { 4, "Lavendel" },
                    { 5, "Tulpan" },
                    { 6, "Solros" },
                    { 7, "Orkidé" },
                    { 8, "Körsbärsblom" },
                    { 9, "Lilja" },
                    { 10, "Vitsippa" }
                });

            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "InstructionId", "Instructions", "PlantId" },
                values: new object[,]
                {
                    { 1, "Vattna regelbundet", 1 },
                    { 2, "Undvik direkt solljus", 1 },
                    { 3, "Vattna sparsamt", 2 },
                    { 4, "Placera i soligt fönster", 3 },
                    { 5, "Beskär efter blomning", 4 },
                    { 6, "Skydda från frost", 5 },
                    { 7, "Väldränerad jord rekommenderas", 6 },
                    { 8, "Använd orkidéjord", 7 },
                    { 9, "Skydda från stark vind", 8 },
                    { 10, "Kräver minimalt med vatten", 9 },
                    { 11, "Växer bäst i halvskugga", 10 },
                    { 12, "Gödsla måttligt", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_PlantId",
                table: "Instructions",
                column: "PlantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instructions");

            migrationBuilder.DropTable(
                name: "Plants");
        }
    }
}
