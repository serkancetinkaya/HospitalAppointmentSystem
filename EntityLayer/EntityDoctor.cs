using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityDoctor
    {
        private int doctorID;
        private string numberID;
        private string firstName;
        private string lastName;
        private string password;
        private string phoneNumber;
        private int branchID;

        public int DoctorID { get => doctorID; set => doctorID = value; }
        public string NumberID { get => numberID; set => numberID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Password { get => password; set => password = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public int BranchID { get => branchID; set => branchID = value; }
    }
}
