using AutoMapper;
using EntityLayer.Concrete;
using Form_Project.Models;

namespace Form_Project.Mapping
{
    public class UserMapping : Profile
    {      
            public UserMapping()
            {
                CreateMap<SignInUserModel, AppUser>();
                CreateMap<AppUser, SignInUserModel>();
                CreateMap<AppUser, CreateUserModel>();
                CreateMap<CreateUserModel, AppUser>();
            }
        
    }
}
