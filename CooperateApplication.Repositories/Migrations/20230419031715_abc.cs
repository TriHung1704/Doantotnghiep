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
                    TenChiNhanh = table.Column<string>(type: "text", nullable: true),
                    Tinh = table.Column<string>(type: "text", nullable: true),
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
                values: new object[] { 1, null, new DateTime(2023, 4, 19, 3, 17, 14, 876, DateTimeKind.Utc).AddTicks(2444), "Là doanh nghiệp phát triển các phần mềm ứng dụng chất lượng ca và ổn định", null, "hr@gmail.com", null, false, "Test Company", "0325867435", false, null, "https://www.google.com.vn/" });

            migrationBuilder.InsertData(
                table: "NguoiDung",
                columns: new[] { "Id", "Avatar", "NgaySinh", "NgayTao", "DiaChiCuThe", "Email", "Ten", "GioiTinh", "IsDeleted", "MatKhau", "SoDienThoai", "DiaChi", "RefreshToken", "RefreshTokenExpiryTime", "TrangThai", "NgayChinhSua", "TaiKhoan", "LoaiNguoiDung" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 19, 3, 17, 14, 875, DateTimeKind.Utc).AddTicks(9718), null, null, "Quản trị viên 1", false, false, "$2a$11$1S0JhB3xoqMQjJeHpacEguh2U1IIdJpiUpLLAZDQqUPuxOePdkU92", null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "admin", 0 },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 19, 3, 17, 15, 72, DateTimeKind.Utc).AddTicks(933), null, null, "Employee HRM", false, false, "$2a$11$QgXsvjLeWgxG0DiHPKvzxeSdvJjb8LH23GCAIzN.yu5NHO4jswG.6", null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "employee_hrm", 1 },
                    { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 19, 3, 17, 15, 259, DateTimeKind.Utc).AddTicks(6903), null, null, "Employee admin", false, false, "$2a$11$Kp2XIGXMBG9Dxr1GC3kr.eZVyQWZuEjapn6RkianIPkVKOBKaBodK", null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "employee_admin", 1 }
                });

            migrationBuilder.InsertData(
                table: "Quyen",
                columns: new[] { "Id", "NgayTao", "IsDeleted", "TenQuyen", "TrangThai", "NgayChinhSua" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 19, 3, 17, 14, 659, DateTimeKind.Utc).AddTicks(410), false, "Administrator", false, null },
                    { 2, new DateTime(2023, 4, 19, 3, 17, 14, 660, DateTimeKind.Utc).AddTicks(227), false, "EmployeeHRM", false, null },
                    { 3, new DateTime(2023, 4, 19, 3, 17, 14, 660, DateTimeKind.Utc).AddTicks(330), false, "EmployeeMentor", false, null },
                    { 4, new DateTime(2023, 4, 19, 3, 17, 14, 660, DateTimeKind.Utc).AddTicks(362), false, "EmployeeAdmin", false, null },
                    { 5, new DateTime(2023, 4, 19, 3, 17, 14, 660, DateTimeKind.Utc).AddTicks(383), false, "Student", false, null }
                });

            migrationBuilder.InsertData(
                table: "Truong",
                columns: new[] { "Id", "DiaChi", "NgayTao", "GioiThieu", "IsDeleted", "TenTruong", "TrangThai", "NgayChinhSua" },
                values: new object[] { 1, "Đà Nẵng", new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(4914), "description", false, "Test University", false, null });

            migrationBuilder.InsertData(
                table: "ChiNhanhDoanhNghiep",
                columns: new[] { "Id", "NgayTao", "DiaChiCuThe", "MaDoanhNghiep", "IsDeleted", "TenChiNhanh", "Tinh", "TrangThai", "NgayChinhSua" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(1578), "Đường 3/2", 1, false, "Tầng 23, Tòa nhà ACB Bank", "Thuận Phước", false, null },
                    { 2, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(1934), "Đường Hùng Vương", 1, false, "Tầng 13, Tòa nhà Viettin Bank", "Hải Châu", false, null }
                });

            migrationBuilder.InsertData(
                table: "Khoa",
                columns: new[] { "Id", "NgayTao", "IsDeleted", "TenKhoa", "TrangThai", "MaTruong", "NgayChinhSua" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(6064), false, "Khoa Công Nghệ Số", false, 1, null },
                    { 2, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(6385), false, "Khoa Điện - Điện Tử", false, 1, null },
                    { 3, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(6432), false, "Khoa Cơ Khí", false, 1, null },
                    { 4, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(6529), false, "Khoa Xây Dựng", false, 1, null },
                    { 5, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(6561), false, "Khoa Hóa Học và Môi Trường", false, 1, null }
                });

            migrationBuilder.InsertData(
                table: "LinhVucKinhDoanh",
                columns: new[] { "Id", "NgayTao", "MaDoanhNghiep", "IsDeleted", "TenLinhVuc", "TrangThai", "NgayChinhSua" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(3150), 1, false, "Software", false, null },
                    { 2, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(3434), 1, false, "Giải trí/ Game", false, null },
                    { 3, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(3513), 1, false, "Dịch vụ IT", false, null }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "Id", "NgayTao", "MaDoanhNghiep", "IsDeleted", "TrangThai", "NgayChinhSua", "MaNguoiDung" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 19, 3, 17, 15, 72, DateTimeKind.Utc).AddTicks(2875), 1, false, false, null, 2 },
                    { 2, new DateTime(2023, 4, 19, 3, 17, 15, 259, DateTimeKind.Utc).AddTicks(7923), 1, false, false, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "QuyenNguoiDung",
                columns: new[] { "Id", "NgayTao", "IsDeleted", "MaQuyen", "TrangThai", "NgayChinhSua", "MaNguoiDung" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 19, 3, 17, 14, 876, DateTimeKind.Utc).AddTicks(1202), false, 1, false, null, 1 },
                    { 2, new DateTime(2023, 4, 19, 3, 17, 15, 72, DateTimeKind.Utc).AddTicks(3136), false, 2, false, null, 2 },
                    { 3, new DateTime(2023, 4, 19, 3, 17, 15, 259, DateTimeKind.Utc).AddTicks(7744), false, 4, false, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Nganh",
                columns: new[] { "Id", "NgayTao", "MaKhoa", "IsDeleted", "TenNganh", "TrangThai", "NgayChinhSua" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(7654), 1, false, "Ngành Công Nghệ Thông Tin", false, null },
                    { 2, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(7784), 2, false, "Ngành Công nghệ kỹ thuật nhiệt", false, null },
                    { 3, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(7816), 2, false, "Ngành Công nghệ kỹ thuật điện, điện tử", false, null },
                    { 5, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(7845), 2, false, "Ngành Công nghệ kỹ thuật điện tử - viễn thông", false, null },
                    { 6, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(7874), 2, false, "Ngành Công nghệ kỹ thuật điều khiển và tự động hóa", false, null },
                    { 7, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(7904), 3, false, "Ngành Công nghệ kỹ thuật cơ khí", false, null },
                    { 8, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(7933), 3, false, "Ngành Công nghệ kỹ thuật cơ điện tử", false, null },
                    { 9, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(7962), 4, false, "Ngành Công nghệ kỹ thuật xây dựng", false, null },
                    { 10, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(7992), 4, false, "Ngành Công nghệ kỹ thuật giao thông", false, null },
                    { 11, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(8023), 4, false, "Ngành Công nghệ kỹ thuật kiến trúc", false, null },
                    { 12, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(8052), 4, false, "Kỹ thuật cơ sở hạ tầng", false, null },
                    { 13, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(8124), 5, false, "Công nghệ kỹ thuật môi trường", false, null },
                    { 14, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(8161), 5, false, "Ngành Kỹ Thuật thực phẩm", false, null },
                    { 15, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(8583), 5, false, "Ngành Công nghệ vật liệu", false, null }
                });

            migrationBuilder.InsertData(
                table: "Lop",
                columns: new[] { "Id", "NgayTao", "IsDeleted", "MaNganh", "TenLop", "TrangThai", "NgayChinhSua" },
                values: new object[] { 1, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(9610), false, 1, "20T1", false, null });

            migrationBuilder.InsertData(
                table: "Lop",
                columns: new[] { "Id", "NgayTao", "IsDeleted", "MaNganh", "TenLop", "TrangThai", "NgayChinhSua" },
                values: new object[] { 2, new DateTime(2023, 4, 19, 3, 17, 15, 260, DateTimeKind.Utc).AddTicks(9934), false, 1, "20T2", false, null });

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
