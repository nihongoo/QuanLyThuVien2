﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class PhieuTCTView
    {
        [Key] public int IDPhieuTraCT { get; set; }
        public int IDPhieuTra { get; set; }
        public int IDSachCT { get; set; }
        public int SoLuong { get; set; }
        public string? GhiChu { get; set; }
        public string? TenSach { get; set; }
        public string? TenDocGia { get; set; }
    }
}
