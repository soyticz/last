using System.Windows;
using wpf1.ViewModels;
using wpf1.Models;
using wpf1.Firebase.FirebaseRepository;
using wpf1.Firebase.Firestore;

namespace wpf1.Views.PatientView.EditWindowView
{
    public partial class EditWindowView : Window
    {
        private readonly AddWindowViewModel _repositoryViewModel;
        private readonly string CollectionName = "Patient";
        private readonly string PID; // Assuming you pass this ID when opening the window

        public EditWindowView(string pid) // Constructor takes EID as parameter
        {
            InitializeComponent();
            _repositoryViewModel = new AddWindowViewModel();
            this.DataContext = _repositoryViewModel;
            PID = pid;
            LoadEmployeeDataAsync(PID).ConfigureAwait(false); // Load the employee data when the window opens
        }

        private async Task LoadEmployeeDataAsync(string pid)
        {
            try
            {
                MessageBox.Show(pid);
                var patient = await FireStoreQuery.Instance.FetchDocumentFromFirestore<PatientModel>(CollectionName, pid);
                if (patient != null)
                {
                    // Populate the UI fields with employee data
                    txtName.Text = patient.Name;
                    txtServices.Text = patient.Services;
                    txtEmail.Text = patient.Email;
                    txtPhone.Text = patient.PhoneNumber.ToString();
                }
                else
                {
                    MessageBox.Show("Employee not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employee data: {ex.Message}");
            }
        }

        private async void SaveEmployeeDataAsync()
        {
            try
            {
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

                // Create an updated employee model
                var patientModel = new PatientModel
                {
                    PID = PID, // Use the existing EID
                    Name = name,
                    Services = services,
                    Email = email,
                    PhoneNumber = phoneNumber,
                };

                // Save the updated employee model to Firestore
                await FirestoreRepository.Instance.UpdateAsync(patientModel.PID, CollectionName, patientModel);

                MessageBox.Show($"Employee {name} has been updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving employee: {ex.Message}");
            }
        }

        private async void Save_Button(object sender, RoutedEventArgs e)
        {
            SaveEmployeeDataAsync(); // Await the async method
        }
    }
}
