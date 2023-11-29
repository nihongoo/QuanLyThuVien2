using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.IService
{
    public interface INgonNguSev
    {
        public NgonNgu Create(NgonNgu obj);
        public void Update(int Id, NgonNgu obj);
        public void Delete(int Id);
    }
}
