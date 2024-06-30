using Microsoft.EntityFrameworkCore;

namespace APIRestaurantepe.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
