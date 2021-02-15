using BirKelimeBirIslem.DAL;
using BirKelimeBirIslem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class KelimeController
    {
        KelimeDAL kelimeDAL;

        public KelimeController()
        {
            kelimeDAL = new KelimeDAL();
        }

        public bool Add(KelimeModel kelime)
        {
            try
            {
                return kelimeDAL.Insert(kelime);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(KelimeModel kelime)
        {
            return kelimeDAL.Delete(kelime);
        }

        public bool DeleteByID(int kelimeID)
        {
            KelimeModel kelime = kelimeDAL.GetByID(kelimeID);
            return kelimeDAL.Delete(kelime);
        }

        public KelimeModel GetKelimeByID(int kelimeID)
        {
            return kelimeDAL.GetByID(kelimeID);
        }

        public List<KelimeModel> GetKelimeList()
        {
            return kelimeDAL.GetAll();
        }

        public List<KelimeModel> GetFilteredList(string param)
        {
            return kelimeDAL.GetAll(a => a.Kelime.StartsWith(param));
        }
    }
}
