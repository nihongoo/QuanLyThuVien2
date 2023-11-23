using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class DocGia
    {
        [Key] public int IDDocGia { get; set; }
        public string Ten { get; set; }
        public string? DiaChi { get; set; }
        public string? SDT { get; set; }
        public DateTime NgayDangKy { get; set; }
        public string LoaiThe { get; set; }
        public string CCCD { get; set; }

    }
}
