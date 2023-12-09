using DAL.Context;
using DAL.IRepositories;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SCTRepo : ISCT
    {
        DBContext _dBContext;
        public SCTRepo()
        {
            _dBContext = new();
        }
        public SachCT Create(SachCT obj)
        {
            try
            {
                var exitobj = _dBContext.SachCT.FirstOrDefault(sct => sct.IDSachCT == obj.IDSachCT);

                if (exitobj != null)
                {
                    return null;
                }
                _dBContext.SachCT.Add(obj);
                _dBContext.SaveChanges();
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Delete(int Id)
        {
            var exobj = _dBContext.SachCT.FirstOrDefault(c => c.IDSachCT == Id);

            if (exobj != null)
            {
                _dBContext.SachCT.Remove(exobj);
                _dBContext.SaveChanges();
            }
        }

        public List<SachCTView> GetAll(int Id)
        {
            var query = from sct in _dBContext.SachCT
                        join nxb in _dBContext.NXB
                        on sct.IDNXB equals nxb.IDNXB
                        select new SachCTView()
                        {
                            IDSachCT = sct.IDSachCT,
                            IDSach = sct.IDSach,
                            NgayXB = sct.NgayXB,
                            IDNXB = sct.IDNXB,
                            Gia = sct.Gia,
                            SoLuong = sct.SoLuong,
                            TrangThai = sct.TrangThai,
                            TenNXB = nxb.TenNXB,
                        };
            return query.Where(c => c.IDSach == Id).ToList();
            //throw new NotImplementedException();
        }

        public SachCT Update(int Id, SachCT obj)
        {
            try
            {
                var exobj = _dBContext.SachCT.FirstOrDefault(c => c.IDSachCT == Id);

                if (exobj != null)
                {
                    exobj.NgayXB = obj.NgayXB;
                    exobj.IDNXB = obj.IDNXB;
                    exobj.Gia = obj.Gia;
                    exobj.SoLuong = obj.SoLuong;
                    exobj.TrangThai = obj.TrangThai;

                    _dBContext.SachCT.Update(exobj);
                    _dBContext.SaveChanges();

                    return exobj;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
