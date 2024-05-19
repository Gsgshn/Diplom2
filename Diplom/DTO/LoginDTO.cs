using System.ComponentModel.DataAnnotations;

namespace Diplom.DTO
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty ;
    }
}
