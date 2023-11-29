using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.IService
{
    public interface ISachSev
    {
        List<SachView> GetAll(string Search);
        public Sach Create(Sach obj);
        public void Update(int Id, Sach obj);
        public void Delete(int Id);
        List<T> GetRecords<T>();
    }
}
