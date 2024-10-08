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
    public int Age { get; set; }

    [FirestoreProperty("address")]
    public string Address { get; set; }

    [FirestoreProperty("userType")]
    public string UserType { get; set; } 
}