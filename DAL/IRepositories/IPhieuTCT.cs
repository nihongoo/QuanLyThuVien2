using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IPhieuTCT
    {
        public bool Create(PhieuTraCT obj);
        public bool Update(int Id, PhieuTraCT obj, int iddg, int idsct);
        public void UpdateSCT(int idsct);
        public void UndoSCT(int idsct);
        List<PhieuTCTView> GetAll();
        List<T> GetRecords<T>();
    }
}
