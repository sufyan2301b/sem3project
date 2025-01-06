using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TARS_Delivery_System.Migrations
{
    /// <inheritdoc />
    public partial class IdentityMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
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
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Branch_Tbl",
            //    columns: table => new
            //    {
            //        Branch_id = table.Column<int>(type: "int", nullable: false),
            //        Branch_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            //        Location = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
            //        Contact_number = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
            //        Pin_Code = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Branch_Tbl", x => x.Branch_id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Service_Charges_Tbl",
            //    columns: table => new
            //    {
            //        Service_charge_id = table.Column<int>(type: "int", nullable: false),
            //        Service_type = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        Base_charge = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
            //        Weight_factor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
            //        Distance_factor = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Service_Charges_Tbl", x => x.Service_charge_id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "User_Tbl",
            //    columns: table => new
            //    {
            //        User_Id = table.Column<int>(type: "int", nullable: false),
            //        User_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        User_email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        Password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            //        Role = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        Contact_number = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_User_Tbl", x => x.User_Id);
            //    });

            migrationBuilder.CreateTable(
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
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
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
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "Deliverables_Tbl",
            //    columns: table => new
            //    {
            //        Deliverable_id = table.Column<int>(type: "int", nullable: false),
            //        User_id = table.Column<int>(type: "int", nullable: false),
            //        Branch_id = table.Column<int>(type: "int", nullable: false),
            //        Delivery_type = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        Weight = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
            //        Status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
            //        Delivery_date = table.Column<DateTime>(type: "datetime", nullable: false),
            //        Send_date = table.Column<DateTime>(type: "datetime", nullable: false),
            //        Payment_status = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
            //        charge = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
            //        Sender_Name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        Sender_Contact = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
            //        Receiver_Name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        Receiver_Contact = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
            //        Receiver_Address = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
            //        Product_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        Quantity = table.Column<int>(type: "int", nullable: false),
            //        Tracking_Id = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Deliverables_Tbl", x => x.Deliverable_id);
            //        table.ForeignKey(
            //            name: "FK_Deliverables_Tbl_Branch_Tbl",
            //            column: x => x.Branch_id,
            //            principalTable: "Branch_Tbl",
            //            principalColumn: "Branch_id");
            //        table.ForeignKey(
            //            name: "FK_Deliverables_Tbl_User_Tbl",
            //            column: x => x.User_id,
            //            principalTable: "User_Tbl",
            //            principalColumn: "User_Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Employees_Tbl",
            //    columns: table => new
            //    {
            //        Employee_id = table.Column<int>(type: "int", nullable: false),
            //        User_id = table.Column<int>(type: "int", nullable: false),
            //        Role = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
            //        Branch_id = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Employees_Tbl", x => x.Employee_id);
            //        table.ForeignKey(
            //            name: "FK_Employees_Tbl_Branch_Tbl",
            //            column: x => x.Branch_id,
            //            principalTable: "Branch_Tbl",
            //            principalColumn: "Branch_id");
            //        table.ForeignKey(
            //            name: "FK_Employees_Tbl_User_Tbl",
            //            column: x => x.User_id,
            //            principalTable: "User_Tbl",
            //            principalColumn: "User_Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Logs_Tbl",
            //    columns: table => new
            //    {
            //        Log_id = table.Column<int>(type: "int", nullable: false),
            //        User_id = table.Column<int>(type: "int", nullable: false),
            //        Action = table.Column<string>(type: "text", nullable: false),
            //        Log_date = table.Column<DateTime>(type: "datetime", nullable: false),
            //        Ip_adress = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Logs_Tbl", x => x.Log_id);
            //        table.ForeignKey(
            //            name: "FK_Logs_Tbl_User_Tbl",
            //            column: x => x.User_id,
            //            principalTable: "User_Tbl",
            //            principalColumn: "User_Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Payment_Tbl",
            //    columns: table => new
            //    {
            //        Payment_id = table.Column<int>(type: "int", nullable: false),
            //        Deliverable_id = table.Column<int>(type: "int", nullable: false),
            //        Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
            //        Payment_date = table.Column<DateTime>(type: "datetime", nullable: false),
            //        Payment_method = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        Payment_status = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Payment_Tbl", x => x.Payment_id);
            //        table.ForeignKey(
            //            name: "FK_Payment_Tbl_Deliverables_Tbl",
            //            column: x => x.Deliverable_id,
            //            principalTable: "Deliverables_Tbl",
            //            principalColumn: "Deliverable_id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Tracking_Tbl",
            //    columns: table => new
            //    {
            //        Tracking_id = table.Column<int>(type: "int", nullable: false),
            //        Deliverable_id = table.Column<int>(type: "int", nullable: false),
            //        Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        Update_date = table.Column<DateTime>(type: "datetime", nullable: false),
            //        Location = table.Column<byte[]>(type: "varbinary(255)", maxLength: 255, nullable: false),
            //        Action_taken = table.Column<string>(type: "text", nullable: false),
            //        Updated_by = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Tracking_Tbl", x => x.Tracking_id);
            //        table.ForeignKey(
            //            name: "FK_Tracking_Tbl_Deliverables_Tbl",
            //            column: x => x.Deliverable_id,
            //            principalTable: "Deliverables_Tbl",
            //            principalColumn: "Deliverable_id");
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Deliverables_Tbl_Branch_id",
            //    table: "Deliverables_Tbl",
            //    column: "Branch_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Deliverables_Tbl_User_id",
            //    table: "Deliverables_Tbl",
            //    column: "User_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Employees_Tbl_Branch_id",
            //    table: "Employees_Tbl",
            //    column: "Branch_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Employees_Tbl_User_id",
            //    table: "Employees_Tbl",
            //    column: "User_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Logs_Tbl_User_id",
            //    table: "Logs_Tbl",
            //    column: "User_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Payment_Tbl_Deliverable_id",
            //    table: "Payment_Tbl",
            //    column: "Deliverable_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Tracking_Tbl_Deliverable_id",
            //    table: "Tracking_Tbl",
            //    column: "Deliverable_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            //migrationBuilder.DropTable(
            //    name: "Employees_Tbl");

            //migrationBuilder.DropTable(
            //    name: "Logs_Tbl");

            //migrationBuilder.DropTable(
            //    name: "Payment_Tbl");

            //migrationBuilder.DropTable(
            //    name: "Service_Charges_Tbl");

            //migrationBuilder.DropTable(
            //    name: "Tracking_Tbl");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            //migrationBuilder.DropTable(
            //    name: "Deliverables_Tbl");

            //migrationBuilder.DropTable(
            //    name: "Branch_Tbl");

            //migrationBuilder.DropTable(
            //    name: "User_Tbl");
        }
    }
}
