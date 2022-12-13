using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using QventoAPI.Data;
using QventoAPI.Dto;
using System.Reflection;

namespace QventoAPI.Facades
{
    public class QventoFacade
    {
        QventodbContext context;

        public QventoFacade(QventodbContext context)
        {
            this.context = context;
        }

        public string? Get(int qventoId)
        {
            var qvento = context.Qventos
                .Include(u => u.CreatedByNavigation)
                .Include(i => i.Invitations)
                .ThenInclude(u => u.User)
                .SingleOrDefault(x => x.QventoId == qventoId);

            string json = JsonConvert.SerializeObject(qvento, new JsonSerializerSettings { Formatting = Formatting.Indented });

            return json;
        }

        public List<Qvento> GetAll()
        {
            var qventos = context.Qventos.ToList();
            return qventos;
        }

        public bool Save(ref Qvento qvento)
        {
            User? user = QventoCreator(qvento);
            if (user == null)
                return false;

            qvento.CreatedByNavigation = user;

            var now = DateTime.Now;
            qvento.DateCreated = new DateTime(
                now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);

            qvento.Status = "A";

            var entity = context.Qventos.Add(qvento).Entity;
            context.SaveChanges();

            qvento = entity;

            return entity != null;
        }

        public bool Delete(int qventoId)
        {
            var entity = context.Qventos.SingleOrDefault(x => x.QventoId == qventoId);

            if (entity == null)
                return false;

            context.Qventos.Remove(entity);
            context.SaveChanges();

            return true;
        }

        public bool Update(ref Qvento? qvento, int qventoId, NewQventoDto dto)
        {
            Qvento? entity = context.Qventos.SingleOrDefault(x => x.QventoId == qventoId);

            if (entity == null)
                return false;

            if (!dto.Title.IsNullOrEmpty())
                entity.Title = dto.Title;

            if (!dto.Description.IsNullOrEmpty())
                entity.Description = dto.Description;

            if (dto.DateOfQvento != DateTime.MinValue)
                entity.DateOfQvento = dto.DateOfQvento;

            if (!dto.Location.IsNullOrEmpty())
                entity.Location = dto.Location;

            if (context.SaveChanges() == 1)
            {
                qvento = entity;
                return true;
            }

            return false;
        }

        public List<Qvento> GetCreatedByUser(int userId)
        {
            var qventos = context.Qventos.Where(
                x => x.CreatedBy == userId).ToList();

            return qventos;
        }

        public string GetRelevantToUser(string tempToken)
        {
            var user = context.Users.FirstOrDefault(x => x.TempToken == tempToken);

            var qventos = context.Qventos
                .Include(u => u.CreatedByNavigation)
                .Where((x => (x.CreatedBy == user.UserId || x.Invitations.Any(y => y.UserId == user.UserId)) && x.Status == "A")).ToList();

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                //ContractResolver = new CustomResolver(),
                //PreserveReferencesHandling = PreserveReferencesHandling.None,
                //ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(qventos, new JsonSerializerSettings{ Formatting = Formatting.Indented });

            return json;
        }

        private User? QventoCreator(Qvento qvento)
        {
            User? user = null;

            int userId = qvento.CreatedBy;

            var result = context.Users.Find(userId);

            if (result != null)
            {
                user = result;
            }

            return user;
        }
    }
}

class CustomResolver : DefaultContractResolver
{
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        JsonProperty prop = base.CreateProperty(member, memberSerialization);

        if (prop.DeclaringType == typeof(User))
        {
            prop.ShouldSerialize = obj => false;
        }

        return prop;
    }
}
