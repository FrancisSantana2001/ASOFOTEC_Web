using ASOFOTEC_Web.Models;
using ASOFOTEC_Web.Services;
using Microsoft.EntityFrameworkCore;

namespace ASOFOTEC_Web.Data
{
    public class AppdbContext: DbContext
    {
        public AppdbContext(DbContextOptions<AppdbContext> options): base (options)
        {   
        }

        public DbSet<ModelUser> ModelUsers { get; set; }
        public DbSet<Systems> Systems { get; set; }

    }
}
