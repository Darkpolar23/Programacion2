using Apirestaurant.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;


namespace Apirestaurant.Context
{
    public class AppDBcontext: DbContext
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options): base(options) 
        {
            
        }

        public DbSet<ModelsRestaurant> ModelsRestaurants { get; set; }
    }
}
