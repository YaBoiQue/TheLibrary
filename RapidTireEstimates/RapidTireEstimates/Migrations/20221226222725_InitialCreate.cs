using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidTireEstimates.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            _ = migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            _ = migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Customer", x => x.Id);
                });

            _ = migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hours = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Service", x => x.Id);
                });

            _ = migrationBuilder.CreateTable(
                name: "ShopSupply",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstimateId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "money", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_ShopSupply", x => x.Id);
                });

            _ = migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_VehicleType", x => x.Id);
                });

            _ = migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    _ = table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    _ = table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    _ = table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "CustomerComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_CustomerComment", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_CustomerComment_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "ServicePrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<short>(type: "smallint", nullable: false),
                    Value = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_ServicePrice", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_ServicePrice_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "ServiceVehicleType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicesId = table.Column<int>(type: "int", nullable: false),
                    VehicleTypesId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_ServiceVehicleType", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_ServiceVehicleType_Service_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_ServiceVehicleType_VehicleType_VehicleTypesId",
                        column: x => x.VehicleTypesId,
                        principalTable: "VehicleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Vehicle", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_Vehicle_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_Vehicle_VehicleType_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "Estimate",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShopTools = table.Column<int>(type: "int", nullable: false),
                    FinalPrice = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Estimate", x => x.VehicleId);
                    _ = table.ForeignKey(
                        name: "FK_Estimate_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_Estimate_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id");
                });

            _ = migrationBuilder.CreateTable(
                name: "EstimateComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstimateId = table.Column<int>(type: "int", nullable: false),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_EstimateComment", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_EstimateComment_Estimate_EstimateId",
                        column: x => x.EstimateId,
                        principalTable: "Estimate",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "EstimateShopSupply",
                columns: table => new
                {
                    EstimatesVehicleId = table.Column<int>(type: "int", nullable: false),
                    ShopPartsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_EstimateShopSupply", x => new { x.EstimatesVehicleId, x.ShopPartsId });
                    _ = table.ForeignKey(
                        name: "FK_EstimateShopSupply_Estimate_EstimatesVehicleId",
                        column: x => x.EstimatesVehicleId,
                        principalTable: "Estimate",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_EstimateShopSupply_ShopSupply_ShopPartsId",
                        column: x => x.ShopPartsId,
                        principalTable: "ShopSupply",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "PurchasedPart",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    EstimateId = table.Column<int>(type: "int", nullable: false),
                    UpsalePercent = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "money", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_PurchasedPart", x => x.VehicleId);
                    _ = table.ForeignKey(
                        name: "FK_PurchasedPart_Estimate_EstimateId",
                        column: x => x.EstimateId,
                        principalTable: "Estimate",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_PurchasedPart_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id");
                });

            _ = migrationBuilder.CreateTable(
                name: "ServiceEstimate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    EstimateId = table.Column<int>(type: "int", nullable: false),
                    AdjustedHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_ServiceEstimate", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_ServiceEstimate_Estimate_EstimateId",
                        column: x => x.EstimateId,
                        principalTable: "Estimate",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_ServiceEstimate_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "ServiceEstimateComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceEstimateId = table.Column<int>(type: "int", nullable: false),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_ServiceEstimateComment", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_ServiceEstimateComment_ServiceEstimate_ServiceEstimateId",
                        column: x => x.ServiceEstimateId,
                        principalTable: "ServiceEstimate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "ServiceEstimatePrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceEstimateId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_ServiceEstimatePrice", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_ServiceEstimatePrice_ServiceEstimate_ServiceEstimateId",
                        column: x => x.ServiceEstimateId,
                        principalTable: "ServiceEstimate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            _ = migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            _ = migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            _ = migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            _ = migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            _ = migrationBuilder.CreateIndex(
                name: "IX_CustomerComment_CustomerId",
                table: "CustomerComment",
                column: "CustomerId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Estimate_CustomerId",
                table: "Estimate",
                column: "CustomerId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_EstimateComment_EstimateId",
                table: "EstimateComment",
                column: "EstimateId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_EstimateShopSupply_ShopPartsId",
                table: "EstimateShopSupply",
                column: "ShopPartsId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_PurchasedPart_EstimateId",
                table: "PurchasedPart",
                column: "EstimateId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_ServiceEstimate_EstimateId",
                table: "ServiceEstimate",
                column: "EstimateId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_ServiceEstimate_ServiceId",
                table: "ServiceEstimate",
                column: "ServiceId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_ServiceEstimateComment_ServiceEstimateId",
                table: "ServiceEstimateComment",
                column: "ServiceEstimateId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_ServiceEstimatePrice_ServiceEstimateId",
                table: "ServiceEstimatePrice",
                column: "ServiceEstimateId",
                unique: true);

            _ = migrationBuilder.CreateIndex(
                name: "IX_ServicePrice_ServiceId",
                table: "ServicePrice",
                column: "ServiceId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_ServiceVehicleType_ServicesId",
                table: "ServiceVehicleType",
                column: "ServicesId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_ServiceVehicleType_VehicleTypesId",
                table: "ServiceVehicleType",
                column: "VehicleTypeIds");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Vehicle_CustomerId",
                table: "Vehicle",
                column: "CustomerId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleTypeId",
                table: "Vehicle",
                column: "VehicleTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            _ = migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            _ = migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            _ = migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            _ = migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            _ = migrationBuilder.DropTable(
                name: "CustomerComment");

            _ = migrationBuilder.DropTable(
                name: "EstimateComment");

            _ = migrationBuilder.DropTable(
                name: "EstimateShopSupply");

            _ = migrationBuilder.DropTable(
                name: "PurchasedPart");

            _ = migrationBuilder.DropTable(
                name: "ServiceEstimateComment");

            _ = migrationBuilder.DropTable(
                name: "ServiceEstimatePrice");

            _ = migrationBuilder.DropTable(
                name: "ServicePrice");

            _ = migrationBuilder.DropTable(
                name: "ServiceVehicleType");

            _ = migrationBuilder.DropTable(
                name: "AspNetRoles");

            _ = migrationBuilder.DropTable(
                name: "AspNetUsers");

            _ = migrationBuilder.DropTable(
                name: "ShopSupply");

            _ = migrationBuilder.DropTable(
                name: "ServiceEstimate");

            _ = migrationBuilder.DropTable(
                name: "Estimate");

            _ = migrationBuilder.DropTable(
                name: "Service");

            _ = migrationBuilder.DropTable(
                name: "Vehicle");

            _ = migrationBuilder.DropTable(
                name: "Customer");

            _ = migrationBuilder.DropTable(
                name: "VehicleType");
        }
    }
}
