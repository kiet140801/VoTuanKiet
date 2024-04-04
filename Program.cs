using System;
using System.Collections.Generic;
using System.Linq;

namespace VoTuanKiet
{
    internal class Program
    {
        static List<ViecCanLam> danhSachViec = new List<ViecCanLam>();

        static void Main(string[] args)
        {
            bool chay = true;
            while (chay)
            {
                Console.WriteLine("Quan ly viec can lam");
                Console.WriteLine("1. Them viec can lam");
                Console.WriteLine("2. Xoa viec cam lam");
                Console.WriteLine("3. Cap nhat trang thai viec can lam");
                Console.WriteLine("4. tim kiem viec can lam");
                Console.WriteLine("5. Hien thi danh sach viec can lam theo do uu tien");
                Console.WriteLine("6. Hien thi toan bo danh sach viec can lam");
                Console.WriteLine("7. Thoat");
                Console.Write("Chon chuc nang: ");  

                int luaChon;
                if (int.TryParse(Console.ReadLine(), out luaChon))
                {
                    switch (luaChon)
                    {
                        case 1:
                            ThemViecCanLam();
                            break;
                        case 2:
                            XoaViecCanLam();
                            break;
                        case 3:
                            CapNhatTrangThai();
                            break;
                        case 4:
                            TimKiemViecCanLam();
                            break;
                        case 5:
                            HienThiTheoDoUuTien();
                            break;
                        case 6:
                            HienThiDanhSach();
                            break;
                        case 7:
                            chay = false;
                            break;
                        default:
                            Console.WriteLine("Chuc nang khong hop le. Vui long chon lai.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Vui long nhap so.");
                }
                Console.WriteLine();
            }
        }
        static void ThemViecCanLam()
        {
            Console.WriteLine("Them viec can lam");
            ViecCanLam viec = new ViecCanLam();

            Console.Write("Nhap ten viec: ");
            viec.TenViec = Console.ReadLine();

            Console.Write("Nhap do uu tien (1-5): ");
            int doUuTien;
            if (int.TryParse(Console.ReadLine(), out doUuTien) && doUuTien >= 1 && doUuTien <= 5)
            {
                viec.DoUuTien = doUuTien;
            }
            else
            {
                Console.WriteLine("Đo uu tien khong hop le. Se duoc mac dinh se la 1.");
                viec.DoUuTien = 1;
            }

            Console.Write("Nhap mo ta: ");
            viec.MoTa = Console.ReadLine();

            viec.TrangThai = false;

            danhSachViec.Add(viec);
        }

        static void XoaViecCanLam()
        {
            Console.WriteLine("Xoa viec can lam");
            HienThiDanhSach();

            Console.Write("Nhap vi tri viec can xoa: ");
            int viTri;
            if (int.TryParse(Console.ReadLine(), out viTri) && viTri >= 0 && viTri < danhSachViec.Count)
            {
                danhSachViec.RemoveAt(viTri);
                Console.WriteLine("Da xoa thanh cong.");
            }
            else
            {
                Console.WriteLine("Vi tri trong hop le.");
            }
        }

        static void CapNhatTrangThai()
        {
            Console.WriteLine("Cap nhat trang thai viec can lam");
            Console.Write("Nhap ten viec can cap nhat trang thai: ");
            string tenViec = Console.ReadLine();

            var viecCanCapNhat = danhSachViec.FirstOrDefault(v => v.TenViec.Equals(tenViec, StringComparison.OrdinalIgnoreCase));
            if (viecCanCapNhat != null)
            {
                Console.Write("Nhap trang thai moi chon true hoac false: ");
                if (bool.TryParse(Console.ReadLine(), out bool trangThai))
                {
                    viecCanCapNhat.TrangThai = trangThai;
                    Console.WriteLine("Da cap nhap trang thai moi thanh cong.");
                }
                else
                {
                    Console.WriteLine("Trang thai khong hop le.");
                }
            }
            else
            {
                Console.WriteLine("Khong tim thay viec can cap nhat.");
            }
        }

        static void TimKiemViecCanLam()
        {
            Console.WriteLine("Tim kiem viec can lam");
            Console.WriteLine("1. Tim kiem theo ten viec");
            Console.WriteLine("2. Tim kiem theo do uu tien");
            Console.Write("Chon cach tim kiem: ");

            int luaChon;
            if (int.TryParse(Console.ReadLine(), out luaChon))
            {
                switch (luaChon)
                {
                    case 1:
                        Console.Write("Nhap ten viec can tim: ");
                        string tenViec = Console.ReadLine();
                        var ketQuaTenViec = danhSachViec.Where(v => v.TenViec.Contains(tenViec, StringComparison.OrdinalIgnoreCase));
                        HienThiDanhSach(ketQuaTenViec.ToList());
                        break;
                    case 2:
                        Console.Write("Nhap do uu tien can tim: ");
                        int doUuTien;
                        if (int.TryParse(Console.ReadLine(), out doUuTien) && doUuTien >= 1 && doUuTien <= 5)
                        {
                            var ketQuaDoUuTien = danhSachViec.Where(v => v.DoUuTien == doUuTien);
                            HienThiDanhSach(ketQuaDoUuTien.ToList());
                        }
                        else
                        {
                            Console.WriteLine("Do uu tien khong hop le.");
                        }
                        break;
                    default:
                        Console.WriteLine("cach tim kiem khong hop le.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Vui long nhap so.");
            }
        }

        static void HienThiTheoDoUuTien()
        {
            Console.WriteLine("Danh sach viec lam theo do uu tien.");
            var danhSachSapXep = danhSachViec.OrderByDescending(v => v.DoUuTien);
            HienThiDanhSach(danhSachSapXep.ToList());
        }

        static void HienThiDanhSach(List<ViecCanLam> danhSach = null)
        {
            if (danhSach == null)
                danhSach = danhSachViec;

            Console.WriteLine("Danh sach viec can lam");
            if (danhSach.Any())
            {
                for (int i = 0; i < danhSach.Count; i++)
                {
                    Console.WriteLine($"[{i}] Ten: {danhSach[i].TenViec} | Do uu tien: {danhSach[i].DoUuTien} | Mo ta: {danhSach[i].MoTa} | Trang thai {(danhSach[i].TrangThai ? "Hoan thanh" : "Chua hoan thanh")}");
                }
            }
            else
            {
                Console.WriteLine("Khong co viec can lam");
            }
        }
    }
}
