using BirKelimeBirIslem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirKelimeBirIslem.DAL
{
   public class KelimeMapping : EntityTypeConfiguration<KelimeModel>
    {
        public KelimeMapping()
        {
            HasKey(a => a.KelimeID);

            Property(a => a.Kelime)
                .HasMaxLength(20)
                .IsRequired();

            Property(a => a.KelimeAnlam)
                .HasMaxLength(500);

        }
    }
}
