using Microsoft.AspNetCore.Identity;

namespace Diplom.Data
{
    public class User : IdentityUser<Guid>
    {
        
        public string Name { get; set; }

        public List<UserApp>? UserApp { get; set; }
    }
}
