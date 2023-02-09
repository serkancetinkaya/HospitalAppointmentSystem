using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;

namespace LogicLayer
{
    public class LogicDiseased
    {
        public static List<EntityDiseased> LLDiseasedListesi()
        {
            return DALDiseased.DiseasedListesi();
        }
        public static int LLDiseasedEkle(EntityDiseased p)
        {
            return DALDiseased.DiseasedEkle(p);
        }
        public static bool LLDiseasedSil(int p)
        {
            if (p >= 1) { return DALDiseased.DiseasedSil(p); }
            else { return false; }
        }
        public static bool LLDiseasedGuncelle(EntityDiseased p)
        {
            return DALDiseased.DiseasedGuncelle(p);
        }
        public static EntityDiseased LLDiseasedGuncelleHastaListele(EntityDiseased p)
        {
            return DALDiseased.DiseasedGuncelleHastaListele(p);
        }
        public static int LLDiseasedTCKontrol(string p)
        {
            return DALDiseased.DiseasedTCKontrol(p);
        }
    }
}
