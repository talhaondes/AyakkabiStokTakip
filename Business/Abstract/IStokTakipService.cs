using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Business.Abstract
{
    public interface IStokTakipService
    {
        List<StokTakip> GetAll();
        StokTakip GetById(int id);
        void StokTakipAdd(StokTakip stokTakip);
        void StokTakipUpdate(StokTakip stokTakip);
        void StokTakipDelete(StokTakip stokTakip);
    }
}
