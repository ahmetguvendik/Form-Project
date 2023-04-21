using Form_Project.Data.Contexts;
using Form_Project.Data.Entities;
using Form_Project.Interfaces;
using Form_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Form_Project.Repositories
{
    public class UserRepository : IUser
    {
        private readonly FormContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserRepository(FormContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<CreateUserModel> CreateUserAsync(CreateUserModel model)
        {
            var appUser = new AppUser { UserName = model.UserName };
            var result = await _userManager.CreateAsync(appUser,model.Password);
            return model;
   
        }

        public Task<SignInUserModel> SignInUserAsync(SignInUserModel model)
        {
            throw new NotImplementedException();
        }

        public Task SignOut()
        {
            throw new NotImplementedException();
        }
    }
}
