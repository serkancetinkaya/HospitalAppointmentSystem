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
    public class DALResult
    {
        public static List<EntityResult> IlgiliDoctorResultListesi(int p)
        {
            List<EntityResult> resultList = new List<EntityResult>();
            SqlCommand resultBaglanti = new SqlCommand("Select * from Result where doctorID=@doctorID", Baglanti.baglanti);
            if (resultBaglanti.Connection.State != ConnectionState.Open) { resultBaglanti.Connection.Open(); }
            resultBaglanti.Parameters.AddWithValue("@doctorID", p);
            SqlDataReader dr = resultBaglanti.ExecuteReader();
            while (dr.Read())
            {
                EntityResult result = new EntityResult();
                result.ResultID = Convert.ToInt32(dr["resultID"]);
                result.AppointmentID = Convert.ToInt32(dr["appointmentID"]);
                result.DoctorID = Convert.ToInt32(dr["doctorID"]);
                result.DiseasedID = Convert.ToInt32(dr["diseasedID"]);
                result.DoctorResult = Convert.ToString(dr["doctorResult"]);
                result.TestResult = Convert.ToString(dr["testResult"]);
                result.Date = Convert.ToDateTime(dr["date"]);
                resultList.Add(result);
            }
            dr.Close();
            return resultList;
        }
        public static List<EntityAppointment> IlgiliDoctorAppointmentListesi(int p)
        {
            List<EntityAppointment> appointmentList = new List<EntityAppointment>();
            SqlCommand appointmentBaglanti = new SqlCommand("Select * from Appointment where doctorID=@doctorID", Baglanti.baglanti);
            if (appointmentBaglanti.Connection.State != ConnectionState.Open) { appointmentBaglanti.Connection.Open(); }
            appointmentBaglanti.Parameters.AddWithValue("@doctorID", p);
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
        public static int ResultEkle(EntityResult p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            SqlCommand resultBaglanti = new SqlCommand("insert into Result (appointmentID,doctorID,diseasedID,doctorResult,testResult,date) values (@appointmentID,@doctorID,@diseasedID,@doctorResult,@testResult,@date)", Baglanti.baglanti);

            resultBaglanti.Parameters.AddWithValue("@appointmentID", p.AppointmentID);
            resultBaglanti.Parameters.AddWithValue("@doctorID", p.DoctorID);
            resultBaglanti.Parameters.AddWithValue("@diseasedID", p.DiseasedID);
            resultBaglanti.Parameters.AddWithValue("@doctorResult", p.DoctorResult);
            resultBaglanti.Parameters.AddWithValue("@testResult", p.TestResult);
            resultBaglanti.Parameters.AddWithValue("@date", p.Date);

            return resultBaglanti.ExecuteNonQuery();
        }
        public static EntityDiseased ResultDiseasedGetir(int p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            EntityDiseased diseased = new EntityDiseased();
            SqlCommand diseasedBaglanti = new SqlCommand("select firstName,lastName,phoneNumber,mail from Diseased where diseasedID=@diseasedID", Baglanti.baglanti);
            diseasedBaglanti.Parameters.AddWithValue("@diseasedID", p);

            SqlDataReader dr = diseasedBaglanti.ExecuteReader();

            if (dr.Read())
            {
                diseased.FirstName = Convert.ToString(dr["firstName"]);
                diseased.LastName = Convert.ToString(dr["lastName"]);
                diseased.PhoneNumber = Convert.ToString(dr["phoneNumber"]);
                diseased.Mail = Convert.ToString(dr["mail"]);

            }
            dr.Close();
            return diseased;
        }
        public static bool ResultAppointmentSil(int p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            SqlCommand resultBaglanti = new SqlCommand("delete from Appointment where appointmentID = @appointmentID", Baglanti.baglanti);

            if (resultBaglanti.Connection.State != ConnectionState.Open) { resultBaglanti.Connection.Open(); }

            resultBaglanti.Parameters.AddWithValue("@appointmentID", p);
            return resultBaglanti.ExecuteNonQuery() > 0;
        }
    }
}
