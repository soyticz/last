

using System.Windows;
using Firebase.Auth;
using Google.Protobuf.WellKnownTypes;
using FirebaseAdmin;
using wpf1.Models;
using FirebaseAdmin.Auth;
namespace wpf1.Firebase.FirebaseAuthentication;
public class FirebaseUserAuth
{
    private static readonly Lazy<FirebaseUserAuth> _instance = new Lazy<FirebaseUserAuth>(() => new FirebaseUserAuth());
    public static FirebaseUserAuth Instance => _instance.Value;
    private string Token;
    FirebaseApp app = FirebaseApp.DefaultInstance;
    private readonly string _firebseApiKey = "AIzaSyBelUGdk2injXLxR3Y3N7xcVkSaYCz1W30";
    private readonly FirebaseAuthProvider _authProvider;

    private FirebaseUserAuth()
    {
        _authProvider = new FirebaseAuthProvider(new FirebaseConfig(_firebseApiKey));
    }
    public async Task<bool> RegisterUserAsync(string username, string password)
    {
        var userregister = await _authProvider.CreateUserWithEmailAndPasswordAsync(username, password);
        return true;
    }
    public async Task<bool> LoginUserAsync(string username, string password)
    {
        try
        {
            var userlogin = await _authProvider.SignInWithEmailAndPasswordAsync(username, password);
            return true;
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
            return false;
        }
    }
    public async Task<string> GetUserTokenAsync(FirebaseAuthLink _firebaseAuthLink)
    {
        string s = _firebaseAuthLink.FirebaseToken;
        return s;
    }

    public async Task<string> getTenantId()
    {
        var user = await _authProvider.GetUserAsync(Token);
        return user.FederatedId;
    }
}