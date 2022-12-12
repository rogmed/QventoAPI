using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace QventoAPI.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Phone { get; set; }

        public string? Address { get; set; }
    }

    public class NewUserDto : UserDto
    {
        [Required]
        public string? PasswordHash { get; set; } = null!;
    }

    public class CredentialsDto
    {
        public CredentialsDto(string email, string passwordHash)
        {
            Email = email;
            PasswordHash = passwordHash;
        }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }

}
