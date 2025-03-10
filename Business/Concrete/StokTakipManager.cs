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
    public class StokTakipManager : IStokTakipService
    {
        IStokTakipDal _stokTakipDal;

        public StokTakipManager(IStokTakipDal stokTakipDal)
        {
            _stokTakipDal = stokTakipDal;
        }

        public List<StokTakip> GetAll()
        {
            return _stokTakipDal.GetAll();
        }

        public StokTakip GetById(int id)
        {
            return _stokTakipDal.Get(x => x.StokTakipId == id); 
        }

        public void StokTakipAdd(StokTakip stokTakip)
        {
            _stokTakipDal.Add(stokTakip);
        }

        public void StokTakipDelete(StokTakip stokTakip)
        {
            _stokTakipDal.Delete(stokTakip);    
        }

        public void StokTakipUpdate(StokTakip stokTakip)
        {
            _stokTakipDal.Update(stokTakip);    
        }
    }
}
