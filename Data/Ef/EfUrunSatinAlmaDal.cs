using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Abstract;
using Data.Repository;
using Entities.Abstract;

namespace Data.Ef
{
    public class EfUrunSatinAlmaDal : GenericRepository<UrunSatinAlma>, IUrunSatinAlmaDal
    {
    }
}
