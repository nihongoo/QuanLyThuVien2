using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TacGia
    {
        [Key] public int IDTacGia { get; set; }
        public string TenTacGia { get; set; }
        public string? MoTa { get; set; }

    }
}
