using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.IService
{
    public interface ITacGiaSev
    {
        List<TacGia> GetAll();
        public TacGia Create(TacGia obj);
        public void Update(int Id, TacGia obj);
        public void Delete(int Id);
    }
}
