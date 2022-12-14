using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace QventoAPI.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }
    }

    public class NewUserDto
    {

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? PasswordHash { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }
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
