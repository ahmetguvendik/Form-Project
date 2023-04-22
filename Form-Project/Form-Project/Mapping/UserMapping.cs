using AutoMapper;
using Form_Project.Data.Entities;
using Form_Project.Models;

namespace Form_Project.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<SignInUserModel, AppUser>();
            CreateMap<AppUser, SignInUserModel>();
        }
    }
}
