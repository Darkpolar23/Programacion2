using Microsoft.EntityFrameworkCore;

namespace APIrestaurante.Models
{
    public class Pedidosmodel
    {

        public class Cliente
        {
            public Guid Id { get; set; }
            public required string? full_nombre { get; set; }
            public string? Numeropedido { get; set; }
            public required string? Detallespedidos { get; set; }
            public decimal? Costopedido { get; set; }
            public DateOnly Fechapedido { get; set; }

        }
    }
}
