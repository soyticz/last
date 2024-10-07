using Google.Cloud.Firestore;
namespace wpf1.Models;

[FirestoreData]
public class EmployeeModel 
{
    
    public EmployeeModel()
    {

    }

    [FirestoreProperty]
    public string EID { get; set; }
    [FirestoreProperty]
    public string? Name { get; set; }
    [FirestoreProperty]
    public string? Position { get; set; }
    [FirestoreProperty]
    public string? Email { get; set; }
    [FirestoreProperty]
    public long? PhoneNumber { get; set; }
    [FirestoreProperty]
    public bool IsSelected { get; set; }
}