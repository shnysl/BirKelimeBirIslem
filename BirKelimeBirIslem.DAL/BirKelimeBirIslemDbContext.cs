using BirKelimeBirIslem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirKelimeBirIslem.DAL
{
    class BirKelimeBirIslemDbContext:DbContext
    {
        public BirKelimeBirIslemDbContext() : base("Server=DESKTOP-Q21DV4G\\DENEME; Database=BirKelimeBirIslem; uid=sa; pwd=123")
        {

        }

        public DbSet<KelimeModel> Kelimeler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new KelimeMapping());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
