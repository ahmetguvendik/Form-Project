using AutoMapper;
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
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;


        public UserRepository(FormContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper,RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<CreateUserModel> CreateUserAsync(CreateUserModel model)
        {
            var appUser = new AppUser { UserName = model.UserName };
            var result = await _userManager.CreateAsync(appUser, model.Password);
            if(result.Succeeded)
            {
                var role = await _roleManager.FindByNameAsync("Member");
                if (role == null)
                {
                    var appRole = new AppRole()
                    {
                        Name = "Member"
                    };
                    await _roleManager.CreateAsync(appRole);
                }

                await _userManager.AddToRoleAsync(appUser, "Member");
            }
        
            return model;

        }

        public async Task<SignInUserModel> SignInUserAsync(SignInUserModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            var signInResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if(signInResult.Succeeded)
            {
                var role = await _userManager.GetRolesAsync(user);
                var userId = await _userManager.FindByIdAsync(user.Id.ToString());
                if (role.Contains("Member"))
                {
                    var userMapper = _mapper.Map<SignInUserModel>(user);
                    return userMapper;
                }
            }

            return null;
           


        }

        public Task SignOut()
        {
            throw new NotImplementedException();
        }
    }
}
