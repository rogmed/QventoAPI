﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QventoAPI.Data;
using System.Runtime.CompilerServices;
using System.Xml;

namespace QventoAPI.Facades
{
    public class QventoFacade
    {
        QventodbContext context = new QventodbContext();

        public Qvento? Get(int qventoId)
        {
            var qvento = context.Qventos.SingleOrDefault(x => x.QventoId == qventoId);
            return qvento;
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

        public bool Update(ref Qvento qvento)
        {
            int qventoId = qvento.QventoId;
            Qvento? entity = context.Qventos.SingleOrDefault(x => x.QventoId == qventoId);

            if (entity == null)
                return false;

            entity = qvento;
            context.SaveChanges();

            return true;
        }

        public List<Qvento> GetCreatedByUser(int userId)
        {
            var qventos = context.Qventos.Where(
                x => x.CreatedBy == userId).ToList();

            return qventos;
        }

        public string GetRelevantToUser(int userId)
        {
            var qventos = context.Qventos.Where(
                (x => (x.CreatedBy == userId || x.Invitations.Any(y => y.UserId == userId)) && x.Status == "A")
                 ).ToList();

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(qventos, settings);

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
