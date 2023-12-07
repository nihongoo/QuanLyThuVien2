﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.IService
{
    public interface IMemberSev
    {
        List<DocGia> GetAll();
        List<SachView> GetHangSach();
        public void Update(int Id, DocGia obj);
    }
}
