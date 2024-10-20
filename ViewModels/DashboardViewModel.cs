using wpf1.Models;
using wpf1.Abstracts;
using wpf1.Firebase.Firestore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows;
using System.Threading.Tasks;

namespace wpf1.ViewModels
{
    public class DashboardViewModel : BaseMembersViewModel<DoctorModel>
    {
        private string doctorCollectionName = "users"; // for doctors
        private string scheduleCollectionName = "appointments"; // for consultation requests

        public ObservableCollection<ScheduleModel> ConsultationRequests { get; } = new ObservableCollection<ScheduleModel>();
        public ObservableCollection<PatientModel> Patients { get; } = new ObservableCollection<ScheduleModel>();
        public DashboardViewModel()
        {
            InitializeAsync(doctorCollectionName, scheduleCollectionName).ConfigureAwait(false);
        }

        private async Task InitializeAsync(string doctorCollection, string scheduleCollection)
        {
            try
            {
                await GetEntityAsync(doctorCollection); // Load doctors

                FirestoreService.Instance.ListenToCollectionChanges<DoctorModel>(doctorCollection, updatedDoctors =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Members.Clear();
                        foreach (var item in updatedDoctors)
                        {
                            if (item.UserType != null && item.UserType.Contains("Doctor"))
                            {
                                Members.Add(item);
                            }
                        }
                    });
                });

                FirestoreService.Instance.ListenToCollectionChanges<ScheduleModel>(scheduleCollection, updatedSchedules =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        ConsultationRequests.Clear();
                        foreach (var item in updatedSchedules)
                        {
                            ConsultationRequests.Add(item);
                        }
                    });
                });

                FirestoreService.Instance.ListenToCollectionChanges<PatientModel>(doctorCollection, updatedPatients =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Patients.Clear();
                        foreach (var item in updatedPatients)
                        {
                            if (item.UserType != null && item.UserType.Contains("Patient"))
                            {
                                Patients.Add(item);
                            }
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
