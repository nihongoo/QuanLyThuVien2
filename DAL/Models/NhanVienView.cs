using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class NhanVienView
    {
        [Key] public int IDNhanVien { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string TenNhanVien { get; set; }
    }
}
