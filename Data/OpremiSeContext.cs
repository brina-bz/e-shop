using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpremiSe.Models;

namespace OpremiSe.Data
{
    public class OpremiSeContext : DbContext
    {
        public OpremiSeContext (DbContextOptions<OpremiSeContext> options)
            : base(options)
        {
        }

        public DbSet<OpremiSe.Models.Produkti> Produkti { get; set; } = default!;
        public DbSet<OpremiSe.Models.KosaricaProdukt> KosaricaProdukt { get; set; } = default!;
    }
}
