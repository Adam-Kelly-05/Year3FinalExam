using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Q1
{
    /// <summary>
    /// Interaction logic for AppointmentWindow.xaml
    /// </summary>
    public partial class AppointmentWindow : Window
    {
        public PatientData db = new PatientData();

        private MainWindow mainWindow;

        public AppointmentWindow(MainWindow owner)
        {
            InitializeComponent();
            mainWindow = owner;
        }

        private void AddAppointment_BTN_Click(object sender, RoutedEventArgs e)
        {
            DateTime appointmentDate = Date_DTPKR.SelectedDate.Value;
            string appointmentTime = Time_TMPKR.Text;

            db.Appointments.Add(new Appointment()
            {
                AppointmentTime = appointmentDate
            });

            var query = from a in mainWindow.db.Appointments
                        select a;
        }
    }
}
