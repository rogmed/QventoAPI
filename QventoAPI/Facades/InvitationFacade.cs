using QventoAPI.Data;
using QventoAPI.Dto;

namespace QventoAPI.Facades
{
    public class InvitationFacade
    {
        QventodbContext context;

        public InvitationFacade(QventodbContext context)
        {
            this.context = context;
        }

        public Invitation? Get(InvitationDto dto)
        {
            var qventoId = dto.QventoId;
            var userId = dto.UserId;
            return context.Invitations.FirstOrDefault(
                x => x.QventoId == qventoId && x.UserId == userId);
        }

        public bool Save(ref Invitation invitation)
        {
            invitation.Status = "P";

            var entity = context.Invitations.Add(invitation).Entity;
            context.SaveChanges();

            invitation = entity;

            return entity != null;
        }

        public bool Exists(ref Invitation invitation, ref MessageDto message)
        {
            var qventoId = invitation.QventoId;
            var userId = invitation.UserId;
            var foundInvitation = context.Invitations.FirstOrDefault(
                x => x.QventoId == qventoId && x.UserId == userId);

            if (foundInvitation == null)
            {
                return false;
            }

            string status = foundInvitation.Status switch
            {
                "P" => "pendiente",
                "A" => "aceptada",
                "R" => "rechazada",
                _ => ""
            };

            message.Value = $"Este usuario ya tiene una invitación {status} a este evento";

            return true;
        }

        public bool Update(ref Invitation invitation, InvitationDto dto, ref MessageDto message)
        {
            if (invitation.Status != "P" && dto.Status == "P")
            {
                message.Value = "No se puede volver a estado pendiente una vez " +
                    "aceptada o rechazada una invitacion.";
                return false;
            }

            invitation.Status = dto.Status;
            int changes = context.SaveChanges();

            return changes == 1;
        }
    }
}
