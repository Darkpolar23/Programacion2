using Microsoft.EntityFrameworkCore;
using APIrestaurante.Models;

namespace APIrestaurante.Data
{

    public class AplicationDBcontext : DbContext
    {
        public AplicationDBcontext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Pedidosmodel> Pedidosmodels { get; set; }
    }
}
