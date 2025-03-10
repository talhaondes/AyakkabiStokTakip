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
    public class TedarikciManager : ITedarikciService
    {
        ITedarikciDal _tedarikciDal;

        public TedarikciManager(ITedarikciDal tedarikciDal)
        {
            _tedarikciDal = tedarikciDal;
        }

        public List<Tedarikci> GetAll()
        {
            return _tedarikciDal.GetAll();  
        }

        public Tedarikci GetById(int id)
        {
            return _tedarikciDal.Get(x => x.TedarikciId == id);     
        }

        public void TedarikciAdd(Tedarikci tedarikci)
        {
            _tedarikciDal.Add(tedarikci);   
        }

        public void TedarikciDelete(Tedarikci tedarikci)
        {
            _tedarikciDal.Delete(tedarikci);    
        }

        public void TedarikciUpdate(Tedarikci tedarikci)
        {
            _tedarikciDal.Update(tedarikci);
        }
    }
}
