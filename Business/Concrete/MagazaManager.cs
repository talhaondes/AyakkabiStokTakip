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
    public class MagazaManager : IMagazaService
    {
        IMagazaDal _magazaDal;

        public MagazaManager(IMagazaDal magazaDal)
        {
            _magazaDal = magazaDal;
        }

        public List<Magaza> GetAll()
        {
            return _magazaDal.GetAll();

        }

        public Magaza GetById(int id)
        {
            return _magazaDal.Get(c => c.MagazaId == id);
        }

        public void MagazaAdd(Magaza magaza)
        {
            _magazaDal.Add(magaza);
        }

        public void MagazaDelete(Magaza magaza)
        {
            _magazaDal.Delete(magaza);
        }

        public void MagazaUpdate(Magaza magaza)
        {
            _magazaDal.Update(magaza);  
        }
    }
}
