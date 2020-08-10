using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Entities
{
    public class HaberContext : DbContext
    {
        public HaberContext() : base("HaberDataBase")
        {
            //Database.SetInitializer(new DataInitializer());
        }

        public DbSet<Haber> Haberler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Log> Loglar { get; set; }
        public DbSet<IpAdresses> ipadresses { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
