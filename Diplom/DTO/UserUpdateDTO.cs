using Diplom.Data;
using System.ComponentModel.DataAnnotations;

namespace Diplom.DTO
{
    public class UserUpdateDTO
    {
        
        
        public string? Name { get; set; } = string.Empty;
        
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; } = string.Empty;
        
        [DataType(DataType.Password)]
        public string? Password { get; set; } = string.Empty;
        
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; } = string.Empty;
        public string? App { get; set; } 
    }
}
