using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;

namespace LogicLayer
{
    public class LogicDoctor
    {
        public static List<EntityDoctor> LLDoctorListesi()
        {
            return DALDoctor.DoctorListesi();
        }
        public static int LLDoctorGiris(EntityDoctor p)
        {
            return DALDoctor.DoctorGiris(p);
        }
        public static int LLDoctorEkle(EntityDoctor p)
        {
            return DALDoctor.DoctorEkle(p);
        }
        public static bool LLDoctorSil(int p)
        {
            if (p >= 1) { return DALDoctor.DoctorSil(p); }
            else { return false; }
        }
        public static bool LLDoctorGuncelle(EntityDoctor p)
        {
            return DALDoctor.DoctorGuncelle(p);
        }
        public static EntityDoctor LLDoctorGuncellePersonelListele(EntityDoctor p)
        {
            return DALDoctor.DoctorGuncellePersonelListele(p);
        }
        public static EntityDoctor LLDoctorBilgiTut(EntityDoctor p)
        {
            return DALDoctor.DoctorBilgiTut(p);
        }
        public static int LLDoctorTCKontrol(string p)
        {
            return DALDoctor.DoctorTCKontrol(p);
        }

        public static int LLBransHastaSayisiCek(EntityBranch p)
        {
            return DALDoctor.BransHastaSayisiCek(p);  
        }
    }
}
