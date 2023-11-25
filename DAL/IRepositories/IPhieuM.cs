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
        List<PhieuMuon> GetAll();
        public PhieuMuon Create(PhieuMuon obj);
        public void Update(string Id, PhieuMuon obj);
        public void Delete(string Id);
    }
}
