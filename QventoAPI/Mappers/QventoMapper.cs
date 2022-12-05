using QventoAPI.Data;
using QventoAPI.Dto;

namespace QventoAPI.MAppers
{
    public class QventoMapper
    {
        public Qvento MaptoUpdateQvento(UpdateQventoDto dto)
        {
            Qvento qvento = new Qvento();

            qvento.Title = dto.Title ?? "";
            qvento.DateOfQvento = dto.DateOfQvento;
            qvento.Description = dto.Description;
            qvento.Location = dto.Location;

            return qvento;
        }

        public Qvento MaptoQvento(QventoDto dto)
        {
            Qvento qvento = MaptoUpdateQvento(dto);

            qvento.CreatedBy = dto.CreatedBy;

            return qvento;
        }

        public OutgoingQventoDto MapToOutgoingDto(Qvento qvento)
        {
            OutgoingQventoDto dto = new OutgoingQventoDto();

            dto.QventoId = qvento.QventoId;
            dto.CreatedBy = qvento.CreatedBy;
            dto.Title = qvento.Title;
            dto.DateOfQvento = qvento.DateOfQvento;
            dto.Status = qvento.Status;
            dto.Description = qvento.Description;
            dto.Location = qvento.Location;
            dto.DateCreated = qvento.DateCreated;

            return dto;
        }

        public QventoDto MapToDto(Qvento qvento)
        {
            QventoDto dto = new QventoDto();

            dto.CreatedBy = qvento.CreatedBy;
            dto.Title = qvento.Title;
            dto.DateOfQvento = qvento.DateOfQvento;
            dto.Description = qvento.Description;
            dto.Location = qvento.Location;

            return dto;
        }
    }
}
