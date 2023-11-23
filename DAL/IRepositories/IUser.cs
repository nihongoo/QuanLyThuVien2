using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IUser
    {
        List<NguoiDung> GetAll();
        List<NguoiDung> FindByName(string value);
        List<NguoiDung> FilterByUsedRole(string value);
        public NguoiDung Create(NguoiDung obj);
        public void Update(string TaiKhoan, NguoiDung obj);
        public void Delete(string TaiKhoan);
        public string GetRole(string TaiKhoan);
        ///kiểm tra quyền
        public bool Check(string TaiKhoan, string MatKhau); ///Check login
    }
}
