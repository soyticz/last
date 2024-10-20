using Google.Cloud.Firestore;

namespace wpf1.Models;
[FirestoreData]
public record DoctorModel{

    [FirestoreProperty("fullname")]
    public string FullName {get; set;}
    [FirestoreProperty("ProfilePath")]
    public string Profile {get; set;}
    [FirestoreProperty("userType")]
    public List<string> UserType { get; set; }
}