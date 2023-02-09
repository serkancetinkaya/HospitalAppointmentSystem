using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntitySecretary
    {
        private int secretaryID;
        private string numberID;
        private string firstName;
        private string lastName;
        private string password;
        private string phoneNumber;

        public int SecretaryID { get => secretaryID; set => secretaryID = value; }
        public string NumberID { get => numberID; set => numberID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Password { get => password; set => password = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
    }
}
