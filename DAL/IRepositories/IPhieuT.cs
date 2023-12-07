﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IPhieuT
    {
        List<PhieuTraView> GetAll();
        public PhieuTra Create(PhieuTra obj);
        public void Update(int Id, PhieuTra obj);
        public void Delete(int Id);
        List<QLMSView> GetQLMS();
        List<T> GetRecords<T>();
    }
}
