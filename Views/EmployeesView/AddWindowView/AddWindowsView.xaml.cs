using System.Windows;
using wpf1.ViewModels;
using wpf1.Models;
using wpf1.Firebase.FirebaseRepository;
using Google.Cloud.Firestore.V1;

namespace wpf1.Views.EmployeesView.AddWindowView
{
    public partial class AddWindowsView : Window
    {
        private readonly AddWindowViewModel _repositoryViewModel;
        private readonly string projectId = "adminthesis";
        private readonly string CollectionName = "Employee";
        private readonly string field = "EID";

        public AddWindowsView()
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
                string finalEid = await FirestoreRepository.Instance.GetLastDocument(CollectionName, field);

                // Retrieve input data
                string name = txtName.Text;
                string position = txtPosition.Text;
                string email = txtEmail.Text;
                string phoneNumberStr = txtPhone.Text;

                // Validate the input
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(position) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneNumberStr))
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
                var employeeModel = new EmployeeModel
                {
                    EID = finalEid,
                    Name = name,
                    Position = position,
                    Email = email,
                    PhoneNumber = phoneNumber,
                };

                // Save the employee model to Firestore
                await FirestoreRepository.Instance.CreateNewDocumentWithIncrementedIdAsync(CollectionName, field, employeeModel);

                MessageBox.Show($"Employee {name} has been saved with EID: {finalEid}");
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
