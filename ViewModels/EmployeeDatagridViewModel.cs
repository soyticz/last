using wpf1.Models;
using System.Collections.ObjectModel;
using wpf1.Firebase.Firestore;
using wpf1.Abstracts;
using System.Windows;
using System.Windows.Input;
using System.Threading.Tasks; // Ensure this is included

namespace wpf1.ViewModels
{
    public class EmployeeDatagridViewModel : BaseMembersViewModel<EmployeeModel>
    {
        private string collectionName = "employees"; // Corrected typo

        public EmployeeDatagridViewModel()
        {
            // Initialize the employee listener in the constructor
            InitializeEmployeeListener().ConfigureAwait(false);
        }

        private async Task InitializeEmployeeListener() // Renamed for clarity
        {
            try
            {
		await GetEntityAsync(collectionName);
                await FirestoreService.Instance.ListenToCollectionChanges<EmployeeModel>(collectionName, updatedCollection =>
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
                MessageBox.Show("Error: " + e.Message);
            }
        }
    }
}
