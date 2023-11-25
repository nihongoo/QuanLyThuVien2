using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class PhieuMuon
    {
        [Key] public int IDPhieuMuon { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime NgayTra { get; set; }
        public int IDDocGia { get; set; }
        public int IDNhanVien { get; set; }
        public string GhiChu { get; set; }
        //atri join
        public string? TenDocGia { get; set; }
        public string? TenNV { get; set; }
    }
}
