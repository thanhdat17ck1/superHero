using SuperHeroApiDotNet7.Entity.User;

namespace SuperHeroApiDotNet7.Models
{
    public class UserModel
    {
        private readonly DataContext _context;
        public UserModel(DataContext context)
        {
            _context = context;
        }

        public Task<List<UserEntity>> Register(User user)
        {
            var Post = _context.User.FromSqlRaw("sp_user {0}, {1}, {2}", "Post", user.UserName, user.PasswordHash).ToListAsync();
            return Post;
        }

        public async Task<string> GetUserByUsername(string userName)
        {
            var users = await _context.User
            .FromSqlRaw("sp_user {0}, {1}, {2}", "GetUserByUsername", userName, "aa")
            .ToListAsync();

            var user = users.FirstOrDefault();

            if (user != null)
            {
                return user.PasswordHash;
            }

            // Trả về giá trị mặc định nếu không tìm thấy người dùng
            return "null";
        }
    }
}
