using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityResult
    {
        private int resultID;
        private int appointmentID;
        private int doctorID;
        private int diseasedID;
        private string doctorResult;
        private string testResult;
        private DateTime date;

        public int ResultID { get => resultID; set => resultID = value; }
        public int AppointmentID { get => appointmentID; set => appointmentID = value; }
        public int DoctorID { get => doctorID; set => doctorID = value; }
        public int DiseasedID { get => diseasedID; set => diseasedID = value; }
        public string DoctorResult { get => doctorResult; set => doctorResult = value; }
        public string TestResult { get => testResult; set => testResult = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}
