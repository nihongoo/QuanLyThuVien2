using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IMemBer
    {
        List<DocGia> GetAll();
        List<SachView> GetHangSach();
        public void Update(int Id);
    }
}
