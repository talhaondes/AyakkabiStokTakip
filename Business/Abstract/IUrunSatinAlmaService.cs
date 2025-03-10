using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Business.Abstract
{
    public interface IUrunSatinAlmaService
    {
        List<UrunSatinAlma> GetAll();
        UrunSatinAlma GetById(int id);
        void UrunSatinAlmaAdd(UrunSatinAlma urunSatinAlma);
        void UrunSatinAlmaUpdate(UrunSatinAlma urunSatinAlma);
        void UrunSatinAlmaDelete(UrunSatinAlma urunSatinAlma);
    }
}
