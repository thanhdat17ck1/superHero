namespace SuperHeroApiDotNet7.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<User>> Register(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return await _context.User.ToListAsync();
        }
    }
}
