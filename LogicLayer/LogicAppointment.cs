using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;

namespace LogicLayer
{
    public class LogicAppointment
    {
        public static List<EntityAppointment> LLAppointmentListesi()
        {
            return DALAppointment.AppointmentListesi();
        }
        public static int LLAppointmentOlustur(EntityAppointment p)
        {
            return DALAppointment.AppointmentOlustur(p);
        }
        public static bool LLAppointmentSil(int p)
        {
            if (p >= 1) { return DALAppointment.AppointmentSil(p); }
            else { return false; }
        }
        public static EntitySecretary LLAppointmentSecretaryGetir(EntityAppointment p)
        {
            return DALAppointment.AppointmentSecretaryGetir(p);
        }
        public static EntityDoctor LLAppointmentDoctorGetir(EntityAppointment p)
        {
            return DALAppointment.AppointmentDoctorGetir(p);
        }
        public static EntityDiseased LLAppointmentDiseasedGetir(EntityAppointment p)
        {
            return DALAppointment.AppointmentDiseasedGetir(p);
        }
        public static EntityBranch LLAppointmentBranchGetir(EntityAppointment p)
        {
            return DALAppointment.AppointmentBranchGetir(p);
        }
        public static int LLAppointmentTarihiSorgula(DateTime p)
        {
            return DALAppointment.AppointmentTarihiSorgula(p);
        }
    }
}
