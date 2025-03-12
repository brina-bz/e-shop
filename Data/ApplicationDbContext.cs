using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpremiSe.Models;

namespace OpremiSe.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<OpremiSe.Models.Produkti> Produkti { get; set; } = default!;
        public DbSet<OpremiSe.Models.KosaricaProdukt> KosaricaProdukt { get; set; } = default!;
    }
}
