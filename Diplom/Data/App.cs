namespace Diplom.Data
{
    public class App
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; } = [];
    }
}
