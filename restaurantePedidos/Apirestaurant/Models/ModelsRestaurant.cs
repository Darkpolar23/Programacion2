namespace Apirestaurant.Models
{
    public class ModelsRestaurant
    {
        public Guid Id { get; set; }
        public required string? Full_nombre { get; set; }
        public string? Numeropedido { get; set; }
        public required string? Detallespedidos { get; set; }
        public required decimal Costopedido  { get; set; }
        public DateOnly Fechapedido { get; set; }
    }
}
