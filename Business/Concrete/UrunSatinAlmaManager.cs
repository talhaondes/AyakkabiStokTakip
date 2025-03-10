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
    public class UrunSatinAlmaManager : IUrunSatinAlmaService
    {
        IUrunSatinAlmaDal _urunSatinAlmaDal;

        public UrunSatinAlmaManager(IUrunSatinAlmaDal urunSatinAlmaDal)
        {
            _urunSatinAlmaDal = urunSatinAlmaDal;
        }

        public List<UrunSatinAlma> GetAll()
        {
            return _urunSatinAlmaDal.GetAll();  
        }

        public UrunSatinAlma GetById(int id)
        {
            return _urunSatinAlmaDal.Get(c => c.Id == id);

        }

        public void UrunSatinAlmaAdd(UrunSatinAlma urunSatinAlma)
        {
            _urunSatinAlmaDal.Add(urunSatinAlma);
        }

        public void UrunSatinAlmaDelete(UrunSatinAlma urunSatinAlma)
        {
            _urunSatinAlmaDal.Delete(urunSatinAlma);    
        }

        public void UrunSatinAlmaUpdate(UrunSatinAlma urunSatinAlma)
        {
            _urunSatinAlmaDal.Update(urunSatinAlma);
        }
    }
}
