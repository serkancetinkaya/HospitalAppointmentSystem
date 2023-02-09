using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;

namespace LogicLayer
{
    public class LogicSecretary
    {
        public static List<EntitySecretary> LLSecreterListesi()
        {
            return DALSecretary.SecretaryListesi();
        }
        public static int LLSecretaryGiris(EntitySecretary p)
        {
            return DALSecretary.SecretaryGiris(p);
        }
        public static int LLSecretaryEkle(EntitySecretary p)
        {
            return DALSecretary.SecretaryEkle(p);
        }
        public static bool LLSecretarySil(int p)
        {
            if (p >= 1) { return DALSecretary.SecretarySil(p); }
            else { return false; }
        }
        public static bool LLSecretaryGuncelle(EntitySecretary p)
        {
            return DALSecretary.SecretaryGuncelle(p);
        }
        public static EntitySecretary LLSecretaryGuncellePersonelListele(EntitySecretary p)
        {
            return DALSecretary.SecretaryGuncellePersonelListele(p);
        }
        public static EntitySecretary LLSecretaryBilgiTut(EntitySecretary p)
        {
            return DALSecretary.SecretaryBilgiTut(p);
        }
        public static int LLSecretaryTCKontrol(string p)
        {
            return DALSecretary.SecretaryTCKontrol(p);
        }
    }
}
