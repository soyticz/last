using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Google.Cloud.Firestore;
using System.Threading.Tasks;

namespace wpf1.Views.DashboardView
{
    public partial class DashboardView : UserControl
    {
        // ObservableCollection to store doctor data
        public ObservableCollection<Doctor> Doctors { get; set; } = new ObservableCollection<Doctor>();

        public DashboardView()
        {
            InitializeComponent();
            this.DataContext = this; // Set the DataContext for binding
            LoadDoctorDataAsync(); // Fetch doctor data on initialization
        }

        // Fetch doctor data from Firestore
        private async Task LoadDoctorDataAsync()
        {
            FirestoreDb db = FirestoreDb.Create("your-project-id"); // Initialize Firestore
            Query query = db.Collection("users").WhereArrayContains("userType", "Doctor");

            QuerySnapshot snapshot = await query.GetSnapshotAsync();

            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                if (document.Exists)
                {
                    // Get fullname and ProfilePath fields
                    string fullname = document.GetValue<string>("fullname");
                    string profilePath = document.ContainsField("ProfilePath") ? document.GetValue<string>("ProfilePath") : "default_path.png"; // Provide a default image if missing

                    // Add doctor to the collection
                    Doctors.Add(new Doctor { FullName = fullname, ProfilePath = profilePath });
                }
            }
        }

        // Add the click event handler for the View button
        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                var menuBar = mainWindow.FindName("MenuBar") as Menubar;
                if (menuBar != null)
                {
                    var patientButton = menuBar.FindName("PatientButton") as RadioButton;
                    if (patientButton != null)
                    {
                        patientButton.IsChecked = true;

                        var command = patientButton.Command;
                        if (command != null && command.CanExecute(patientButton.CommandParameter))
                        {
                            command.Execute(patientButton.CommandParameter);
                        }
                    }
                }
            }
        }
    }



[FirestoreData]
public record Doctor
{
    [FirestoreProperty]
    public string fullname { get; set; }
    [FirestoreProperty]
    public string ProfilePath { get; set; }
}
}
