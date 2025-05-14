using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{    public class Appointment
    {
        public int AppointmentID { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string AppointmentNotes { get; set; }

        public int PatientID { get; set; }
        public virtual Patient Patient { get; set; }
    }

    public class Patient
    {
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DOB { get; set; }
        public string ContactNumber { get; set; }

        public virtual List<Appointment> Appointments { get; set; }
    }

    public class PatientData : DbContext
    {
        public PatientData() : base("OODExam_AdamKelly") { }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
