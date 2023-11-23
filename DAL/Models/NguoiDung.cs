using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class NguoiDung
    {
        [Key] public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string Ten { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SDT { get; set; }
        public string Quyen { get; set; }
    }
}
