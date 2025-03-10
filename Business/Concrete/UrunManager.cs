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
    public class UrunManager : IUrunService
    {
        IUrunDal _urunDal;

        public UrunManager(IUrunDal urunDal)
        {
            _urunDal = urunDal;
        }

        public List<Urun> GetAll()
        {
            return _urunDal.GetAll();
        }

        public Urun GetById(int id)
        {
            return _urunDal.Get(x => x.UrunId == id);   
        }

        public void UrunAdd(Urun urun)
        {
            _urunDal.Add(urun); 
        }

        public void UrunDelete(Urun urun)
        {
            _urunDal.Delete(urun);  
        }

        public void UrunUpdate(Urun urun)
        {
            _urunDal.Update(urun);  
        }
    }
}
