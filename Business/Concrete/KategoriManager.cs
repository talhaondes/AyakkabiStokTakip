using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Data.Abstract;
using Entities.Abstract;

namespace Business.Concrete
{
    public class KategoriManager : IKategoriService
    {
        IKategoriDal _ıkategoridal;

        public KategoriManager(IKategoriDal ıkategoridal)
        {
            _ıkategoridal = ıkategoridal;
        }

        public List<Kategori> GetAll()
        {
            return _ıkategoridal.GetAll();
        }

        public Kategori GetById(int id)
        {
            return _ıkategoridal.Get(z => z.KategoriId == id);
        }

        public void KategoriAdd(Kategori kategori)
        {
            _ıkategoridal.Add(kategori);
        }

        public void KategoriDelete(Kategori kategori)
        {
            _ıkategoridal.Delete(kategori);
        }

        public void KategoriUpdate(Kategori kategori)
        {
            _ıkategoridal.Update(kategori);
        }
    }
}
