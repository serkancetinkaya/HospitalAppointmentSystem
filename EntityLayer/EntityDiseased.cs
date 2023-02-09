using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityDiseased
    {
        private int diseasedID;
        private string numberID;
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string mail;

        public int DiseasedID { get => diseasedID; set => diseasedID = value; }
        public string NumberID { get => numberID; set => numberID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Mail { get => mail; set => mail = value; }
    }
}
