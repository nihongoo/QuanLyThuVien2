using DAL.Context;
using DAL.IRepositories;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DocGiaRepo : IDocGia
    {
        DBContext _dBContext;
        public DocGiaRepo()
        {
            _dBContext = new();
        }
        public DocGia Create(DocGia obj)
        {
            _dBContext.DocGia.Add(obj);
            _dBContext.SaveChanges();
            return obj;
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            var exobj = _dBContext.DocGia.FirstOrDefault(c => c.IDDocGia == Id);

            if (exobj != null)
            {
                _dBContext.DocGia.Remove(exobj);
                _dBContext.SaveChanges();
            }
        }

        public List<DocGia> GetAll(string Search, string Type)
        {
            if (string.IsNullOrEmpty(Search) && string.IsNullOrEmpty(Type))
            {
                return _dBContext.DocGia.ToList();
            }
            if (Type == "ID")
            {
                return _dBContext.DocGia.Where(c => c.IDDocGia.ToString().Contains(Search)).ToList();
            }
            else if (Type == "Tên")
            {
                return _dBContext.DocGia.Where(c => c.Ten.Contains(Search)).ToList();
            }
            else
            {
                return _dBContext.DocGia.ToList();
            }
            throw new NotImplementedException();
        }

        public void Update(int Id, DocGia obj)
        {
            var exobj = _dBContext.DocGia.FirstOrDefault(c => c.IDDocGia == Id);

            if (obj != null)
            {

            }
            if (exobj != null)
            {
                //exobj.IDDocGia = obj.IDDocGia;
                exobj.DiaChi = obj.DiaChi;
                exobj.SDT = obj.SDT;
                exobj.Ten = obj.Ten;
                exobj.NgayDangKy = obj.NgayDangKy;
                exobj.LoaiThe = obj.LoaiThe;
                exobj.CCCD = obj.CCCD;
            }
            _dBContext.DocGia.Update(exobj);
            _dBContext.SaveChanges();
        }
    }
}
