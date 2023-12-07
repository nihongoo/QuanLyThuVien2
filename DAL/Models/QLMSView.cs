using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class QLMSView
    {
        public int IDDocGia { get; set; }
        public int IDSachCT { get; set; }
        public string? GhiChu { get; set; }
        public string? TenDocGia { get; set; }
        public string? TenSach { get; set; }
    }
}
