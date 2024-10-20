using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using System;
using System.Threading.Tasks;
using wpf1.Firebase.Firestore;

namespace Firebase.FirebaseAuthentication // Replace with your actual namespace
{
    public class FirebaseAuthService
    {
        private static readonly Lazy<FirebaseAuthService> _instance = new Lazy<FirebaseAuthService>(() => new FirebaseAuthService());
        public static FirebaseAuthService Instance => _instance.Value;
        private readonly FirestoreService _firestoreService;

        private FirebaseAuthService()
        {
            // Use the full path to the service account JSON file
            string fullPath = @"C:\Users\soyti\wpf1\AdminThesis.json";

            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(fullPath),
            });

            _firestoreService = new FirestoreService("integrated-2970a"); // Initialize FirestoreService
        }

        public async Task<string> CreateUserAsync(string email, string password, string location)
        {
            try
            {
                UserRecord userRecord = await FirebaseAuth.DefaultInstance.CreateUserAsync(new UserRecordArgs()
                {
                    Email = email,
                    Password = password,
                });

                Console.WriteLine($"Successfully created user: {userRecord.Uid}");

                // After creating user, save the user's location in Firestore
                await _firestoreService.AddUserLocationAsync(userRecord.Uid, email, location);

                return userRecord.Uid;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error creating user: {e.Message}");
                return null;
            }
        }

        public async Task<UserRecord> GetUserAsync(string uid)
        {
            try
            {
                UserRecord userRecord = await FirebaseAuth.DefaultInstance.GetUserAsync(uid);
                return userRecord;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching user: {e.Message}");
                return null;
            }
        }
    }
}
