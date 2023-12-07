using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IPhieuM
    {
        List<PhieuMView> GetAll();
        public PhieuMuon Create(PhieuMuon obj);
        public void Update(int Id, PhieuMuon obj);
        public void Delete(int Id);
        List<T> GetRecords<T>();
    }
}
