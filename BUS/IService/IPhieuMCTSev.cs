using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.IService
{
    public interface IPhieuMCTSev
    {
        List<PhieuMCTView> GetAll();
        public bool Create(PhieuMuonCT obj);
        public bool Update(int Id, PhieuMuonCT obj, int iddg, int idsct);
        public void Delete(int Id);
        List<T> GetRecords<T>();
    }
}
