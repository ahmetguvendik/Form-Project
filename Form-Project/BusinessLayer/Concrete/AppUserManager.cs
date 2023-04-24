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
    public class AppUserManager : IAppUserService
    {
        IAppUserDal _appUserDal;
        public AppUserManager(IAppUserDal appUserDal) 
        {
            appUserDal = _appUserDal;
        }
        public void Delete(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> GetAll()
        {
            return _appUserDal.GetAll();
        }

        public void Insert(AppUser entity)
        {
           _appUserDal.Insert(entity);
        }

        public void Update(AppUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
