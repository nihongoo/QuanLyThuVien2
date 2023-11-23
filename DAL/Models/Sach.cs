using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Sach
    {
        [Key] public int IDSach { get; set; }
        public string TenSach { get; set; }
        public int IDTheLoai { get; set; }
        public int IDNgonNgu { get; set; }
        public string HangSach { get; set; }

    }
}
