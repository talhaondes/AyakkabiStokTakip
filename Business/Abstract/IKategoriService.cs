using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Business.Abstract
{
    public interface IKategoriService
    {
        List<Kategori> GetAll();
        Kategori GetById(int id);
        void KategoriAdd(Kategori kategori);
        void KategoriUpdate(Kategori kategori);
        void KategoriDelete(Kategori kategori);
    }
}
