using SuperHeroApiDotNet7.Entity.User;

namespace SuperHeroApiDotNet7.Repository
{
    public interface IUserRepository
    {
        Task<List<UserEntity>> Register(User user);
        Task<string> GetUserByUsername(string username);
    }
    public class UserRepository : IUserRepository
    {
        UserModel _model;
        public UserRepository(UserModel model)
        {
            _model = model;
        }
        public Task<List<UserEntity>> Register(User user)
        {
            var post = _model.Register(user);
            return post;
        }
        public Task<string> GetUserByUsername(string username)
        {
            var result = _model.GetUserByUsername(username);
            return result;
        }
    }
}
