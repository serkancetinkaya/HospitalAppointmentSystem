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
    public class DALDiseased
    {
        public static List<EntityDiseased> DiseasedListesi()
        {
            List<EntityDiseased> diseasedList = new List<EntityDiseased>();
            SqlCommand diseasedBaglanti = new SqlCommand("Select * from Diseased", Baglanti.baglanti);
            if (diseasedBaglanti.Connection.State != ConnectionState.Open) { diseasedBaglanti.Connection.Open(); }
            SqlDataReader dr = diseasedBaglanti.ExecuteReader();
            while (dr.Read())
            {
                EntityDiseased diseased = new EntityDiseased();
                diseased.DiseasedID = Convert.ToInt32(dr["diseasedID"]);
                diseased.NumberID = Convert.ToString(dr["numberID"]);
                diseased.FirstName = Convert.ToString(dr["firstName"]);
                diseased.LastName = Convert.ToString(dr["lastName"]);
                diseased.PhoneNumber = Convert.ToString(dr["phoneNumber"]);
                diseased.Mail = Convert.ToString(dr["mail"]);
                diseasedList.Add(diseased);
            }
            dr.Close();
            return diseasedList;
        }
        public static int DiseasedEkle(EntityDiseased p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            SqlCommand diseasedBaglanti = new SqlCommand("insert into Diseased (numberID,firstName,lastName,phoneNumber,mail) values (@numberID,@firstName,@lastName,@phoneNumber,@mail)", Baglanti.baglanti);

            diseasedBaglanti.Parameters.AddWithValue("@numberID", p.NumberID);
            diseasedBaglanti.Parameters.AddWithValue("@firstName", p.FirstName);
            diseasedBaglanti.Parameters.AddWithValue("@lastName", p.LastName);
            diseasedBaglanti.Parameters.AddWithValue("@phoneNumber", p.PhoneNumber);
            diseasedBaglanti.Parameters.AddWithValue("@mail", p.Mail);
            return diseasedBaglanti.ExecuteNonQuery();
        }
        public static bool DiseasedSil(int p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            SqlCommand diseasedBaglanti = new SqlCommand("delete from Diseased where diseasedID = @diseasedID", Baglanti.baglanti);

            if (diseasedBaglanti.Connection.State != ConnectionState.Open) { diseasedBaglanti.Connection.Open(); }

            diseasedBaglanti.Parameters.AddWithValue("@diseasedID", p);
            return diseasedBaglanti.ExecuteNonQuery() > 0;
        }
        public static bool DiseasedGuncelle(EntityDiseased p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            SqlCommand diseasedBaglanti = new SqlCommand("update Diseased set firstName=@firstName,lastName=@lastName,phoneNumber=@phoneNumber,mail=@mail where diseasedID = @diseasedID", Baglanti.baglanti);

            if (diseasedBaglanti.Connection.State != ConnectionState.Open) { diseasedBaglanti.Connection.Open(); }

            diseasedBaglanti.Parameters.AddWithValue("@diseasedID", p.DiseasedID);
            diseasedBaglanti.Parameters.AddWithValue("@firstName", p.FirstName);
            diseasedBaglanti.Parameters.AddWithValue("@lastName", p.LastName);
            diseasedBaglanti.Parameters.AddWithValue("@phoneNumber", p.PhoneNumber);
            diseasedBaglanti.Parameters.AddWithValue("@mail", p.Mail);

            return diseasedBaglanti.ExecuteNonQuery() > 0;
        }
        public static EntityDiseased DiseasedGuncelleHastaListele(EntityDiseased p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            EntityDiseased diseased = new EntityDiseased();
            SqlCommand diseasedBaglanti = new SqlCommand("Select * from Diseased where diseasedID=" + p.DiseasedID, Baglanti.baglanti);
            SqlDataReader dr = diseasedBaglanti.ExecuteReader();

            if (dr.Read())
            {
                diseased.DiseasedID = Convert.ToInt32(dr["diseasedID"]);
                diseased.FirstName = Convert.ToString(dr["firstName"]);
                diseased.LastName = Convert.ToString(dr["lastName"]);
                diseased.NumberID = Convert.ToString(dr["numberID"]);
                diseased.PhoneNumber = Convert.ToString(dr["phoneNumber"]);
                diseased.Mail = Convert.ToString(dr["mail"]);
            }
            dr.Close();
            return diseased;
        }
        public static int DiseasedTCKontrol(string p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            SqlCommand diseasedBaglanti = new SqlCommand("Select numberID from Diseased where numberID=@numberID", Baglanti.baglanti);
            diseasedBaglanti.Parameters.AddWithValue("@numberID", p);
            SqlDataReader dr = diseasedBaglanti.ExecuteReader();

            if (dr.Read())
            {
                EntityDiseased diseased = new EntityDiseased();
                diseased.NumberID = Convert.ToString(dr["numberID"]);

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
