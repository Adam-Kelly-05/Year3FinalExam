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

            FirstName_TXTBX.Text = selected.FirstName;
            SurName_TXTBX.Text = selected.Surname;
            PhoneNumber_TXTBX.Text = selected.ContactNumber;
            DOB_DTPKR.SelectedDate = selected.DOB;

            if (selected.Appointments.Count() == 0)
                Appointment_LBX.ItemsSource = "No Appointments";
            else
                Appointment_LBX.ItemsSource = selected.Appointments;
        }

        private void Appointment_Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            Appointment selected = Appointment_LBX.SelectedItem as Appointment;
        }

        private void FirstName_TXTBX_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            FirstName_TXTBX.Text = "";
        }

        private void SurName_TXTBX_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SurName_TXTBX.Text = "";
        }

        private void PhoneNumber_TXTBX_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PhoneNumber_TXTBX.Text = "";
        }

        private void DOB_DTPKR_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DOB_DTPKR.SelectedDate = DateTime.Now;
        }
    }
}
