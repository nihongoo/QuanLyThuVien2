using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class NgonNgu
    {
        [Key] public int IDNgonNgu { get; set; }
        public string TenNgonNgu { get; set; }
        public string? MoTa { get; set; }

    }
}
