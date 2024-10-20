using Google.Cloud.Firestore;
namespace wpf1.Models;

[FirestoreData]
public record Doctor
{
    [FirestoreProperty]
    public string fullname { get; set; }
    [FirestoreProperty]
    public string ProfilePath { get; set; }
}