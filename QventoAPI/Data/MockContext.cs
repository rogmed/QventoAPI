using Microsoft.EntityFrameworkCore;

namespace QventoAPI.Data
{
    public class MockContext
    {
        List<Qvento> qventos = new List<Qvento>()
        {
            new Qvento()
            {
                QventoId = 0,
                CreatedBy = 0,
                Title = "Qvento de prueba activo",
                Description = "Esta es la descripción del Qvento de prueba. " +
                "El veloz murciélago hindú comía feliz cardillo y kiwi. La cigüeña " +
                "tocaba el saxofón detrás del palenque de paja.",
                Location = "Calle de la Piruleta 123",
                DateOfQvento = new DateTime(2022, 12, 22),
                DateCreated = DateTime.Now.Date,
                Status = "A"
            },

            new Qvento()
            {
                QventoId = 1,
                CreatedBy = 1,
                Title = "Qvento de prueba cancelado",
                Description = "Le gustaba cenar un exquisito sándwich de jamón con " +
                "zumo de piña y vodka fría. El viejo Señor Gómez pedía queso, kiwi " +
                "y habas, pero le ha tocado un saxofón. Exhíbanse politiquillos " +
                "zafios, con orejas kilométricas y uñas de gavilán.  ",
                Location = "Calle Falsa 456",
                DateOfQvento = new DateTime(2023, 01, 15),
                DateCreated = DateTime.Now.Date,
                Status = "C"
            },

            new Qvento()
            {
                QventoId = 2,
                CreatedBy = 2,
                Title = "Qvento de prueba finalizado",
                Description = "Le gustaba cenar un exquisito sándwich de jamón con " +
                "zumo de piña y vodka fría. El viejo Señor Gómez pedía queso, kiwi " +
                "y habas, pero le ha tocado un saxofón. Exhíbanse politiquillos " +
                "zafios, con orejas kilométricas y uñas de gavilán.  ",
                Location = "Avenida del Pasado -1",
                DateOfQvento = new DateTime(2020, 09, 15),
                DateCreated = new DateTime(2020, 08, 01),
                Status = "F"
            }
        };

        public DbSet<Invitation> Invitations { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<Qvento> Qventos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<User> Users { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Qvento? FindQvento(int qventoId)
        {
            Qvento? qvento = qventos.Find(x => x.QventoId.Equals(qventoId));

            return qvento;
        }

        public List<Qvento> FindAll()
        {
            return qventos;
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
