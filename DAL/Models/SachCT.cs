using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class SachCT
    {
        [Key] public int IDSachCT { get; set; }
        public int IDSach { get; set; }
        public DateTime NgayXB { get; set; }
        public int IDNXB { get; set; }
        public string Gia { get; set; }
        public int SoLuong { get; set; }
        public string? TrangThai { get; set; }

    }
}
