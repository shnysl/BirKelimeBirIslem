using BirKelimeBirIslem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BirKelimeBirIslem.DAL
{
   public class KelimeDAL
    {
        BirKelimeBirIslemDbContext db;

        public KelimeDAL()
        {
            db = new BirKelimeBirIslemDbContext();
        }

        public bool Insert(KelimeModel kelime)
        {
            //db.Entry(kelime).State = System.Data.Entity.EntityState.Added; 
            db.Kelimeler.Add(kelime);
            return db.SaveChanges() > 0;
        }

        public bool Delete(KelimeModel kelime)
        {
            db.Kelimeler.Remove(kelime);
            return db.SaveChanges() > 0;
        }

        public KelimeModel GetByID(int kelimeID)
        {
            KelimeModel kelime = db.Kelimeler.AsNoTracking().SingleOrDefault(a => a.KelimeID == kelimeID);
            return kelime;
        }

        public List<KelimeModel> GetAll(Expression<Func<KelimeModel, bool>> filter = null)
        {
            if (filter == null)
            {
                return db.Kelimeler.AsNoTracking().ToList();
            }
            //GetAll(a=>a.Ad == "Deneme")
            else
            {
                return db.Kelimeler.AsNoTracking().Where(filter).ToList();
                //return db.Kelimeler.Where(a => a.Ad == "Deneme").ToList();
            }
        }
    }
}
