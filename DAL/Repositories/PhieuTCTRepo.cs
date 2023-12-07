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
    public class PhieuTCTRepo : IPhieuTCT
    {
        DBContext _dBContext;
        public PhieuTCTRepo()
        {
            _dBContext = new();
        }
        public bool Create(PhieuTraCT obj)
        {
            var exobj = _dBContext.PhieuTraCT.FirstOrDefault(c => c.IDPhieuTraCT == obj.IDPhieuTra);
            if (exobj != null)
            {
                exobj.IDPhieuTra = obj.IDPhieuTra;
                exobj.IDSachCT = obj.IDSachCT;
                exobj.SoLuong = obj.SoLuong;
                exobj.GhiChu = obj.GhiChu;
            }
            else
            {
                var pt = _dBContext.PhieuTra.FirstOrDefault(c => c.IDPhieuTra == obj.IDPhieuTra);
                if (pt != null)
                {
                    //QuanLyMuonSach phx = new QuanLyMuonSach();
                    var phx = _dBContext.QuanLyMuonSach.FirstOrDefault(c => c.IDDocGia == pt.IDDocGia && c.IDSachCT == obj.IDSachCT);
                    if (phx != null)
                    {
                        _dBContext.QuanLyMuonSach.Remove(phx);
                        UpdateSCT(obj.IDSachCT);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                _dBContext.PhieuTraCT.Add(obj);
            }
            // Gọi SaveChanges sau khi thực hiện tất cả các thay đổi
            _dBContext.SaveChanges();

            return true;
        }

        public List<PhieuTCTView> GetAll()
        {
            var query = from pct in _dBContext.PhieuTraCT
                        join pm in _dBContext.PhieuTra
                        on pct.IDPhieuTra equals pm.IDPhieuTra
                        join dg in _dBContext.DocGia
                        on pm.IDDocGia equals dg.IDDocGia
                        join sct in _dBContext.SachCT
                        on pct.IDSachCT equals sct.IDSachCT
                        join sa in _dBContext.Sach
                        on sct.IDSach equals sa.IDSach
                        select new PhieuTCTView
                        {
                            IDPhieuTraCT = pct.IDPhieuTraCT,
                            IDPhieuTra = pct.IDPhieuTra,
                            IDSachCT = pct.IDSachCT,
                            SoLuong = pct.SoLuong,
                            GhiChu = pct.GhiChu,
                            TenDocGia = dg.Ten,
                            TenSach = sa.TenSach
                        };
            return query.ToList();
        }

        public List<T> GetRecords<T>()
        {
            List<T> records = new List<T>();
            if (typeof(T) == typeof(SachCT))
            {
                return _dBContext.SachCT.ToList() as List<T>;
            }
            else if (typeof(T) == typeof(PhieuTra))
            {
                return _dBContext.PhieuTra.ToList() as List<T>;
            }
            throw new NotImplementedException();
        }

        public void UndoSCT(int idsct)
        {
            var exobj = _dBContext.SachCT.FirstOrDefault(c => c.IDSachCT == idsct);

            if (exobj != null)
            {
                exobj.SoLuong -= 1;
                _dBContext.SachCT.Update(exobj);
                _dBContext.SaveChanges();
            }
        }

        public bool Update(int Id, PhieuTraCT obj, int iddg, int idsct)// lỗi
        {
            var exobj = _dBContext.PhieuTraCT.FirstOrDefault(c => c.IDPhieuTraCT == Id);
            if (exobj != null)
            {
                exobj.IDSachCT = obj.IDSachCT;
                exobj.IDPhieuTra = obj.IDPhieuTra;
                exobj.GhiChu = obj.GhiChu;

                var pm = _dBContext.PhieuTra.FirstOrDefault(c => c.IDPhieuTra == iddg);//idphieumuon == iddg
                if (pm != null)
                {
                    var phx = _dBContext.QuanLyMuonSach.FirstOrDefault(c => c.IDDocGia == pm.IDDocGia && c.IDSachCT == obj.IDSachCT);
                    if (phx != null)
                    {
                        //phx = new QuanLyMuonSach();
                        phx.IDSachCT = obj.IDSachCT;
                        phx.IDDocGia = pm.IDDocGia;

                        var sct = _dBContext.SachCT.FirstOrDefault(c => c.IDSachCT == idsct);
                        if (sct.SoLuong > 0)
                        {
                            UpdateSCT(obj.IDSachCT);
                            UndoSCT(idsct);
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                    _dBContext.QuanLyMuonSach.Update(phx);

                }
                else
                {
                    return false;
                }
                _dBContext.PhieuTraCT.Update(exobj);
            }
            else
            {
                return false;
            }

            _dBContext.SaveChanges();
            return true;
        }

        public void UpdateSCT(int idsct)
        {
            var exobj = _dBContext.SachCT.FirstOrDefault(c => c.IDSachCT == idsct);

            if (exobj != null)
            {
                exobj.SoLuong += 1;
                _dBContext.SachCT.Update(exobj);
                _dBContext.SaveChanges();
            }
        }
    }
}
