using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityAppointment
    {
        private int appointmentID;
        private int secretaryID;
        private int doctorID;
        private int diseasedID;
        private int branchID;
        private DateTime date;

        public int AppointmentID { get => appointmentID; set => appointmentID = value; }
        public int SecretaryID { get => secretaryID; set => secretaryID = value; }
        public int DoctorID { get => doctorID; set => doctorID = value; }
        public int DiseasedID { get => diseasedID; set => diseasedID = value; }
        public int BranchID { get => branchID; set => branchID = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}
