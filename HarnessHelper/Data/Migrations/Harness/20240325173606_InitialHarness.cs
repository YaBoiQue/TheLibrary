using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HarnessHelper.Data.Migrations.Harness
{
    /// <inheritdoc />
    public partial class InitialHarness : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Harness");

            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "colors",
                schema: "Harness",
                columns: table => new
                {
                    colorCode = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, comment: "Solid colors consist of\nBlack = BK\nBrown = BN\nRed = RD\nOrange = OG\nYellow = YE\nGreen = GN\nBlue = BU\nViolent = VT\nGrey = GY\nWhite = WH\nPink = PK\nGold = GD\nTurquoise = TQ\nSilver = SR\nGreen - Yellow = GNYE\n\nFor striped wires use Solid/Stripe", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    solidValue = table.Column<byte[]>(type: "binary(3)", fixedLength: true, maxLength: 3, nullable: true),
                    stripeValue = table.Column<byte[]>(type: "binary(3)", fixedLength: true, maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.colorCode);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "devices",
                schema: "Harness",
                columns: table => new
                {
                    deviceId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numPlugSpots = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    userId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.deviceId);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "wires",
                schema: "Harness",
                columns: table => new
                {
                    wireId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    colorCode = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    gauge = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    userId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.wireId);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "plugs",
                schema: "Harness",
                columns: table => new
                {
                    plugId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    deviceId = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numPinHoles = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    userId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.plugId);
                    table.ForeignKey(
                        name: "plug_device",
                        column: x => x.deviceId,
                        principalSchema: "Harness",
                        principalTable: "devices",
                        principalColumn: "deviceId");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "pins",
                schema: "Harness",
                columns: table => new
                {
                    pinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    plugId = table.Column<int>(type: "int", nullable: false),
                    wireId = table.Column<int>(type: "int", nullable: false),
                    position = table.Column<int>(type: "int", nullable: true),
                    userId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.pinId);
                    table.ForeignKey(
                        name: "pin_plug",
                        column: x => x.plugId,
                        principalSchema: "Harness",
                        principalTable: "plugs",
                        principalColumn: "plugId");
                    table.ForeignKey(
                        name: "pin_wire",
                        column: x => x.wireId,
                        principalSchema: "Harness",
                        principalTable: "wires",
                        principalColumn: "wireId");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "device_user_idx",
                schema: "Harness",
                table: "devices",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "deviceId_UNIQUE",
                schema: "Harness",
                table: "devices",
                column: "deviceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "pin_plug_idx",
                schema: "Harness",
                table: "pins",
                column: "plugId");

            migrationBuilder.CreateIndex(
                name: "pin_wire_idx",
                schema: "Harness",
                table: "pins",
                column: "wireId");

            migrationBuilder.CreateIndex(
                name: "plug_device_idx",
                schema: "Harness",
                table: "plugs",
                column: "deviceId");

            migrationBuilder.CreateIndex(
                name: "plug_user_idx",
                schema: "Harness",
                table: "plugs",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "plugId_UNIQUE",
                schema: "Harness",
                table: "plugs",
                column: "plugId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "wire_user_idx",
                schema: "Harness",
                table: "wires",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "wireId_UNIQUE",
                schema: "Harness",
                table: "wires",
                column: "wireId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "colors",
                schema: "Harness");

            migrationBuilder.DropTable(
                name: "pins",
                schema: "Harness");

            migrationBuilder.DropTable(
                name: "plugs",
                schema: "Harness");

            migrationBuilder.DropTable(
                name: "wires",
                schema: "Harness");

            migrationBuilder.DropTable(
                name: "devices",
                schema: "Harness");
        }
    }
}
