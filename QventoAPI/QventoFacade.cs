using Microsoft.EntityFrameworkCore;
using QventoAPI.Data;

namespace QventoAPI
{
    public class QventoFacade
    {
        QventodbContext context = new QventodbContext();

        public bool Save(ref Qvento qvento)
        {
            User? user = QventoCreator(qvento);
            if (user == null)
                return false;

            qvento.CreatedByNavigation = user;

            var now = DateTime.Now;
            qvento.DateCreated = new DateTime(
                now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);

            var entity = context.Qventos.Add(qvento);
            context.SaveChanges();

            if(entity == null)
                return false;

            qvento = entity.Entity;

            return true;
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

        public bool Update(ref Qvento qvento)
        {
            int qventoId = qvento.QventoId;
            Qvento entity = context.Qventos.SingleOrDefault(x => x.QventoId == qventoId);

            if (entity == null)
                return false;

            entity = qvento;
            context.SaveChanges();

            return true;
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
