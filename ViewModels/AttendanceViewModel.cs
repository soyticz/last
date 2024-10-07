using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using wpf1.Abstracts;
using wpf1.Firebase.Firestore;
using wpf1.Models;

namespace wpf1.ViewModels
{
    public class AttendanceViewModel : BaseMembersViewModel<AttendanceModel>
    {
        private readonly string collectionName = "Attendance";
        private readonly string employeeCollectionName = "Employee";

        public AttendanceViewModel()
        {
            InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await LoadFilteredAttendanceAsync();
            ListenToChanges();
        }

        public async Task LoadFilteredAttendanceAsync()
        {
            try
            {
                var filteredAttendance = await FireStoreQuery.Instance.FilteredData();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Members.Clear();
                    foreach (var record in filteredAttendance)
                    {
                        Members.Add(record);
                    }
                });
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
        }

        private void ListenToChanges()
        {
            // Listen to changes in the Employee collection
            FireStoreQuery.Instance.ListenToCollectionChanges<EmployeeModel>(employeeCollectionName, _ =>
            {
                RefreshFilteredData();
            });

            // Listen to changes in the Attendance collection
            FireStoreQuery.Instance.ListenToCollectionChanges<AttendanceModel>(collectionName, _ =>
            {
                RefreshFilteredData();
            });
        }

        private async void RefreshFilteredData()
        {
            // Re-fetch and filter the data when either Employee or Attendance data changes
            await LoadFilteredAttendanceAsync();
        }
    }
}
