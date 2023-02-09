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
    public class DALBranch
    {
        public static List<EntityBranch> BranchListesi()
        {
            List<EntityBranch> branchList = new List<EntityBranch>();
            SqlCommand branchBaglanti = new SqlCommand("Select * from Branch", Baglanti.baglanti);
            if (branchBaglanti.Connection.State != ConnectionState.Open) { branchBaglanti.Connection.Open(); }
            SqlDataReader dr = branchBaglanti.ExecuteReader();
            while (dr.Read())
            {
                EntityBranch branch = new EntityBranch();
                branch.BranchID = Convert.ToInt32(dr["branchID"]);
                branch.BranchName = Convert.ToString(dr["branchName"]);
                branchList.Add(branch);
            }
            dr.Close();
            return branchList;
        }
        public static List<EntityDoctor> IlgiliBranchDoctorListele(EntityBranch p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            List<EntityDoctor> doctorList = new List<EntityDoctor>();
            SqlCommand branchBaglanti = new SqlCommand("Select * from Doctor where branchID = (select branchID from Branch where branchName = @branchName)", Baglanti.baglanti);
            if (branchBaglanti.Connection.State != ConnectionState.Open) { branchBaglanti.Connection.Open(); }
            branchBaglanti.Parameters.AddWithValue("@branchName", p.BranchName);
            SqlDataReader dr = branchBaglanti.ExecuteReader();

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
        public static EntityBranch IlgiliBranchAdiGetir(int p)
        {
            Baglanti.baglanti.Close();
            Baglanti.baglanti.Open();
            EntityBranch branch = new EntityBranch();
            SqlCommand branchBaglanti = new SqlCommand("select branchName from Branch where branchID=@branchID", Baglanti.baglanti);
            branchBaglanti.Parameters.AddWithValue("@branchID", p);
            SqlDataReader dr = branchBaglanti.ExecuteReader();

            if (dr.Read())
            {
                branch.BranchName = Convert.ToString(dr["branchName"]);
            }
            dr.Close();
            return branch;
        }
    }
}
