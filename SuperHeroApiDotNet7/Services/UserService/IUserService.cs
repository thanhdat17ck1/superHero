namespace SuperHeroApiDotNet7.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> Register(User user);
        Task<string> GetUserByUsername(string username);
    }
}
