using Google.Cloud.Firestore;
using wpf1.Interfaces;

namespace wpf1.Models;
[FirestoreData]
public class AttendanceModel : IPerson, IWorkingHours
{
    [FirestoreProperty]
    public string AID { get; set; }
    [FirestoreProperty]
    public string EID { get; set; }
    [FirestoreProperty]
    public string? Name { get; set; }
    [FirestoreProperty]
    public bool IsSelected { get; set; }
    [FirestoreProperty]
    public string? timeIn { get; set; }
    [FirestoreProperty]
    public string? timeOut { get; set; }
    [FirestoreProperty]
    public long? PhoneNumber { get; set; }
}