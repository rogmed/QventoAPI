using QventoAPI.Data;
using QventoAPI.Dto;

namespace QventoAPI
{
    public class QventoMapper
    {
        public Qvento MaptoQvento(QventoDto dto)
        {
            Qvento qvento = new Qvento();

            qvento.CreatedBy = dto.CreatedBy;
            qvento.Title = dto.Title;
            qvento.DateOfQvento = dto.DateOfQvento;
            qvento.Status = dto.Status;
            qvento.Description = dto.Description;
            qvento.Location = dto.Location;

            return qvento;
        }

        public QventoDto MapToDto(Qvento qvento)
        {
            QventoDto dto = new QventoDto();

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
    }
}
