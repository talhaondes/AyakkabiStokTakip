using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Business.Abstract
{
    public interface ITedarikciService
    {
        List<Tedarikci> GetAll();
        Tedarikci GetById(int id);
        void TedarikciAdd(Tedarikci tedarikci);
        void TedarikciUpdate(Tedarikci tedarikci);
        void TedarikciDelete(Tedarikci tedarikci);
    }
}
