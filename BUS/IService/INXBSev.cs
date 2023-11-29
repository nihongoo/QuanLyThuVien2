using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.IService
{
    public interface INXBSev
    {
        List<NXB> GetAll();
        public NXB Create(NXB obj);
        public void Update(int Id, NXB obj);
        public void Delete(int Id);
    }
}
