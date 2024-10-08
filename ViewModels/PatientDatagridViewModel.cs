using wpf1.Models;
using wpf1.Abstracts;
using wpf1.Firebase.Firestore;
using System.Windows.Input;
using System.Windows;
using wpf1.Commands;
using wpf1.Views.PatientView.EditWindowView;

namespace wpf1.ViewModels;

public class PatientDatagridViewModel : BaseMembersViewModel<PatientModel>
{
    private string collectionName = "users";
    private EditWindowView _editWindow;
    public ICommand DeleteCommand { get; private set; }
    public ICommand EditCommand { get; private set; }
    public PatientDatagridViewModel()
    {
        // DeleteCommand = new DeleteCommand<PatientModel>(OnDelete);
        // EditCommand = new EditCommand<PatientModel>(OnEdit);
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

    private async void OnDelete(PatientModel patient)
    {
        if (patient == null) return;

        try
        {
            
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting employee: {ex.Message}");
        }
    }


    private void OnEdit(PatientModel patient)
    {
        if (patient == null) return;

        try
        {
          
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error Editing employee: {ex.Message}");
        }
    }
}