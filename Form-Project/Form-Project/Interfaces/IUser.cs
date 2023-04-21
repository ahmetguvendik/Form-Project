using Form_Project.Models;

namespace Form_Project.Interfaces
{
    public interface IUser
    {
        public Task<CreateUserModel> CreateUserAsync(CreateUserModel model);
        public Task<SignInUserModel> SignInUserAsync(SignInUserModel model);
        public Task SignOut();
    }
}
