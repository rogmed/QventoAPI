using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QventoAPI.Data;
using QventoAPI.Dto;

namespace QventoAPI.Facades
{
    public class UserFacade
    {
        QventodbContext context = new QventodbContext();

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

        public bool Login(CredentialsDto dto)
        {
            User? user = context.Users.SingleOrDefault(x => x.Email == dto.Email);
            if (user == null)
                return false;

            if(user.PasswordHash == dto.PasswordHash)
                return true;

            return false;
        }

    }
}
