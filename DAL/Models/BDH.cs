﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class BDH
    {
        [Key] public int IDBDH { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }

    }
}
