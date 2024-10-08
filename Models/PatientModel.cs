using Google.Cloud.Firestore;

[FirestoreData]
public class PatientModel
{
    [FirestoreProperty("uid")]
    public string PID { get; set; }

    [FirestoreProperty("fullname")]
    public string Fullname { get; set; }

    [FirestoreProperty("email")]
    public string Email { get; set; }

    [FirestoreProperty("age")]
    public string Age { get; set; }

    [FirestoreProperty("address")]
    public string Address { get; set; }

    // Now, this property represents the array stored in Firestore.
    [FirestoreProperty("userType")]
    public List<string> UserType { get; set; }
}
