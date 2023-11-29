using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface ITheLoai
    {
        public TheLoaiSach Create(TheLoaiSach obj);
        public void Update(int Id, TheLoaiSach obj);
        public void Delete(int Id);
    }
}
