using System.Windows;
using wpf1.ViewModels;
using wpf1.Models;
using wpf1.Firebase.FirebaseRepository;
using Google.Cloud.Firestore.V1;

namespace wpf1.Views.PatientView.AddWindowView
{
    public partial class AddWindowView : Window
    {
        private readonly AddWindowViewModel _repositoryViewModel;
        private readonly string projectId = "adminthesis";
        private readonly string CollectionName = "Patient";
        private readonly string field = "PID";

        public AddWindowView()
        {
            InitializeComponent();
            _repositoryViewModel = new AddWindowViewModel();
            this.DataContext = _repositoryViewModel;
        }
        private async void SaveEmployeeDataAsync()
        {
            try
            {
                // Retrieve the next document ID
                string finalPid = await FirestoreRepository.Instance.GetLastDocument(CollectionName, field);

                // Retrieve input data
                string name = txtName.Text;
                string services = txtServices.Text;
                string email = txtEmail.Text;
                string phoneNumberStr = txtPhone.Text;

                // Validate the input
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(services) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneNumberStr))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                if (!long.TryParse(phoneNumberStr, out long phoneNumber))
                {
                    MessageBox.Show("Please enter a valid phone number.");
                    return;
                }

                // Create a new employee model
                var patientModel = new PatientModel
                {
                    PID = finalPid,
                    Name = name,
                    Services = services,
                    Email = email,
                    PhoneNumber = phoneNumber,
                };

                // Save the employee model to Firestore
                await FirestoreRepository.Instance.CreateNewDocumentWithIncrementedIdAsync(CollectionName, field, patientModel);

                MessageBox.Show($"Employee {name} has been saved with EID: {finalPid}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving employee: {ex.Message}");
            }
        }


        private async void Save_Button(object sender, RoutedEventArgs e)
        {
            SaveEmployeeDataAsync();
        }
    }
}
