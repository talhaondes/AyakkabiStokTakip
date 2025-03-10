using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repository;
using Data.Abstract;
using Entities.Abstract;
namespace Data.Ef
{
    public class EfStokTakipDal:GenericRepository<StokTakip>, IStokTakipDal
    {
    }
}
