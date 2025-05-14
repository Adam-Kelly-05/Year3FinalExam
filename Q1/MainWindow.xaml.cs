using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Q1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PatientData db = new PatientData();

        public MainWindow()
        {
            InitializeComponent();
            DisplayPatients();
        }

        public void DisplayPatients()
        {
            var query = from p in db.Patients
                        orderby p.FirstName
                        select p;

            Patients_LBX.ItemsSource = query.ToList();
        }

        private void AddPatient_BTN_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstName_TXTBX.Text;
            string surname = SurName_TXTBX.Text;
            DateTime dob = DOB_DTPKR.SelectedDate.Value;
            string contactNumber = PhoneNumber_TXTBX.Text;

            db.Patients.Add(new Patient()
            {
                FirstName = firstName,
                Surname = surname,
                DOB = dob,
                ContactNumber = contactNumber
            });

            DisplayPatients();
        }

        private void AddAppointment_BTN_Click(object sender, RoutedEventArgs e)
        {
            AppointmentWindow appointmentWindow = new AppointmentWindow(this);
            appointmentWindow.Owner = this;

            appointmentWindow.ShowDialog();
        }

        private void Patient_Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            Patient selected = Patients_LBX.SelectedItem as Patient;

            if (selected.Appointments.Count() == 0)
                Appointment_LBX.ItemsSource = "No Appointments";
            else
                Appointment_LBX.ItemsSource = selected.Appointments;

        }
    }
}
