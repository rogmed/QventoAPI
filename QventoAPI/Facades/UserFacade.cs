using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QventoAPI.Data;
using QventoAPI.Dto;

namespace QventoAPI.Facades
{
    public class UserFacade
    {
        QventodbContext context;

        public UserFacade(QventodbContext context)
        {
            this.context = context;
        }

        public User? Get(int userId)
        {
            var user = context.Users.SingleOrDefault(x => x.UserId == userId);
            return user;
        }

        public bool Save(ref User user)
        {
            var email = user.Email;
            if (context.Users.Any(x => x.Email == email))
                return false;

            var savedEntity = context.Users.Add(user).Entity;
            context.SaveChanges();

            user = savedEntity;

            return savedEntity != null;
        }

        public bool Login(ref int userId, CredentialsDto dto)
        {
            User? user = context.Users.SingleOrDefault(x => x.Email == dto.Email);
            if (user == null)
                return false;

            if(user.PasswordHash == dto.PasswordHash)
            {
                userId = user.UserId;
                return true;
            }

            return false;
        }

        public string? GenerateToken(CredentialsDto dto)
        {
            var user = context.Users.FirstOrDefault(x => x.Email.Equals(dto.Email));

            if (user == null)
                return null;

            var allChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var resultToken = new string(
               Enumerable.Repeat(allChar, 16)
               .Select(token => token[random.Next(token.Length)]).ToArray());

            user.TempToken = resultToken.ToString();
            context.SaveChanges();

            return user.TempToken;
        }

        public int Authenticate(string tempToken)
        {
            var user = context.Users.SingleOrDefault(x => x.TempToken.Equals(tempToken));

            if (user == null)
                return -1;

            return user.UserId;
        }
    }
}
