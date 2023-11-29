using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.IService
{
    public interface ISCTSev
    {
        List<SachCTView> GetAll(int Id);
        public SachCT Create(SachCT obj);
        public SachCT Update(int Id, SachCT obj);
        public void Delete(int Id);
    }
}
