using SuperHeroApiDotNet7.Entity.User;

namespace SuperHeroApiDotNet7.Services.UserService
{
    public interface IUserService
    {
        Task<List<UserEntity>> Register(User user);
        Task<string> GetUserByUsername(string username);
    }
}
