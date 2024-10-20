using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using System;
using System.Threading.Tasks;
using wpf1.Firebase.Firestore;

namespace wpf1.Firebase.FirebaseAuthentication // Replace with your actual namespace
{
    public class FirebaseAuthService
    {
        private static readonly Lazy<FirebaseAuthService> _instance = new Lazy<FirebaseAuthService>(() => new FirebaseAuthService());
        public static FirebaseAuthService Instance => _instance.Value;

        private FirebaseAuthService()
        {
            // Use the full path to the service account JSON file
            string fullPath = @"C:\Users\soyti\wpf1\AdminThesis.json";

            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(fullPath),
            });

            
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

        public async Task<string> LoginUserAsync(string email, string password, string selectedLocation)
        {
            try
            {
                // Perform Firebase login using the email and password.
                // If successful, you can perform additional checks based on selectedLocation.

                var user = await FirebaseAuth.DefaultInstance.GetUserByEmailAsync(email);
                // Here you can validate the user's location based on your application logic
                if (user != null)
                {
                    return user.Uid;
                }

                return null;
            }
            catch (FirebaseAuthException e)
            {
                Console.WriteLine($"Error logging in user: {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error logging in user: {e.Message}");
                return null;
            }
        }
    }
}
