namespace Diplom.Data
{
    public class UserApp
    {
        public Guid UserId { get; set; }
        public Guid AppId { get; set; }

        public User User { get; set; }
        public App App { get; set; }
    }
}
