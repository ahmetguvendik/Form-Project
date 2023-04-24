using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class FormManager : IFormService
    {
        IFormDal _formDal;
        public FormManager(IFormDal formDal)
        {
            _formDal = formDal;
        }

        public void Delete(Form entity)
        {
           _formDal.Delete(entity);
        }

        public List<Form> GetAll()
        {
            return _formDal.GetAll();
        }

        public void Insert(Form entity)
        {
           _formDal.Insert(entity);
        }

        public void Update(Form entity)
        {
            _formDal.Update(entity);
        }
    }
}
