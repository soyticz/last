using System.ComponentModel.DataAnnotations; // Add this namespace
using Google.Cloud.Firestore;

namespace wpf1.Models
{
    [FirestoreData]
    public class EmployeeModel
    {
        public EmployeeModel() { }

        [FirestoreProperty]
        [Required(ErrorMessage = "EID is required.")]
        public string EID { get; set; }

        [FirestoreProperty]
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        [FirestoreProperty]
        [Required(ErrorMessage = "Position is required.")]
        public string? Position { get; set; }

        [FirestoreProperty]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [FirestoreProperty]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public long? PhoneNumber { get; set; }

        [FirestoreProperty]
        public bool IsSelected { get; set; }
    }
}
