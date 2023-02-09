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
    public class DALSecretary
    {
        public static List<EntitySecretary> SecretaryListesi()
        {
            List<EntitySecretary> secretaryList = new List<EntitySecretary>();
            SqlCommand secretaryBaglanti = new SqlCommand("Select * from Secretary", Baglanti.baglanti);
            if (secretaryBaglanti.Connection.State != ConnectionState.Open) { secretaryBaglanti.Connection.Open(); }
            SqlDataReader dr = secretaryBaglanti.ExecuteReader();
            while (dr.Read())
            {
                EntitySecretary secretary = new EntitySecretary();
                secretary.SecretaryID = Convert.ToInt32(dr["secretaryID"]);
                secretary.NumberID = Convert.ToString(dr["numberID"]);
                secretary.FirstName = Convert.ToString(dr["firstName"]);
                secretary.LastName = Convert.ToString(dr["lastName"]);
                secretary.Password = Convert.ToString(dr["password"]);
                secretary.PhoneNumber = Convert.ToString(dr["phoneNumber"]);
                secretaryList.Add(secretary);
            }
            dr.Close();
            return secretaryList;
        }
        public static int SecretaryGiris(EntitySecretary p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            SqlCommand secretaryBaglanti = new SqlCommand("Select * from Secretary where numberID='" + p.NumberID + "' AND password='" + p.Password + "'", Baglanti.baglanti);
            SqlDataReader dr = secretaryBaglanti.ExecuteReader();

            if (dr.Read())
            {
                EntitySecretary secretary = new EntitySecretary();
                secretary.SecretaryID = Convert.ToInt32(dr["secretaryID"]);
                secretary.NumberID = Convert.ToString(dr["numberID"]);
                secretary.FirstName = Convert.ToString(dr["firstName"]);
                secretary.LastName = Convert.ToString(dr["lastName"]);
                secretary.Password = Convert.ToString(dr["password"]);
                secretary.PhoneNumber = Convert.ToString(dr["phoneNumber"]);

                dr.Close();
                return 1;
            }
            else
            {
                dr.Close();
                return 2;
            }
        }
        public static int SecretaryEkle(EntitySecretary p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            SqlCommand secretaryBaglanti = new SqlCommand("insert into Secretary (firstName,lastName,numberID,password,phoneNumber) values (@firstName,@lastName,@numberID,@password,@phoneNumber)", Baglanti.baglanti);

            secretaryBaglanti.Parameters.AddWithValue("@firstName", p.FirstName);
            secretaryBaglanti.Parameters.AddWithValue("@lastName", p.LastName);
            secretaryBaglanti.Parameters.AddWithValue("@numberID", p.NumberID);
            secretaryBaglanti.Parameters.AddWithValue("@password", p.Password);
            secretaryBaglanti.Parameters.AddWithValue("@phoneNumber", p.PhoneNumber);
            return secretaryBaglanti.ExecuteNonQuery();
        }
        public static bool SecretarySil(int p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            SqlCommand secretaryBaglanti = new SqlCommand("delete from Secretary where secretaryID = @secretaryID", Baglanti.baglanti);

            if (secretaryBaglanti.Connection.State != ConnectionState.Open) { secretaryBaglanti.Connection.Open(); }

            secretaryBaglanti.Parameters.AddWithValue("@secretaryID", p);
            return secretaryBaglanti.ExecuteNonQuery() > 0;
        }
        public static bool SecretaryGuncelle(EntitySecretary p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            SqlCommand secretaryBaglanti = new SqlCommand("update Secretary set firstName=@firstName,lastName=@lastName,phoneNumber=@phoneNumber,password=@password where secretaryID = @secretaryID", Baglanti.baglanti);

            if (secretaryBaglanti.Connection.State != ConnectionState.Open) { secretaryBaglanti.Connection.Open(); }

            secretaryBaglanti.Parameters.AddWithValue("@secretaryID", p.SecretaryID);
            secretaryBaglanti.Parameters.AddWithValue("@firstName", p.FirstName);
            secretaryBaglanti.Parameters.AddWithValue("@lastName", p.LastName);
            secretaryBaglanti.Parameters.AddWithValue("@phoneNumber", p.PhoneNumber);
            secretaryBaglanti.Parameters.AddWithValue("@password", p.Password);

            return secretaryBaglanti.ExecuteNonQuery() > 0;
        }
        public static EntitySecretary SecretaryGuncellePersonelListele(EntitySecretary p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            EntitySecretary secretary = new EntitySecretary();
            SqlCommand secretaryBaglanti = new SqlCommand("Select * from Secretary where secretaryID=" + p.SecretaryID, Baglanti.baglanti);
            SqlDataReader dr = secretaryBaglanti.ExecuteReader();

            if (dr.Read())
            {
                secretary.SecretaryID = Convert.ToInt32(dr["secretaryID"]);
                secretary.NumberID = Convert.ToString(dr["numberID"]);
                secretary.FirstName = Convert.ToString(dr["firstName"]);
                secretary.LastName = Convert.ToString(dr["lastName"]);
                secretary.Password = Convert.ToString(dr["password"]);
                secretary.PhoneNumber = Convert.ToString(dr["phoneNumber"]);
            }
            dr.Close();
            return secretary;
        }
        public static EntitySecretary SecretaryBilgiTut(EntitySecretary p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            EntitySecretary secretary = new EntitySecretary();
            SqlCommand secretaryBaglanti = new SqlCommand("Select * from Secretary where numberID=" + p.NumberID + "AND password=" + p.Password, Baglanti.baglanti);
            SqlDataReader dr = secretaryBaglanti.ExecuteReader();

            if (dr.Read())
            {
                secretary.SecretaryID = Convert.ToInt32(dr["secretaryID"]);
                secretary.NumberID = Convert.ToString(dr["numberID"]);
                secretary.FirstName = Convert.ToString(dr["firstName"]);
                secretary.LastName = Convert.ToString(dr["lastName"]);
                secretary.Password = Convert.ToString(dr["password"]);
                secretary.PhoneNumber = Convert.ToString(dr["phoneNumber"]);
            }
            dr.Close();
            return secretary;
        }
        public static int SecretaryTCKontrol(string p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            SqlCommand secretaryBaglanti = new SqlCommand("Select numberID from Secretary where numberID=@numberID", Baglanti.baglanti);
            secretaryBaglanti.Parameters.AddWithValue("@numberID", p);
            SqlDataReader dr = secretaryBaglanti.ExecuteReader();

            if (dr.Read())
            {
                EntitySecretary secretary = new EntitySecretary();
                secretary.NumberID = Convert.ToString(dr["numberID"]);

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
