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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Q1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PatientData db = new PatientData();

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

            // Add patient to database

            DisplayPatients();
        }
    }
}
