using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTL_APIMOVIE.Migrations
{
    public partial class Initial : Migration
    {
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

            migrationBuilder.CreateTable(
                name: "TB_LOAIPHIM",
                columns: table => new
                {
                    MALOAIPHIM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TENLOAIPHIM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAIPHIM", x => x.MALOAIPHIM);
                });

            migrationBuilder.CreateTable(
                name: "TB_NGUOIDUNG",
                columns: table => new
                {
                    MATAIKHOAN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TENDANGNHAP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LOAITAIKHOAN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MATKHAU = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAIKHOAN", x => x.MATAIKHOAN);
                });

            migrationBuilder.CreateTable(
                name: "TB_PHIM",
                columns: table => new
                {
                    MAPHIM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TENPHIM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MOTAPHIM = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    THOILUONG = table.Column<int>(type: "int", nullable: false),
                    ANH = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    NGONNGU = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DUONGDAN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NAM = table.Column<int>(type: "int", nullable: false),
                    DANHGIAPHIM = table.Column<string>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHIM", x => x.MAPHIM);
                });

            migrationBuilder.CreateTable(
                name: "TB_QUOCGIA",
                columns: table => new
                {
                    MAQUOCGIA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TENQUOCGIA = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUOCGIA", x => x.MAQUOCGIA);
                });

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

            migrationBuilder.CreateTable(
                name: "TB_BINHLUAN",
                columns: table => new
                {
                    MABINHLUAN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MATAIKHOAN = table.Column<int>(type: "int", nullable: false),
                    MAPHIM = table.Column<int>(type: "int", nullable: false),
                    NOIDUNG = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    THOIGIAN = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BINHLUAN", x => x.MABINHLUAN);
                    table.ForeignKey(
                        name: "FK_BINHLUAN_NGUOIDUNG",
                        column: x => x.MATAIKHOAN,
                        principalTable: "TB_NGUOIDUNG",
                        principalColumn: "MATAIKHOAN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PHIM_BINHLUAN",
                        column: x => x.MAPHIM,
                        principalTable: "TB_PHIM",
                        principalColumn: "MAPHIM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_Phim_LoaiPhim",
                columns: table => new
                {
                    MA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MAPHIM = table.Column<int>(type: "int", nullable: false),
                    MALOAIPHIM = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHIM_lOAIPHIM", x => x.MA);
                    table.ForeignKey(
                        name: "FK_TB_LoaiPhim",
                        column: x => x.MALOAIPHIM,
                        principalTable: "TB_LOAIPHIM",
                        principalColumn: "MALOAIPHIM",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PHIM",
                        column: x => x.MAPHIM,
                        principalTable: "TB_PHIM",
                        principalColumn: "MAPHIM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_PHIM_QUOCGIA",
                columns: table => new
                {
                    MA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MAQUOCGIA = table.Column<int>(type: "int", nullable: false),
                    MAPHIM = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHIM_QUOCGIA", x => x.MA);
                    table.ForeignKey(
                        name: "FK_TB_PHIM_QG",
                        column: x => x.MAPHIM,
                        principalTable: "TB_PHIM",
                        principalColumn: "MAPHIM",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_QUOCGIA",
                        column: x => x.MAQUOCGIA,
                        principalTable: "TB_QUOCGIA",
                        principalColumn: "MAQUOCGIA",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_TB_BINHLUAN_MAPHIM",
                table: "TB_BINHLUAN",
                column: "MAPHIM");

            migrationBuilder.CreateIndex(
                name: "IX_TB_BINHLUAN_MATAIKHOAN",
                table: "TB_BINHLUAN",
                column: "MATAIKHOAN");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Phim_LoaiPhim_MALOAIPHIM",
                table: "TB_Phim_LoaiPhim",
                column: "MALOAIPHIM");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Phim_LoaiPhim_MAPHIM",
                table: "TB_Phim_LoaiPhim",
                column: "MAPHIM");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PHIM_QUOCGIA_MAPHIM",
                table: "TB_PHIM_QUOCGIA",
                column: "MAPHIM");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PHIM_QUOCGIA_MAQUOCGIA",
                table: "TB_PHIM_QUOCGIA",
                column: "MAQUOCGIA");
        }

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

            migrationBuilder.DropTable(
                name: "TB_BINHLUAN");

            migrationBuilder.DropTable(
                name: "TB_Phim_LoaiPhim");

            migrationBuilder.DropTable(
                name: "TB_PHIM_QUOCGIA");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TB_NGUOIDUNG");

            migrationBuilder.DropTable(
                name: "TB_LOAIPHIM");

            migrationBuilder.DropTable(
                name: "TB_PHIM");

            migrationBuilder.DropTable(
                name: "TB_QUOCGIA");
        }
    }
}
