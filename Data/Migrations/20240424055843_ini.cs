using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace website_CLB_HTSV.Data.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    MaChucVu = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.MaChucVu);
                });

            migrationBuilder.CreateTable(
                name: "HoatDong",
                columns: table => new
                {
                    MaHoatDong = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenHoatDong = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaDiem = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HocKy = table.Column<int>(type: "int", nullable: false),
                    NamHoc = table.Column<int>(type: "int", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DaDangKi = table.Column<bool>(type: "bit", nullable: false),
                    DaThamGia = table.Column<bool>(type: "bit", nullable: false),
                    MinhChung = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoatDong", x => x.MaHoatDong);
                });

            migrationBuilder.CreateTable(
                name: "Khoa",
                columns: table => new
                {
                    MaKhoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenKhoa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoa", x => x.MaKhoa);
                });

            migrationBuilder.CreateTable(
                name: "LopHoc",
                columns: table => new
                {
                    MaLop = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenLop = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Khoahoc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MaKhoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHoc", x => x.MaLop);
                    table.ForeignKey(
                        name: "FK_LopHoc_Khoa_MaKhoa",
                        column: x => x.MaKhoa,
                        principalTable: "Khoa",
                        principalColumn: "MaKhoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    MaSV = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaLop = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MaChucVu = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    HinhAnh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DuongdanQR = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVien", x => x.MaSV);
                    table.ForeignKey(
                        name: "FK_SinhVien_ChucVu_MaChucVu",
                        column: x => x.MaChucVu,
                        principalTable: "ChucVu",
                        principalColumn: "MaChucVu");
                    table.ForeignKey(
                        name: "FK_SinhVien_LopHoc_MaLop",
                        column: x => x.MaLop,
                        principalTable: "LopHoc",
                        principalColumn: "MaLop");
                });

            migrationBuilder.CreateTable(
                name: "DangKyHoatDong",
                columns: table => new
                {
                    MaDangKy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaSV = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MaHoatDong = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThaiDangKy = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangKyHoatDong", x => x.MaDangKy);
                    table.ForeignKey(
                        name: "FK_DangKyHoatDong_HoatDong_MaHoatDong",
                        column: x => x.MaHoatDong,
                        principalTable: "HoatDong",
                        principalColumn: "MaHoatDong");
                    table.ForeignKey(
                        name: "FK_DangKyHoatDong_SinhVien_MaSV",
                        column: x => x.MaSV,
                        principalTable: "SinhVien",
                        principalColumn: "MaSV");
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    MaTaiKhoan = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenDangNhap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quyen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaSV = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.MaTaiKhoan);
                    table.ForeignKey(
                        name: "FK_TaiKhoan_SinhVien_MaSV",
                        column: x => x.MaSV,
                        principalTable: "SinhVien",
                        principalColumn: "MaSV");
                });

            migrationBuilder.CreateTable(
                name: "TinTuc",
                columns: table => new
                {
                    MaTinTuc = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiDang = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SinhVienMaSV = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinTuc", x => x.MaTinTuc);
                    table.ForeignKey(
                        name: "FK_TinTuc_SinhVien_SinhVienMaSV",
                        column: x => x.SinhVienMaSV,
                        principalTable: "SinhVien",
                        principalColumn: "MaSV");
                });

            migrationBuilder.CreateTable(
                name: "ThamGiaHoatDong",
                columns: table => new
                {
                    MaThamGiaHoatDong = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaDangKy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MaSV = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MaHoatDong = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DaThamGia = table.Column<bool>(type: "bit", nullable: false),
                    LinkMinhChung = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThamGiaHoatDong", x => x.MaThamGiaHoatDong);
                    table.ForeignKey(
                        name: "FK_ThamGiaHoatDong_DangKyHoatDong_MaDangKy",
                        column: x => x.MaDangKy,
                        principalTable: "DangKyHoatDong",
                        principalColumn: "MaDangKy");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DangKyHoatDong_MaHoatDong",
                table: "DangKyHoatDong",
                column: "MaHoatDong");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyHoatDong_MaSV",
                table: "DangKyHoatDong",
                column: "MaSV");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_MaKhoa",
                table: "LopHoc",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_MaChucVu",
                table: "SinhVien",
                column: "MaChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_MaLop",
                table: "SinhVien",
                column: "MaLop");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_MaSV",
                table: "TaiKhoan",
                column: "MaSV");

            migrationBuilder.CreateIndex(
                name: "IX_ThamGiaHoatDong_MaDangKy",
                table: "ThamGiaHoatDong",
                column: "MaDangKy");

            migrationBuilder.CreateIndex(
                name: "IX_TinTuc_SinhVienMaSV",
                table: "TinTuc",
                column: "SinhVienMaSV");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "ThamGiaHoatDong");

            migrationBuilder.DropTable(
                name: "TinTuc");

            migrationBuilder.DropTable(
                name: "DangKyHoatDong");

            migrationBuilder.DropTable(
                name: "HoatDong");

            migrationBuilder.DropTable(
                name: "SinhVien");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "LopHoc");

            migrationBuilder.DropTable(
                name: "Khoa");
        }
    }
}
