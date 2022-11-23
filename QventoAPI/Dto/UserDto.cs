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
}
