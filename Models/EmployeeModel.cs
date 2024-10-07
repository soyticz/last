using Google.Cloud.Firestore;

using wpf1.Interfaces;

namespace wpf1.Models;

[FirestoreData]
public class EmployeeModel : IPerson, IContact
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