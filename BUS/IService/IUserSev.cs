using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BUS.IService
{
    public interface IUserSev
    {
        List<NguoiDung> GetAll();
        List<NguoiDung> FindByName(string value);
        List<NguoiDung> FilterByUsedRole(string value);
        public NguoiDung Create(NguoiDung obj);
        public void Update(string TaiKhoan, NguoiDung obj);
        public void Delete(string TaiKhoan);
        public string GetRole(string TaiKhoan);

        public bool Check(string TaiKhoan, string MatKhau); ///Check login
    }
}
