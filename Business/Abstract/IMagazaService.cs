using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Business.Abstract
{
    public interface IMagazaService
    {
        List<Magaza> GetAll();
        Magaza GetById(int id);
        void MagazaAdd(Magaza magaza);
        void MagazaUpdate(Magaza magaza);
        void MagazaDelete(Magaza magaza);
    }
}
