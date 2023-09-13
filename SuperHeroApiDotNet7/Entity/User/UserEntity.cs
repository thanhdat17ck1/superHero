namespace SuperHeroApiDotNet7.Entity.User
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;
    }
}
