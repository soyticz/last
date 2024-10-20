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
            new Lazy<FirestoreService>(() => new FirestoreService("integrated-2970a")); // Your project ID

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
            var newEmployee = new EmployeeModel
            {
                EID = Guid.NewGuid().ToString(), // Generate new EID
                Name = name,
                Position = position,
                Email = email,
                PhoneNumber = phoneNumber,
                IsSelected = isSelected
            };

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
        public async Task ListenToCollectionChanges<T>(string collectionName, Action<ObservableCollection<T>> onChanged) where T : class
        {
            CollectionReference rootCollection = FirestoreDb.Collection(collectionName);

            // Listen for changes in the collection
            rootCollection.Listen(snapshot =>
            {
                var collection = new ObservableCollection<T>();
                foreach (var document in snapshot.Documents)
                {
                    if (document.Exists)
                    {
                        var item = document.ConvertTo<T>();
                        collection.Add(item);
                    }
                }
                onChanged(collection);
            });
        }

        // Method to fetch data from Firestore and return as an ObservableCollection
        public async Task<ObservableCollection<T>> FetchDataFromFirestore<T>(string collectionName) where T : class
        {
            var collection = new ObservableCollection<T>();

            try
            {
                CollectionReference colRef = FirestoreDb.Collection(collectionName);
                QuerySnapshot snapshot = await colRef.GetSnapshotAsync();

                foreach (DocumentSnapshot doc in snapshot.Documents)
                {
                    if (doc.Exists)
                    {
                        T entity = doc.ConvertTo<T>(); // Assumes Firestore POCO attribute mapping
                        collection.Add(entity);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (such as Firestore access issues)
                System.Diagnostics.Debug.WriteLine($"Error fetching data from Firestore: {ex.Message}");
            }

            return collection;
        }

        
    }
}
