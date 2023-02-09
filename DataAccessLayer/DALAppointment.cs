using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataAccessLayer
{
    public class DALAppointment
    {
        public static List<EntityAppointment> AppointmentListesi()
        {
            List<EntityAppointment> appointmentList = new List<EntityAppointment>();
            SqlCommand appointmentBaglanti = new SqlCommand("Select * from Appointment", Baglanti.baglanti);
            if (appointmentBaglanti.Connection.State != ConnectionState.Open) { appointmentBaglanti.Connection.Open(); }
            SqlDataReader dr = appointmentBaglanti.ExecuteReader();
            while (dr.Read())
            {
                EntityAppointment appointment = new EntityAppointment();
                appointment.AppointmentID = Convert.ToInt32(dr["appointmentID"]);
                appointment.SecretaryID = Convert.ToInt32(dr["secretaryID"]);
                appointment.DoctorID = Convert.ToInt32(dr["doctorID"]);
                appointment.DiseasedID = Convert.ToInt32(dr["diseasedID"]);
                appointment.BranchID = Convert.ToInt32(dr["branchID"]);
                appointment.Date = Convert.ToDateTime(dr["date"]);
                appointmentList.Add(appointment);
            }
            dr.Close();
            return appointmentList;
        }
        public static int AppointmentOlustur(EntityAppointment p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            SqlCommand appointmentBaglanti = new SqlCommand("insert into Appointment (secretaryID,doctorID,diseasedID,branchID,date) values (@secretaryID,@doctorID,@diseasedID,@branchID,@date)", Baglanti.baglanti);

            appointmentBaglanti.Parameters.AddWithValue("@secretaryID", p.SecretaryID);
            appointmentBaglanti.Parameters.AddWithValue("@doctorID", p.DoctorID);
            appointmentBaglanti.Parameters.AddWithValue("@diseasedID", p.DiseasedID);
            appointmentBaglanti.Parameters.AddWithValue("@branchID", p.BranchID);
            appointmentBaglanti.Parameters.AddWithValue("@date", p.Date);
            return appointmentBaglanti.ExecuteNonQuery();
        }
        public static bool AppointmentSil(int p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            SqlCommand appointmentBaglanti = new SqlCommand("delete from Appointment where appointmentID = @appointmentID", Baglanti.baglanti);

            if (appointmentBaglanti.Connection.State != ConnectionState.Open) { appointmentBaglanti.Connection.Open(); }

            appointmentBaglanti.Parameters.AddWithValue("@appointmentID", p);
            return appointmentBaglanti.ExecuteNonQuery() > 0;
        }
        public static EntitySecretary AppointmentSecretaryGetir(EntityAppointment p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            EntitySecretary secretary = new EntitySecretary();
            SqlCommand secretaryGetirBaglanti = new SqlCommand("select firstName,lastName from Secretary where secretaryID=@secretaryID", Baglanti.baglanti);
            secretaryGetirBaglanti.Parameters.AddWithValue("@secretaryID", p.SecretaryID);
            SqlDataReader dr = secretaryGetirBaglanti.ExecuteReader();

            if (dr.Read())
            {
                secretary.FirstName = Convert.ToString(dr["firstName"]);
                secretary.LastName = Convert.ToString(dr["lastName"]);
            }
            dr.Close();
            return secretary;
        }
        public static EntityDoctor AppointmentDoctorGetir(EntityAppointment p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            EntityDoctor doctor = new EntityDoctor();
            SqlCommand doctorGetirBaglanti = new SqlCommand("select firstName,lastName from Doctor where doctorID=@doctorID", Baglanti.baglanti);
            doctorGetirBaglanti.Parameters.AddWithValue("@doctorID", p.DoctorID);
            SqlDataReader dr = doctorGetirBaglanti.ExecuteReader();

            if (dr.Read())
            {
                doctor.FirstName = Convert.ToString(dr["firstName"]);
                doctor.LastName = Convert.ToString(dr["lastName"]);
            }
            dr.Close();
            return doctor;
        }
        public static EntityDiseased AppointmentDiseasedGetir(EntityAppointment p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            EntityDiseased diseased = new EntityDiseased();
            SqlCommand diseasedGetirBaglanti = new SqlCommand("select firstName,lastName from Diseased where diseasedID=@diseasedID", Baglanti.baglanti);
            diseasedGetirBaglanti.Parameters.AddWithValue("@diseasedID", p.DiseasedID);
            SqlDataReader dr = diseasedGetirBaglanti.ExecuteReader();

            if (dr.Read())
            {
                diseased.FirstName = Convert.ToString(dr["firstName"]);
                diseased.LastName = Convert.ToString(dr["lastName"]);
            }
            dr.Close();
            return diseased;
        }
        public static EntityBranch AppointmentBranchGetir(EntityAppointment p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            EntityBranch branch = new EntityBranch();
            SqlCommand branchGetirBaglanti = new SqlCommand("select branchName from Branch where branchID=@branchID", Baglanti.baglanti);
            branchGetirBaglanti.Parameters.AddWithValue("@branchID", p.BranchID);
            SqlDataReader dr = branchGetirBaglanti.ExecuteReader();

            if (dr.Read())
            {
                branch.BranchName = Convert.ToString(dr["branchName"]);
            }
            dr.Close();
            return branch;
        }
        public static int AppointmentTarihiSorgula(DateTime p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            SqlCommand appointmentbaglanti = new SqlCommand("select date from Appointment where date=@date", Baglanti.baglanti);
            appointmentbaglanti.Parameters.AddWithValue("@date", p);
            SqlDataReader dr = appointmentbaglanti.ExecuteReader();

            if (dr.Read())
            {
                EntityAppointment appointment = new EntityAppointment();
                appointment.Date = Convert.ToDateTime(dr["date"]);

                dr.Close();
                return 1;
            }
            else
            {
                dr.Close();
                return 2;
            }
        }
    }
}
