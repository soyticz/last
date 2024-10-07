using Google.Cloud.Firestore;
using System;
using System.Threading.Tasks;
using System.Windows;
using wpf1.Models;
using System.IO;

namespace wpf1.Firebase.Firestore
{
    public class FirestoreService
    {
        // Singleton lazy initialization for FirestoreService
        private static readonly Lazy<FirestoreService> _instance = new Lazy<FirestoreService>(() => new FirestoreService("integrated-2970a")); // Provide your project ID here

        // Public static instance to access FirestoreService singleton
        public static FirestoreService Instance => _instance.Value;

        // Lazy initialization for FirestoreDb
        private readonly Lazy<FirestoreDb> _lazyFirestoreDb;

        // Private constructor (singleton pattern)
        private FirestoreService(string projectId)
        {
            _lazyFirestoreDb = new Lazy<FirestoreDb>(() =>
            {
                // Only create FirestoreDb when accessed
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

        // This is not necessary anymore, EID is set during object creation
        Console.WriteLine($"Employee added with EID: {newEmployee.EID} and document ID: {docRef.Id}");
    }
    catch (Exception e)
    {
        MessageBox.Show("Error" + e, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}

    }
}

