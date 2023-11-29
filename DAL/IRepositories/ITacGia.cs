using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface ITacGia
    {
        List<TacGia> GetAll();
        public TacGia Create(TacGia obj);
        public void Update(int Id, TacGia obj);
        public void Delete(int Id);
    }
}
