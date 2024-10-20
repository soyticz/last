using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using System;
using System.Threading.Tasks;
using System.Windows;
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
            string fullPath = @"C:\admin\admin1\admin1\last\AdminThesis.json";

            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(fullPath),
            });
        }

        public async Task<string> CreateUserAsync(string email, string password, string location)
        {
            try
            {
                // Create the user in Firebase Authentication
                UserRecord userRecord = await FirebaseAuth.DefaultInstance.CreateUserAsync(new UserRecordArgs()
                {
                    Email = email,
                    Password = password,
                });

                MessageBox.Show($"Successfully created user: {userRecord.Uid}", "User Created", MessageBoxButton.OK, MessageBoxImage.Information);

                // Call SaveLoginCredentialsAsync to save the user's credentials
                await FirestoreService.Instance.SaveLoginCredentialsAsync(email, password, location);

                return userRecord.Uid;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error creating user: {e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show($"Error fetching user: {e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public async Task<bool> LoginUserAsync(string email, string password, string selectedLocation)
        {
            try
            {
                // Perform Firebase login using the email and password.
                var user = await FirebaseAuth.DefaultInstance.GetUserByEmailAsync(email);
                var hashedPassword = await FirestoreService.Instance.GetPasswordByUsernameAsync(email);
                // Here you can validate the user's location based on your application logic.
                if (user != null && FirestoreService.Instance.VerifyPassword(password,hashedPassword))
                {
                    return true;
                }

                return false;
            }
            catch (FirebaseAuthException e)
            {
                MessageBox.Show($"Error logging in user: {e.Message}", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error logging in user: {e.Message}", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
    }
}
