using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BO;

namespace MyTPDojo.Web.Data
{
    public class MyTPDojoWebContext : DbContext
    {
        public MyTPDojoWebContext (DbContextOptions<MyTPDojoWebContext> options)
            : base(options)
        {
        }

        public DbSet<BO.Arme> Arme { get; set; } = default!;

        public DbSet<BO.Samourai>? Samourai { get; set; }
    }
}
