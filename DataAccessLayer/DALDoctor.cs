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
    public class DALDoctor
    {
        public static List<EntityDoctor> DoctorListesi()
        {
            List<EntityDoctor> doctorList = new List<EntityDoctor>();
            SqlCommand doctorBaglanti = new SqlCommand("Select * from Doctor", Baglanti.baglanti);
            if (doctorBaglanti.Connection.State != ConnectionState.Open) { doctorBaglanti.Connection.Open(); }
            SqlDataReader dr = doctorBaglanti.ExecuteReader();
            while (dr.Read())
            {
                EntityDoctor doctor = new EntityDoctor();
                doctor.DoctorID = Convert.ToInt32(dr["doctorID"]);
                doctor.NumberID = Convert.ToString(dr["numberID"]);
                doctor.FirstName = Convert.ToString(dr["firstName"]);
                doctor.LastName = Convert.ToString(dr["lastName"]);
                doctor.Password = Convert.ToString(dr["password"]);
                doctor.PhoneNumber = Convert.ToString(dr["phoneNumber"]);
                doctor.BranchID = Convert.ToInt32(dr["branchID"]);
                doctorList.Add(doctor);
            }
            dr.Close();
            return doctorList;
        }
        public static int DoctorGiris(EntityDoctor p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            SqlCommand doctorBaglanti = new SqlCommand("Select * from Doctor where numberID='" + p.NumberID + "' AND password='" + p.Password + "'", Baglanti.baglanti);
            SqlDataReader dr = doctorBaglanti.ExecuteReader();

            if (dr.Read())
            {
                EntityDoctor doctor = new EntityDoctor();
                doctor.DoctorID = Convert.ToInt16(dr["doctorID"]);
                doctor.NumberID = Convert.ToString(dr["numberID"]);
                doctor.FirstName = Convert.ToString(dr["firstName"]);
                doctor.LastName = Convert.ToString(dr["lastName"]);
                doctor.Password = Convert.ToString(dr["password"]);
                doctor.PhoneNumber = Convert.ToString(dr["phoneNumber"]);
                doctor.BranchID = Convert.ToInt16(dr["branchID"]);

                dr.Close();
                return 1;
            }
            else
            {
                dr.Close();
                return 2;
            }
        }
        public static int DoctorEkle(EntityDoctor p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            SqlCommand doctorBaglanti = new SqlCommand("insert into Doctor (firstName,lastName,numberID,password,phoneNumber,branchID) values (@firstName,@lastName,@numberID,@password,@phoneNumber,@branchID)", Baglanti.baglanti);

            doctorBaglanti.Parameters.AddWithValue("@firstName", p.FirstName);
            doctorBaglanti.Parameters.AddWithValue("@lastName", p.LastName);
            doctorBaglanti.Parameters.AddWithValue("@numberID", p.NumberID);
            doctorBaglanti.Parameters.AddWithValue("@password", p.Password);
            doctorBaglanti.Parameters.AddWithValue("@phoneNumber", p.PhoneNumber);
            doctorBaglanti.Parameters.AddWithValue("@branchID", p.BranchID);

            return doctorBaglanti.ExecuteNonQuery();
        }
        public static bool DoctorSil(int p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            SqlCommand doctorBaglanti = new SqlCommand("delete from Doctor where doctorID = @doctorID", Baglanti.baglanti);

            if (doctorBaglanti.Connection.State != ConnectionState.Open) { doctorBaglanti.Connection.Open(); }

            doctorBaglanti.Parameters.AddWithValue("@doctorID", p);
            return doctorBaglanti.ExecuteNonQuery() > 0;
        }
        public static bool DoctorGuncelle(EntityDoctor p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            SqlCommand doctorBaglanti = new SqlCommand("update Doctor set firstName=@firstName,lastName=@lastName,phoneNumber=@phoneNumber,password=@password,branchID=@branchID where doctorID = @doctorID", Baglanti.baglanti);

            if (doctorBaglanti.Connection.State != ConnectionState.Open) { doctorBaglanti.Connection.Open(); }

            doctorBaglanti.Parameters.AddWithValue("@doctorID", p.DoctorID);
            doctorBaglanti.Parameters.AddWithValue("@firstName", p.FirstName);
            doctorBaglanti.Parameters.AddWithValue("@lastName", p.LastName);
            doctorBaglanti.Parameters.AddWithValue("@phoneNumber", p.PhoneNumber);
            doctorBaglanti.Parameters.AddWithValue("@password", p.Password);
            doctorBaglanti.Parameters.AddWithValue("@branchID", p.BranchID);

            return doctorBaglanti.ExecuteNonQuery() > 0;
        }
        public static EntityDoctor DoctorGuncellePersonelListele(EntityDoctor p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            EntityDoctor doctor = new EntityDoctor();
            SqlCommand doctorBaglanti = new SqlCommand("Select * from Doctor where doctorID=" + p.DoctorID, Baglanti.baglanti);
            SqlDataReader dr = doctorBaglanti.ExecuteReader();

            if (dr.Read())
            {
                doctor.DoctorID = Convert.ToInt32(dr["doctorID"]);
                doctor.NumberID = Convert.ToString(dr["numberID"]);
                doctor.FirstName = Convert.ToString(dr["firstName"]);
                doctor.LastName = Convert.ToString(dr["lastName"]);
                doctor.Password = Convert.ToString(dr["password"]);
                doctor.PhoneNumber = Convert.ToString(dr["phoneNumber"]);
                doctor.BranchID = Convert.ToInt32(dr["branchID"]);
            }
            dr.Close();
            return doctor;
        }
        public static EntityDoctor DoctorBilgiTut(EntityDoctor p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            EntityDoctor doctor = new EntityDoctor();
            SqlCommand doctorBaglanti = new SqlCommand("Select * from Doctor where numberID=" + p.NumberID + "AND password=" + p.Password, Baglanti.baglanti);
            SqlDataReader dr = doctorBaglanti.ExecuteReader();

            if (dr.Read())
            {
                doctor.DoctorID = Convert.ToInt32(dr["doctorID"]);
                doctor.NumberID = Convert.ToString(dr["numberID"]);
                doctor.FirstName = Convert.ToString(dr["firstName"]);
                doctor.LastName = Convert.ToString(dr["lastName"]);
                doctor.Password = Convert.ToString(dr["password"]);
                doctor.PhoneNumber = Convert.ToString(dr["phoneNumber"]);
                doctor.BranchID = Convert.ToInt32(dr["branchID"]);

            }
            dr.Close();
            return doctor;
        }
        public static int DoctorTCKontrol(string p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            SqlCommand doctorBaglanti = new SqlCommand("Select numberID from Doctor where numberID=@numberID", Baglanti.baglanti);
            doctorBaglanti.Parameters.AddWithValue("@numberID", p);
            SqlDataReader dr = doctorBaglanti.ExecuteReader();

            if (dr.Read())
            {
                EntityDoctor doctor = new EntityDoctor();
                doctor.NumberID = Convert.ToString(dr["numberID"]);

                dr.Close();
                return 1;
            }
            else
            {
                dr.Close();
                return 2;
            }
        }

        public static int BransHastaSayisiCek(EntityBranch p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            SqlCommand doctorBaglanti = new SqlCommand("Select Count(doctorID) from Doctor where " +
                "branchID=(select branchID from Branch where branchName=@branch)", Baglanti.baglanti);
            doctorBaglanti.Parameters.AddWithValue("@branch", p.BranchName);
            int sayi = (int)doctorBaglanti.ExecuteScalar();
            return sayi;
        }
    }
}
