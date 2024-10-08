using System.Collections.ObjectModel;
using wpf1.Abstracts;
using wpf1.Models;
using System.Windows.Input;

using System.Windows;
using wpf1.Commands;

namespace wpf1.ViewModels
{
    public class ScheduleDatagridViewModel : BaseMembersViewModel<ScheduleModel> // Assuming you have a BaseMembersViewModel
    {
        private string collectionName = "appointments";
        public ICommand DeleteCommand { get; private set; }
        public ScheduleDatagridViewModel()
        {
            DeleteCommand = new DeleteCommand<ScheduleModel>(OnDelete);
            InitializeAsync(collectionName).ConfigureAwait(false);
        }
        private async Task InitializeAsync(string CollectionName)
        {
            try
            {
                await GetEntityAsync(CollectionName);
                FireStoreQuery.Instance.ListenToCollectionChanges<ScheduleModel>(CollectionName, updatedCollection =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Members.Clear();
                        foreach (var item in updatedCollection)
                        {
                            if (item.Status == Status.ACCEPTED.ToString())
                            {
                                Members.Add(item);
                            }
                        }
                    });
                });
            }
            catch (Exception e)
            {
                MessageBox.Show("ERrror" + e.Message);
            }
        }

        private async void OnDelete(ScheduleModel schedule)
        {
            if (schedule == null) return;

            try
            {
                await FirestoreRepository.Instance.DeleteAsync(schedule.SID, collectionName);
                Members.Remove(schedule);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting employee: {ex.Message}");
            }
        }
    }
}
