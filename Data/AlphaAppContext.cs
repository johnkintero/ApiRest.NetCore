using Alpha.Servicios.Models;
using Microsoft.EntityFrameworkCore;

namespace Alpha.Servicios.Data
{
    public class AlphaAppContext : DbContext
    {
        public AlphaAppContext(DbContextOptions<AlphaAppContext> opt): base(opt)
        {

        }
        public DbSet<Usuario> Usuario {get; set;}
        
    }
    
}