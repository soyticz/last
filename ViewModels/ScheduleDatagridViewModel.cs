using System.Collections.ObjectModel;
using System.Windows;
using wpf1.Abstracts;
using wpf1.Models;
using wpf1.Firebase.Firestore;

namespace wpf1.ViewModels
{
    public class ScheduleDatagridViewModel : BaseMembersViewModel<ScheduleModel>
    {
        private string collectionName = "appointments";

        public ScheduleDatagridViewModel()
        {
            InitializeAsync();
        }

        // Initializes the Firestore listener for the "appointments" collection
        private async void InitializeAsync()
        {
            try
            {
                // Fetch initial data from Firestore collection
                await GetEntityAsync(collectionName);

                // Listen for collection changes
                FirestoreService.Instance.ListenToCollectionChanges<ScheduleModel>(collectionName, updatedCollection =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        // Clear existing members and update with new data
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
                // Display error if there is any issue with Firestore access or Google credentials
                MessageBox.Show($"Error in ScheduleDatagridViewModel: {e.Message}", "Initialization Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
