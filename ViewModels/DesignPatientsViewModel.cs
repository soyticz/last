using wpf1.Models;
using wpf1.Abstracts;
using wpf1.Firebase.Firestore;
using System.Windows.Input;
using System.Windows;
using wpf1.Commands;

namespace wpf1.ViewModels;

public class DesignPatientsViewModel : BaseMembersViewModel<PatientModel>
{
    private string collectionName = "users";
    public DesignPatientsViewModel()
    {
        InitializeAsync(collectionName).ConfigureAwait(false);
    }
    private async Task InitializeAsync(string CollectionName)
    {
        try
        {
            await GetEntityAsync(CollectionName);
            FirestoreService.Instance.ListenToCollectionChanges<PatientModel>(collectionName, updatedCollection =>
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