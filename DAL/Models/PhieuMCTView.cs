using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class PhieuMCTView
    {
        [Key] public int IDPhieuMuonCT { get; set; }
        public int IDPhieuMuon { get; set; }
        public int IDSachCT { get; set; }
        public int SoLuong { get; set; }
        public string? GhiChu { get; set; }
        public string? TenSach { get; set; }
        public string? TenDocGia {get; set;}
    }
}
