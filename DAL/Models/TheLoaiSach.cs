using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TheLoaiSach
    {
        [Key] public int IDTheLoai { get; set; }
        public string TenTheLoai { get; set; }
        public string? MoTa { get; set; }

    }
}
