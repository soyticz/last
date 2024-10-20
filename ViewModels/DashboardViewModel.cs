

using System.ComponentModel;
using wpf1.Abstracts;
using wpf1.Models;
namespace wpf1.ViewModels
{
    public class DashboardViewModel : BaseMembersViewModel<DoctorModel>
    {
        private string collectionName = "users";
        public DashboardViewModel()
        {
           InitializeAsync(collectionName).ConfigureAwait(false);
        }
        private async Task InitializeAsync(string CollectionName)
        {
            try
            {
                await GetEntityAsync(CollectionName);
                FirestoreService.Instance.ListenToCollectionChanges<DoctorModel>(collectionName, updatedCollection =>
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
