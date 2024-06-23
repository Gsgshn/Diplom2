using Microsoft.AspNetCore.Identity;

namespace Diplom.Data
{
    public class User : IdentityUser<Guid>
    {
        
        public string Name { get; set; }
        public Guid? AppId { get; set; }
        public App? App { get; set; } 
    }
}
