using wpf1.Abstracts;
using wpf1.Models;
using wpf1.Firebase.Firestore;
using System.Windows;
using System.Windows.Input;
namespace wpf1.ViewModels
{
    public class AttendanceViewModel : BaseMembersViewModel<AttendanceModel>
    {
        private string collectionName = "attendance";
        public AttendanceViewModel()
        {
           InitializeAttendanceListener().ConfigureAwait(false);
        }

        private async Task InitializeAttendanceListener() // Renamed for clarity
        {
            try
            {
		        await GetEntityAsync(collectionName);
                await FirestoreService.Instance.ListenToCollectionChanges<AttendanceModel>(collectionName, updatedCollection =>
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
