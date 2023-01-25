using QventoAPI.Data;
using QventoAPI.Dto;

namespace QventoAPI.Mappers
{
    public class UserMapper
    {
        public User MapToUser(UserDto dto)
        {
            User user = new User();

            user.Name = dto.Name;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.Phone = dto.Phone;
            user.Address = dto.Address;

            return user;
        }

        public User MapToNewUser(NewUserDto dto)
        {
            User user = new User();

            user.Name = dto.Name;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.Phone = dto.Phone;
            user.Address = dto.Address;
            user.PasswordHash = dto.PasswordHash;

            return user;
        }

        public UserDto MapToDto(User user)
        {
            UserDto dto = new UserDto();

            dto.UserId = user.UserId;
            dto.Name = user.Name;
            dto.LastName = user.LastName;
            dto.Email = user.Email;
            dto.Phone = user.Phone;
            dto.Address = user.Address;

            return dto;
        }
    }
}
