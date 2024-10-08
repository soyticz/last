using System.Collections.ObjectModel;
using wpf1.Abstracts;
using wpf1.Models;
using System.Windows.Input;


using System.Windows;
using wpf1.Commands;
using wpf1.Firebase.Firestore;

namespace wpf1.ViewModels
{
    public class ScheduleDatagridViewModel : BaseMembersViewModel<ScheduleModel> // Assuming you have a BaseMembersViewModel
    {
        private string collectionName = "appointments";
        public ICommand DeleteCommand { get; private set; }
        public ScheduleDatagridViewModel()
        {
           
            InitializeAsync(collectionName).ConfigureAwait(false);
        }
        private async Task InitializeAsync(string CollectionName)
        {
            try
            {
                await GetEntityAsync(CollectionName);
                FirestoreService.Instance.ListenToCollectionChanges<ScheduleModel>(CollectionName, updatedCollection =>
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
    }
}
