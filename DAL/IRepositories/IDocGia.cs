using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IDocGia
    {
        List<DocGia> GetAll(string Search, string Type);
        public DocGia Create(DocGia obj);
        public void Update(int Id, DocGia obj);
        public void Delete(int Id);
    }
}
