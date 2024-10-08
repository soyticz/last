using System.Windows;
using System.Windows.Input;
using wpf1.Abstracts;
using wpf1.Commands;

using wpf1.Firebase.Firestore;
using wpf1.Models;
namespace wpf1.ViewModels;

public class DiagnosisViewModel : BaseMembersViewModel<DiagnosisModel>
{
    private string collectionName = "Diagnosis";
    public ICommand DeleteCommand { get; private set; }
    public DiagnosisViewModel()
    {
        // DeleteCommand = new DeleteCommand<DiagnosisModel>(OnDelete);
        InitializeAsync(collectionName).ConfigureAwait(false);
    }

    private async Task InitializeAsync(string CollectionName)
    {
        try
        {
            await GetEntityAsync(CollectionName);
            FirestoreService.Instance.ListenToCollectionChanges<DiagnosisModel>(CollectionName, updatedCollection =>
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

    private async void OnDelete(DiagnosisModel diagnosis)
    {
        if (diagnosis == null) return;

        try
        {
           
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting employee: {ex.Message}");
        }
    }
}
