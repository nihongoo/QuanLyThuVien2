using DAL.Context;
using DAL.IRepositories;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PhieuMCT : IPhieuMuonCT
    {
        DBContext _dBContext;
        public PhieuMCT()
        {
            _dBContext = new();
        }
        public bool Create(PhieuMuonCT obj)
        {
            var exobj = _dBContext.PhieuMuonCT.FirstOrDefault(c => c.IDPhieuMuonCT == obj.IDPhieuMuonCT);
            if (exobj != null)
            {
                exobj.IDPhieuMuon = obj.IDPhieuMuon;
                exobj.IDSachCT = obj.IDSachCT;
                exobj.SoLuong = obj.SoLuong;
                exobj.GhiChu = obj.GhiChu;
                exobj.mes = obj.mes;
            }
            else
            {
                var pm = _dBContext.PhieuMuon.FirstOrDefault(c => c.IDPhieuMuon == obj.IDPhieuMuon);
                if (pm != null)
                {
                    //QuanLyMuonSach phx = new QuanLyMuonSach();
                    var phx = _dBContext.QuanLyMuonSach.FirstOrDefault(c => c.IDDocGia == pm.IDDocGia && c.IDSachCT == obj.IDSachCT);
                    if (phx == null)
                    {
                        phx = new QuanLyMuonSach();
                        phx.IDSachCT = obj.IDSachCT;
                        phx.IDDocGia = pm.IDDocGia;
                    }
                    else
                    {
                        return false;
                    }
                    var sct = _dBContext.SachCT.FirstOrDefault(c => c.IDSachCT == obj.IDSachCT);
                    if(sct.SoLuong > 0)
                    {
                        UpdateSCT(obj.IDSachCT);
                    }
                    else
                    {
                        return false;
                    }
                    _dBContext.QuanLyMuonSach.Add(phx);
                }
                else
                {
                    return false;
                }


                // Nếu đối tượng không tồn tại, tạo đối tượng mới
                _dBContext.PhieuMuonCT.Add(obj);
            }

            // Gọi SaveChanges sau khi thực hiện tất cả các thay đổi
            _dBContext.SaveChanges();

            return true;

        }

        public void Delete(int Id)
        {
            var exobj = _dBContext.PhieuMuonCT.FirstOrDefault(c => c.IDPhieuMuonCT == Id);

            if (exobj != null)
            {
                _dBContext.PhieuMuonCT.Remove(exobj);
                _dBContext.SaveChanges();
            }
        }

        public List<PhieuMCTView> GetAll()
        {
            var query = from pct in _dBContext.PhieuMuonCT
                        join pm in _dBContext.PhieuMuon
                        on pct.IDPhieuMuon equals pm.IDPhieuMuon
                        join dg in _dBContext.DocGia
                        on pm.IDDocGia equals dg.IDDocGia
                        join sct in _dBContext.SachCT
                        on pct.IDSachCT equals sct.IDSachCT
                        join sa in _dBContext.Sach
                        on sct.IDSach equals sa.IDSach
                        select new PhieuMCTView
                        {
                            IDPhieuMuonCT = pct.IDPhieuMuonCT,
                            IDPhieuMuon = pct.IDPhieuMuon,
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
            if (typeof(T) == typeof(SachCTView))
            {
                var query = from sct in _dBContext.SachCT
                            join sa in _dBContext.Sach
                            on sct.IDSach equals sa.IDSach
                            select new SachCTView
                            {
                                IDSachCT = sct.IDSachCT,
                                IDSach = sct.IDSach,
                                NgayXB = sct.NgayXB,
                                IDNXB = sct.IDNXB,
                                Gia = sct.Gia,
                                SoLuong = sct.SoLuong,
                                TrangThai = sct.TrangThai,
                                TenSach = sa.TenSach
                            };
                return query.ToList() as List<T>;
            }
            else if (typeof(T) == typeof(PhieuMView))
            {
                var query = from pm in _dBContext.PhieuMuon
                            join dg in _dBContext.DocGia
                            on pm.IDDocGia equals dg.IDDocGia
                            select new PhieuMView
                            {
                                IDPhieuMuon = pm.IDPhieuMuon,
                                IDDocGia = pm.IDDocGia,
                                TenDocGia = dg.Ten
                            };
                return query.ToList() as List<T>;
            }
            throw new NotImplementedException();
        }

        public void UndoSCT(int Id)
        {
            var exobj = _dBContext.SachCT.FirstOrDefault(c => c.IDSachCT == Id);

            if (exobj != null)
            {
                exobj.SoLuong += 1;
                _dBContext.SachCT.Update(exobj);
                _dBContext.SaveChanges();
            }
        }

        public bool Update(int Id, PhieuMuonCT obj, int iddg, int idsct)
        {
            var exobj = _dBContext.PhieuMuonCT.FirstOrDefault(c => c.IDPhieuMuonCT == Id);
            if (exobj != null)
            {
                exobj.IDSachCT = obj.IDSachCT;
                exobj.IDPhieuMuon = obj.IDPhieuMuon;
                exobj.GhiChu = obj.GhiChu;

                var pm = _dBContext.PhieuMuon.FirstOrDefault(c => c.IDPhieuMuon == iddg);//idphieumuon == iddg
                if(pm != null)
                {
                    var phx = _dBContext.QuanLyMuonSach.FirstOrDefault(c => c.IDDocGia == pm.IDDocGia && c.IDSachCT == obj.IDSachCT);//bug
                    if (phx != null)
                    {
                        //phx = new QuanLyMuonSach();
                        phx.IDSachCT = obj.IDSachCT;
                        phx.IDDocGia = pm.IDDocGia;
                        
                        var sct = _dBContext.SachCT.FirstOrDefault(c => c.IDSachCT == obj.IDSachCT);
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
                _dBContext.PhieuMuonCT.Update(exobj);
            }
            else
            {
                return false;
            }

            _dBContext.SaveChanges();
            return true;
        }

        public void UpdateSCT(int Id)
        {
            var exobj = _dBContext.SachCT.FirstOrDefault(c => c.IDSachCT == Id);

            if (exobj != null)
            {
                exobj.SoLuong -= 1;
                _dBContext.SachCT.Update(exobj);
                _dBContext.SaveChanges();
            }
        }
    }
}
