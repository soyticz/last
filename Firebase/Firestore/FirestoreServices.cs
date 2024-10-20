using Google.Cloud.Firestore;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using BCrypt.Net;
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

        /// <summary>
        /// Adds an employee to the Firestore "employees" collection.
        /// </summary>
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
                    EID = newEmployee.EID,
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

        /// <summary>
        /// Listens for changes and gets all objects of type T from the specified collection.
        /// </summary>
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

        /// <summary>
        /// Fetches data from Firestore and returns it as an ObservableCollection.
        /// </summary>
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

        /// <summary>
        /// Saves login credentials to Firestore, hashing the password before storage.
        /// </summary>
        public async Task SaveLoginCredentialsAsync(string email, string password, string location)
        {
            // Generate a unique document ID
            string documentId = Guid.NewGuid().ToString(); // Generate a unique ID for the document

            try
            {
                // Reference to the Firestore "loginCredentials" collection
                CollectionReference credentialsCollection = FirestoreDb.Collection("admin");

                // Hash the password before storing it
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                // Create the user credential object
                var userCredentials = new
                {
                    Email = email,
                    Password = hashedPassword, // Store the hashed password
                    Location = location,
                    CreatedAt = Timestamp.FromDateTime(DateTime.UtcNow) // Timestamp for creation
                };

                // Add the user credentials to Firestore
                DocumentReference docRef = await credentialsCollection.AddAsync(userCredentials);

                Console.WriteLine($"Login credentials saved with document ID: {docRef.Id}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving login credentials: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Verifies the entered password against the stored hashed password.
        /// </summary>
        public bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHashedPassword);
        }
    }
}
