using Google.Cloud.Firestore;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using wpf1.Models;

namespace wpf1.Firebase.Firestore
{
    public class FirestoreService
    {
        // Singleton instance for FirestoreService
        private static readonly Lazy<FirestoreService> _instance = 
            new Lazy<FirestoreService>(() => new FirestoreService("integrated-2970a")); // Provide your project ID here

        // Public static instance to access FirestoreService singleton
        public static FirestoreService Instance => _instance.Value;

        // Lazy initialization for FirestoreDb
        private readonly Lazy<FirestoreDb> _lazyFirestoreDb;

        // Private constructor for singleton pattern
        private FirestoreService(string projectId)
        {
            _lazyFirestoreDb = new Lazy<FirestoreDb>(() =>
            {
                // Set the Google Application Credentials environment variable
                string path = @"AdminThesis.json"; // Adjust file name if needed
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
                return FirestoreDb.Create(projectId);
            });
        }

        // FirestoreDb property to access the lazily initialized FirestoreDb
        private FirestoreDb FirestoreDb => _lazyFirestoreDb.Value;

        // Method to add an employee to the Firestore "employees" collection
        public async Task AddEmployeeAsync(string name, string position, string email, long? phoneNumber, bool isSelected, string location)
        {
            var newEmployee = new EmployeeModel(
                eid: Guid.NewGuid().ToString(), // Generate new EID
                name: name,
                position: position,
                email: email,
                phoneNumber: phoneNumber,
                isSelected: isSelected
            );

            try
            {
                CollectionReference employeesCollection = FirestoreDb.Collection("employees");
                DocumentReference docRef = await employeesCollection.AddAsync(new
                {
                    EID = newEmployee.EID, // Use the generated EID
                    newEmployee.Name,
                    newEmployee.Position,
                    newEmployee.Email,
                    newEmployee.PhoneNumber,
                    newEmployee.IsSelected,
                    Location = location 
                });

                Console.WriteLine($"Employee added with EID: {newEmployee.EID} and document ID: {docRef.Id}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding employee: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Method to listen for changes and get all objects of type T from the specified collection
        public void GetAllObjects<T>(Action<ObservableCollection<T>> onDataChanged, string collectionName) where T : class
        {
            FirestoreDb.Collection(collectionName).Listen(snapshot =>
            {
                var data = new ObservableCollection<T>();
                
                foreach (var document in snapshot.Documents)
                {
                    var item = document.ToObject<T>();
                    if (item != null)
                    {
                        data.Add(item); // Correctly add the item to the ObservableCollection
                    }
                }
                
                onDataChanged(data); // Notify when data changes
            }, error =>
            {
                MessageBox.Show($"Error retrieving data: {error.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            });
        }
    }
}
