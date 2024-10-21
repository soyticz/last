using wpf1.Models;
using wpf1.Abstracts;
using wpf1.Firebase.Firestore;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using wpf1.Commands;
using wpf1.Views.PatientView.EditWindowView;

namespace wpf1.ViewModels;

public class ModalViewModel : BaseMembersViewModel<PatientModel>
{
    private string collectionName = "users";
    private EditWindowView _editWindow;
    public ICommand DeleteCommand { get; private set; }
    public ICommand EditCommand { get; private set; }

    private PatientModel _selectedPatient;

    public PatientModel SelectedPatient
    {
        get => _selectedPatient;
        set
        {
            _selectedPatient = value;
            OnPropertyChanged(nameof(SelectedPatient)); // Notify property changed
        }
    }

    private void OnMemberSelected(PatientModel patient)
    {
        SelectedPatient = patient; // Set the selected patient
    }


    public ModalViewModel()
    {
        DeleteCommand = new RelayCommand<PatientModel>(OnDelete);
        EditCommand = new RelayCommand<PatientModel>(OnEdit);
        InitializeAsync(collectionName).ConfigureAwait(false);
    }

    private async Task InitializeAsync(string collectionName)
    {
        try
        {
            await GetEntityAsync(collectionName);
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
            MessageBox.Show("Error: " + e.Message);
        }
    }

    private async void OnDelete(PatientModel patient)
    {
        if (patient == null) return;

        try
        {
            // // Logic for deleting the patient from Firestore
            // await FirestoreService.Instance.DeleteDocumentAsync(collectionName, patient.PID);
            // Members.Remove(patient);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting patient: {ex.Message}");
        }
    }

    private void OnEdit(PatientModel patient)
    {
        if (patient == null) return;

        try
        {
            // _editWindow = new EditWindowView(patient); // Open edit window with the selected patient
            // _editWindow.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error editing patient: {ex.Message}");
        }
    }
}
