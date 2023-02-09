using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;

namespace LogicLayer
{
    public class LogicResult
    {
        public static List<EntityAppointment> LLIlgiliDoctorAppointmentListesi(int p)
        {
            return DALResult.IlgiliDoctorAppointmentListesi(p);
        }
        public static List<EntityResult> LLIlgiliDoctorResultListesi(int p)
        {
            return DALResult.IlgiliDoctorResultListesi(p);
        }
        public static int LLResultEkle(EntityResult p)
        {
            return DALResult.ResultEkle(p);
        }
        public static EntityDiseased LLResultDiseasedGetir(int p)
        {
            return DALResult.ResultDiseasedGetir(p);
        }
        public static bool LLResultAppointmentSil(int p)
        {
            return DALResult.ResultAppointmentSil(p);
        }
    }
}
