using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace CooperateApplication.Repositories.Migrations
{
    public partial class abc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    HinhAnh = table.Column<string>(type: "text", nullable: true),
                    KichHoat = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayChinhSua = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoanhNghiep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TenDoanhNghiep = table.Column<string>(type: "text", nullable: true),
                    MaSoThue = table.Column<string>(type: "text", nullable: true),
                    GiamDoc = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Website = table.Column<string>(type: "text", nullable: true),
                    SoDienThoai = table.Column<string>(type: "text", nullable: true),
                    GioiThieu = table.Column<string>(type: "text", nullable: true),
                    Logo = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayChinhSua = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoanhNghiep", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TaiKhoan = table.Column<string>(type: "text", nullable: true),
                    MatKhau = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    SoDienThoai = table.Column<string>(type: "text", nullable: true),
                    Ten = table.Column<string>(type: "text", nullable: true),
                    GioiTinh = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: true),
                    DiaChi = table.Column<string>(type: "text", nullable: true),
                    DiaChiCuThe = table.Column<string>(type: "text", nullable: true),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    LoaiNguoiDung = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayChinhSua = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quyen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TenQuyen = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayChinhSua = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quyen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Truong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TenTruong = table.Column<string>(type: "text", nullable: true),
                    GioiThieu = table.Column<string>(type: "text", nullable: true),
                    DiaChi = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayChinhSua = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChiNhanhDoanhNghiep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DiaChiCuThe = table.Column<string>(type: "text", nullable: true),
                    MaDoanhNghiep = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayChinhSua = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiNhanhDoanhNghiep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiNhanhDoanhNghiep_DoanhNghiep_MaDoanhNghiep",
                        column: x => x.MaDoanhNghiep,
                        principalTable: "DoanhNghiep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinhVucKinhDoanh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TenLinhVuc = table.Column<string>(type: "text", nullable: true),
                    MaDoanhNghiep = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayChinhSua = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinhVucKinhDoanh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinhVucKinhDoanh_DoanhNghiep_MaDoanhNghiep",
                        column: x => x.MaDoanhNghiep,
                        principalTable: "DoanhNghiep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaiDang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TieuDe = table.Column<string>(type: "text", nullable: true),
                    MoTa = table.Column<string>(type: "text", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    HinhAnh = table.Column<string>(type: "text", nullable: true),
                    HanCuoi = table.Column<DateTime>(type: "datetime", nullable: false),
                    LoaiBai = table.Column<int>(type: "int", nullable: false),
                    MaDoanhNghiep = table.Column<int>(type: "int", nullable: false),
                    MaNguoiDung = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayChinhSua = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiDang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaiDang_DoanhNghiep_MaDoanhNghiep",
                        column: x => x.MaDoanhNghiep,
                        principalTable: "DoanhNghiep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaiDang_NguoiDung_MaNguoiDung",
                        column: x => x.MaNguoiDung,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MaNguoiDung = table.Column<int>(type: "int", nullable: false),
                    MaDoanhNghiep = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayChinhSua = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhanVien_DoanhNghiep_MaDoanhNghiep",
                        column: x => x.MaDoanhNghiep,
                        principalTable: "DoanhNghiep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanVien_NguoiDung_MaNguoiDung",
                        column: x => x.MaNguoiDung,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThongBao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TieuDe = table.Column<string>(type: "text", nullable: true),
                    NoiDung = table.Column<string>(type: "text", nullable: true),
                    HinhAnh = table.Column<string>(type: "text", nullable: true),
                    MaNguoiDung = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayChinhSua = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongBao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongBao_NguoiDung_MaNguoiDung",
                        column: x => x.MaNguoiDung,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuyenNguoiDung",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MaNguoiDung = table.Column<int>(type: "int", nullable: false),
                    MaQuyen = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayChinhSua = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyenNguoiDung", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuyenNguoiDung_NguoiDung_MaNguoiDung",
                        column: x => x.MaNguoiDung,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuyenNguoiDung_Quyen_MaQuyen",
                        column: x => x.MaQuyen,
                        principalTable: "Quyen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Khoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TenKhoa = table.Column<string>(type: "text", nullable: true),
                    MaTruong = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayChinhSua = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Khoa_Truong_MaTruong",
                        column: x => x.MaTruong,
                        principalTable: "Truong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nganh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TenNganh = table.Column<string>(type: "text", nullable: true),
                    MaKhoa = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayChinhSua = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nganh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nganh_Khoa_MaKhoa",
                        column: x => x.MaKhoa,
                        principalTable: "Khoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TenLop = table.Column<string>(type: "text", nullable: true),
                    MaNganh = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayChinhSua = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lop_Nganh_MaNganh",
                        column: x => x.MaNganh,
                        principalTable: "Nganh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NganhBaiDang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MaBaiDang = table.Column<int>(type: "int", nullable: false),
                    MaNganh = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayChinhSua = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NganhBaiDang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NganhBaiDang_BaiDang_MaBaiDang",
                        column: x => x.MaBaiDang,
                        principalTable: "BaiDang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NganhBaiDang_Nganh_MaNganh",
                        column: x => x.MaNganh,
                        principalTable: "Nganh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FileCV = table.Column<string>(type: "text", nullable: true),
                    MaNguoiDung = table.Column<int>(type: "int", nullable: false),
                    MaLop = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayChinhSua = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SinhVien_Lop_MaLop",
                        column: x => x.MaLop,
                        principalTable: "Lop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SinhVien_NguoiDung_MaNguoiDung",
                        column: x => x.MaNguoiDung,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SinhVienHoiThao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MaSinhVien = table.Column<int>(type: "int", nullable: false),
                    MaBaiDang = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayChinhSua = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVienHoiThao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SinhVienHoiThao_BaiDang_MaBaiDang",
                        column: x => x.MaBaiDang,
                        principalTable: "BaiDang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SinhVienHoiThao_SinhVien_MaSinhVien",
                        column: x => x.MaSinhVien,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SinhVienTuyenDung",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DuyetDangKi = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MaSinhVien = table.Column<int>(type: "int", nullable: false),
                    MaBaiDang = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayChinhSua = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVienTuyenDung", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SinhVienTuyenDung_BaiDang_MaBaiDang",
                        column: x => x.MaBaiDang,
                        principalTable: "BaiDang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SinhVienTuyenDung_SinhVien_MaSinhVien",
                        column: x => x.MaSinhVien,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DoanhNghiep",
                columns: new[] { "Id", "MaSoThue", "NgayTao", "GioiThieu", "GiamDoc", "Email", "Logo", "IsDeleted", "TenDoanhNghiep", "SoDienThoai", "TrangThai", "NgayChinhSua", "Website" },
                values: new object[] { 1, null, new DateTime(2023, 5, 2, 17, 6, 26, 201, DateTimeKind.Utc).AddTicks(850), "Là doanh nghiệp phát triển các phần mềm ứng dụng chất lượng ca và ổn định", null, "hr@gmail.com", null, false, "Test Company", "0325867435", true, null, "https://www.google.com.vn/" });

            migrationBuilder.InsertData(
                table: "NguoiDung",
                columns: new[] { "Id", "Avatar", "NgaySinh", "NgayTao", "DiaChiCuThe", "Email", "Ten", "GioiTinh", "IsDeleted", "MatKhau", "SoDienThoai", "DiaChi", "RefreshToken", "RefreshTokenExpiryTime", "TrangThai", "NgayChinhSua", "TaiKhoan", "LoaiNguoiDung" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 2, 17, 6, 26, 200, DateTimeKind.Utc).AddTicks(8712), null, "qtrv@gmail.com", "Quản trị viên", false, false, "$2a$11$YlLGQfQQIUbZB6W/GX9U/.R5P10UkmS2p5h3W/ZpGh9SWGzPIijl2", "0987654321", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "admin", 0 },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 2, 17, 6, 26, 375, DateTimeKind.Utc).AddTicks(4034), null, null, "Employee HRM", false, false, "$2a$11$3r4Gy7cqW0I2cW13aVkL6O2lWIE394dYysdEttyo1Hq6XI0gbbzuG", null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "employee_hrm", 1 },
                    { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 2, 17, 6, 26, 549, DateTimeKind.Utc).AddTicks(7084), null, null, "Employee admin", false, false, "$2a$11$LasxMd3SI.jluNseAO088uPEx4QYWbHE8qdm.zVV3Pen3u2o9aiTe", null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "employee_admin", 1 }
                });

            migrationBuilder.InsertData(
                table: "Quyen",
                columns: new[] { "Id", "NgayTao", "IsDeleted", "TenQuyen", "TrangThai", "NgayChinhSua" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 2, 17, 6, 25, 996, DateTimeKind.Utc).AddTicks(2659), false, "Administrator", false, null },
                    { 2, new DateTime(2023, 5, 2, 17, 6, 25, 997, DateTimeKind.Utc).AddTicks(1360), false, "EmployeeHRM", false, null },
                    { 4, new DateTime(2023, 5, 2, 17, 6, 25, 997, DateTimeKind.Utc).AddTicks(1436), false, "EmployeeAdmin", false, null },
                    { 5, new DateTime(2023, 5, 2, 17, 6, 25, 997, DateTimeKind.Utc).AddTicks(1454), false, "Student", false, null }
                });

            migrationBuilder.InsertData(
                table: "Truong",
                columns: new[] { "Id", "DiaChi", "NgayTao", "GioiThieu", "IsDeleted", "TenTruong", "TrangThai", "NgayChinhSua" },
                values: new object[] { 1, "Đà Nẵng", new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(1280), "description", false, "Test University", false, null });

            migrationBuilder.InsertData(
                table: "ChiNhanhDoanhNghiep",
                columns: new[] { "Id", "NgayTao", "DiaChiCuThe", "MaDoanhNghiep", "IsDeleted", "TrangThai", "NgayChinhSua" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 2, 17, 6, 26, 549, DateTimeKind.Utc).AddTicks(9803), "Tầng 23, Tòa nhà ACB Bank - Đường 3/2 Thuận Phước Đà Nẵng", 1, false, false, null },
                    { 2, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(34), "Tầng 13, Tòa nhà Viettin Bank - Đường Hùng Vương Hải Châu Đà Nẵng", 1, false, false, null }
                });

            migrationBuilder.InsertData(
                table: "Khoa",
                columns: new[] { "Id", "NgayTao", "IsDeleted", "TenKhoa", "TrangThai", "MaTruong", "NgayChinhSua" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(1777), false, "Khoa Công Nghệ Số", false, 1, null },
                    { 2, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(1916), false, "Khoa Điện - Điện Tử", false, 1, null },
                    { 3, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(1941), false, "Khoa Cơ Khí", false, 1, null },
                    { 4, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(1971), false, "Khoa Xây Dựng", false, 1, null },
                    { 5, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(1992), false, "Khoa Hóa Học và Môi Trường", false, 1, null },
                    { 6, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(2022), false, "Khoa Sư Phạm Công Nghiệp", false, 1, null }
                });

            migrationBuilder.InsertData(
                table: "LinhVucKinhDoanh",
                columns: new[] { "Id", "NgayTao", "MaDoanhNghiep", "IsDeleted", "TenLinhVuc", "TrangThai", "NgayChinhSua" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(610), 1, false, "Software", false, null },
                    { 2, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(717), 1, false, "Giải trí/ Game", false, null },
                    { 3, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(749), 1, false, "Dịch vụ IT", false, null }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "Id", "NgayTao", "MaDoanhNghiep", "IsDeleted", "TrangThai", "NgayChinhSua", "MaNguoiDung" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 2, 17, 6, 26, 375, DateTimeKind.Utc).AddTicks(5703), 1, false, false, null, 2 },
                    { 2, new DateTime(2023, 5, 2, 17, 6, 26, 549, DateTimeKind.Utc).AddTicks(8020), 1, false, false, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "QuyenNguoiDung",
                columns: new[] { "Id", "NgayTao", "IsDeleted", "MaQuyen", "TrangThai", "NgayChinhSua", "MaNguoiDung" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 2, 17, 6, 26, 200, DateTimeKind.Utc).AddTicks(9991), false, 1, false, null, 1 },
                    { 2, new DateTime(2023, 5, 2, 17, 6, 26, 375, DateTimeKind.Utc).AddTicks(5906), false, 2, false, null, 2 },
                    { 3, new DateTime(2023, 5, 2, 17, 6, 26, 549, DateTimeKind.Utc).AddTicks(7879), false, 4, false, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Nganh",
                columns: new[] { "Id", "NgayTao", "MaKhoa", "IsDeleted", "TenNganh", "TrangThai", "NgayChinhSua" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(2652), 1, false, "Ngành Công Nghệ Thông Tin", false, null },
                    { 2, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(2741), 2, false, "Ngành Tự Động Hóa", false, null },
                    { 3, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(2764), 2, false, "Ngành Điện - Điện Tử", false, null },
                    { 4, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(2784), 3, false, "Ngành Công nghệ kỹ thuật cơ khí", false, null },
                    { 5, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(2803), 3, false, "Ngành Công nghệ kỹ thuật cơ điện tử", false, null },
                    { 6, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(2825), 4, false, "Ngành Công nghệ kỹ thuật xây dựng", false, null },
                    { 7, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(2845), 4, false, "Ngành Công nghệ kỹ thuật xây dựng cầu đường", false, null },
                    { 8, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(2864), 5, false, "Ngành Kỹ Thuật môi trường", false, null }
                });

            migrationBuilder.InsertData(
                table: "Lop",
                columns: new[] { "Id", "NgayTao", "IsDeleted", "MaNganh", "TenLop", "TrangThai", "NgayChinhSua" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(3263), false, 1, "19T1", false, null },
                    { 28, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4430), false, 1, "20MT1", false, null },
                    { 29, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4450), false, 1, "20MT2", false, null },
                    { 30, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4470), false, 1, "20SK1", false, null },
                    { 31, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4490), false, 1, "20XD1", false, null },
                    { 32, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4511), false, 1, "20XD2", false, null },
                    { 33, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4531), false, 1, "20XC1", false, null },
                    { 34, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4553), false, 1, "20XC2", false, null },
                    { 35, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4573), false, 1, "21T1", false, null },
                    { 36, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4594), false, 1, "21T2", false, null },
                    { 37, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4615), false, 1, "21C1", false, null },
                    { 27, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4410), false, 1, "20TDH2", false, null },
                    { 38, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4634), false, 1, "21C2", false, null },
                    { 40, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4675), false, 1, "21CDT2", false, null },
                    { 41, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4695), false, 1, "21DT1", false, null },
                    { 42, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4714), false, 1, "21DT2", false, null },
                    { 43, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4788), false, 1, "21TDH1", false, null },
                    { 44, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4811), false, 1, "21TDH2", false, null },
                    { 45, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4831), false, 1, "21MT1", false, null },
                    { 46, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4851), false, 1, "21MT2", false, null },
                    { 47, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4871), false, 1, "21SK1", false, null },
                    { 48, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4891), false, 1, "21XD1", false, null },
                    { 49, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4910), false, 1, "21XD2", false, null },
                    { 39, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4655), false, 1, "21CDT1", false, null },
                    { 50, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4931), false, 1, "21XC1", false, null },
                    { 26, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4389), false, 1, "20TDH1", false, null },
                    { 24, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4347), false, 1, "20DT1", false, null },
                    { 2, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(3458), false, 1, "19T2", false, null },
                    { 3, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(3479), false, 1, "19C1", false, null },
                    { 4, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(3499), false, 1, "19C2", false, null },
                    { 5, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(3519), false, 1, "19CDT1", false, null },
                    { 6, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(3574), false, 1, "19CDT2", false, null },
                    { 7, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(3655), false, 1, "19DT1", false, null },
                    { 8, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(3986), false, 1, "19DT2", false, null },
                    { 9, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4014), false, 1, "19TDH1", false, null },
                    { 10, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4038), false, 1, "19TDH2", false, null },
                    { 11, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4059), false, 1, "19MT1", false, null },
                    { 25, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4369), false, 1, "20DT2", false, null },
                    { 12, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4080), false, 1, "19MT2", false, null },
                    { 14, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4120), false, 1, "19XD1", false, null },
                    { 15, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4140), false, 1, "19XD2", false, null },
                    { 16, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4160), false, 1, "19XC1", false, null },
                    { 17, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4180), false, 1, "19XC2", false, null },
                    { 18, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4202), false, 1, "20T1", false, null },
                    { 19, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4223), false, 1, "20T2", false, null },
                    { 20, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4243), false, 1, "20C1", false, null },
                    { 21, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4263), false, 1, "20C2", false, null },
                    { 22, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4283), false, 1, "20CDT1", false, null },
                    { 23, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4303), false, 1, "20CDT2", false, null },
                    { 13, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4100), false, 1, "19SK1", false, null },
                    { 51, new DateTime(2023, 5, 2, 17, 6, 26, 550, DateTimeKind.Utc).AddTicks(4951), false, 1, "21XC2", false, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaiDang_MaDoanhNghiep",
                table: "BaiDang",
                column: "MaDoanhNghiep");

            migrationBuilder.CreateIndex(
                name: "IX_BaiDang_MaNguoiDung",
                table: "BaiDang",
                column: "MaNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_ChiNhanhDoanhNghiep_MaDoanhNghiep",
                table: "ChiNhanhDoanhNghiep",
                column: "MaDoanhNghiep");

            migrationBuilder.CreateIndex(
                name: "IX_Khoa_MaTruong",
                table: "Khoa",
                column: "MaTruong");

            migrationBuilder.CreateIndex(
                name: "IX_LinhVucKinhDoanh_MaDoanhNghiep",
                table: "LinhVucKinhDoanh",
                column: "MaDoanhNghiep");

            migrationBuilder.CreateIndex(
                name: "IX_Lop_MaNganh",
                table: "Lop",
                column: "MaNganh");

            migrationBuilder.CreateIndex(
                name: "IX_Nganh_MaKhoa",
                table: "Nganh",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_NganhBaiDang_MaBaiDang",
                table: "NganhBaiDang",
                column: "MaBaiDang");

            migrationBuilder.CreateIndex(
                name: "IX_NganhBaiDang_MaNganh",
                table: "NganhBaiDang",
                column: "MaNganh");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaDoanhNghiep",
                table: "NhanVien",
                column: "MaDoanhNghiep");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaNguoiDung",
                table: "NhanVien",
                column: "MaNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_QuyenNguoiDung_MaNguoiDung",
                table: "QuyenNguoiDung",
                column: "MaNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_QuyenNguoiDung_MaQuyen",
                table: "QuyenNguoiDung",
                column: "MaQuyen");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_MaLop",
                table: "SinhVien",
                column: "MaLop");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_MaNguoiDung",
                table: "SinhVien",
                column: "MaNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienHoiThao_MaBaiDang",
                table: "SinhVienHoiThao",
                column: "MaBaiDang");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienHoiThao_MaSinhVien",
                table: "SinhVienHoiThao",
                column: "MaSinhVien");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienTuyenDung_MaBaiDang",
                table: "SinhVienTuyenDung",
                column: "MaBaiDang");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienTuyenDung_MaSinhVien",
                table: "SinhVienTuyenDung",
                column: "MaSinhVien");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBao_MaNguoiDung",
                table: "ThongBao",
                column: "MaNguoiDung");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banner");

            migrationBuilder.DropTable(
                name: "ChiNhanhDoanhNghiep");

            migrationBuilder.DropTable(
                name: "LinhVucKinhDoanh");

            migrationBuilder.DropTable(
                name: "NganhBaiDang");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "QuyenNguoiDung");

            migrationBuilder.DropTable(
                name: "SinhVienHoiThao");

            migrationBuilder.DropTable(
                name: "SinhVienTuyenDung");

            migrationBuilder.DropTable(
                name: "ThongBao");

            migrationBuilder.DropTable(
                name: "Quyen");

            migrationBuilder.DropTable(
                name: "BaiDang");

            migrationBuilder.DropTable(
                name: "SinhVien");

            migrationBuilder.DropTable(
                name: "DoanhNghiep");

            migrationBuilder.DropTable(
                name: "Lop");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "Nganh");

            migrationBuilder.DropTable(
                name: "Khoa");

            migrationBuilder.DropTable(
                name: "Truong");
        }
    }
}
