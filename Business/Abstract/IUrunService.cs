using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Business.Abstract
{
    public interface IUrunService
    {
        List<Urun> GetAll();
        Urun GetById(int id);
        void UrunAdd(Urun urun);
        void UrunUpdate(Urun urun);
        void UrunDelete(Urun urun);
    }
}
