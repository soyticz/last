using wpf1.Models;
using wpf1.Abstracts;
using wpf1.Firebase.Firestore;
using System.Windows;
using wpf1.Firebase.FirebaseRepository;
using System.Windows.Input;
using wpf1.Views.EmployeesView.EditWindowView;
using wpf1.Commands;
namespace wpf1.ViewModels
{
    public class EmployeeDatagridViewModel : BaseMembersViewModel<EmployeeModel>
    {
        private string collectionName = "Employee";
        private EditWindowView _editWindow;
        public ICommand EditCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public EmployeeDatagridViewModel()
        {
            DeleteCommand = new DeleteCommand<EmployeeModel>(OnDelete);
            EditCommand = new EditCommand<EmployeeModel>(OnEdit);
            InitializeAsync(collectionName).ConfigureAwait(false);
        }

        // In your ViewModel or wherever appropriate
        private async Task InitializeAsync(string CollectionName)
        {
            try
            {
                await GetEntityAsync(CollectionName);
                FireStoreQuery.Instance.ListenToCollectionChanges<EmployeeModel>(CollectionName, updatedCollection =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Members.Clear();
                        foreach (var item in updatedCollection)
                        {
                            Members.Add(item);
                        }
                    });
                });
            }
            catch (Exception e)
            {
                MessageBox.Show("ERrror" + e.Message);
            }
        }

        private async void OnDelete(EmployeeModel employee)
        {
            if (employee == null) return;

            try
            {
                await FirestoreRepository.Instance.DeleteAsync(employee.EID, collectionName);
                Members.Remove(employee);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting employee: {ex.Message}");
            }
        }

        private void OnEdit(EmployeeModel employee)
        {
            if (employee == null) return;

            try
            {
                _editWindow = new EditWindowView(employee.EID);
                _editWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting employee: {ex.Message}");
            }
        }
    }
}
