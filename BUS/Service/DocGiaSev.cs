using BUS.IService;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class DocGiaSev : IDocGiaSev
    {
        DocGiaRepo _repo;
        public DocGiaSev()
        {
            _repo = new();
        }
        public DocGia Create(DocGia obj)
        {
            return _repo.Create(obj);
            throw new NotImplementedException();
        }

        public void Delete(int obj)
        {
            _repo.Delete(obj);
        }


        public List<DocGia> GetAll(string Search, string Type)
        {
            return _repo.GetAll(Search, Type);
            throw new NotImplementedException();
        }

        public void Update(int Id, DocGia obj)
        {
            _repo.Update(Id, obj);
        }
    }
}
