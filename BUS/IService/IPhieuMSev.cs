using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.IService
{
    public interface IPhieuMSev
    {
        List<PhieuMuon> GetAll();
        public PhieuMuon Create(PhieuMuon obj);
        public void Update(string Id, PhieuMuon obj);
        public void Delete(string Id);
    }
}
