using Google.Cloud.Firestore;


namespace wpf1.Models;
[FirestoreData]
public class DiagnosisModel 
{
    [FirestoreProperty]
    public bool IsSelected { get; set; }
    [FirestoreProperty]
    public string DID { get; set; }
    [FirestoreProperty]
    public string PID { get; set; }
    [FirestoreProperty]
    public string? Name { get; set; }
}