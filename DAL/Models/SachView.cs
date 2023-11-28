using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class SachView
    {
        [Key] public int? IDSach { get; set; }
        public string TenSach { get; set; }
        public int IDTheLoai { get; set; }
        public int IDTacGia { get; set; }
        public int IDNgonNgu { get; set; }
        public string HangSach { get; set; }

        //[ForeignKey("IDTheLoai")]
        public string? TenTheLoai { get; set; }

        //[ForeignKey("IDNgonNgu")]
        public string? TenNgonNgu { get; set; }
        public string? TenTacGia { get; set; }
    }
}
