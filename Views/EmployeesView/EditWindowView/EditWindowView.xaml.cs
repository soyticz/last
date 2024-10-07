using System.Windows;
using wpf1.ViewModels;
using wpf1.Models;
using wpf1.Firebase.FirebaseRepository;
using wpf1.Firebase.Firestore;

namespace wpf1.Views.EmployeesView.EditWindowView
{
    public partial class EditWindowView : Window
    {
        private readonly AddWindowViewModel _repositoryViewModel;
        private readonly string CollectionName = "Employee";
        private readonly string EID; // Assuming you pass this ID when opening the window

        public EditWindowView(string eid) // Constructor takes EID as parameter
        {
            InitializeComponent();
            _repositoryViewModel = new AddWindowViewModel();
            this.DataContext = _repositoryViewModel;
            EID = eid;
            LoadEmployeeDataAsync(EID).ConfigureAwait(false); // Load the employee data when the window opens
        }

        private async Task LoadEmployeeDataAsync(string eid)
        {
            try
            {
                MessageBox.Show(eid);
                var employee = await FireStoreQuery.Instance.FetchDocumentFromFirestore<EmployeeModel>(CollectionName, eid);
                if (employee != null)
                {
                    // Populate the UI fields with employee data
                    txtName.Text = employee.Name;
                    txtPosition.Text = employee.Position;
                    txtEmail.Text = employee.Email;
                    txtPhone.Text = employee.PhoneNumber.ToString();
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

                // Create an updated employee model
                var employeeModel = new EmployeeModel
                {
                    EID = EID, // Use the existing EID
                    Name = name,
                    Position = position,
                    Email = email,
                    PhoneNumber = phoneNumber,
                };

                // Save the updated employee model to Firestore
                await FirestoreRepository.Instance.UpdateAsync(employeeModel.EID, CollectionName, employeeModel);

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
