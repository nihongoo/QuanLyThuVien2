using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IPhieuMuonCT
    {
        List<PhieuMCTView> GetAll();
        public bool Create(PhieuMuonCT obj);
        public bool Update(int Id, PhieuMuonCT obj, int iddg, int idsct);
        public void UpdateSCT(int Id);
        public void UndoSCT(int Id);
        public void Delete(int Id);
        List<T> GetRecords<T>();
    }
}
