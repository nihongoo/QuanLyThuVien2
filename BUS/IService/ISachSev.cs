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
        List<Sach> GetAll();
        Sach FindByID(int Id);
        public Sach Create(Sach obj);
        public void Update(int Id, Sach obj);
        List<T> GetRecords<T>();
    }
}
