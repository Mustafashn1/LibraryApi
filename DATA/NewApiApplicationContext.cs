using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace APINEW.DATA
{
    public class NewApiApplicationContext : DbContext
    {
        public NewApiApplicationContext(DbContextOptions<NewApiApplicationContext>options)
            :base(options) 
        { 
            
        }
        public virtual DbSet<ToursEntity> Tours { get; set; }
        public virtual DbSet<SoldToursEntity> SoldTours { get; set; }
    }
}
