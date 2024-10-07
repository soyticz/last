using Google.Cloud.Firestore;
using System.ComponentModel.DataAnnotations; // Ensure this is included

namespace wpf1.Models
{
    [FirestoreData]
    public record EmployeeModel
    {
        public EmployeeModel(string eid, string? name, string? position, string? email, long? phoneNumber, bool isSelected)
        {
            EID = eid;
            Name = name;
            Position = position;
            Email = email;
            PhoneNumber = phoneNumber;
            IsSelected = isSelected;
        }

        [FirestoreProperty]
        [Required(ErrorMessage = "EID is required.")]
        public string EID { get; init; }

        [FirestoreProperty]
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; init; }

        [FirestoreProperty]
        [Required(ErrorMessage = "Position is required.")]
        public string? Position { get; init; }

        [FirestoreProperty]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; init; }

        [FirestoreProperty]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public long? PhoneNumber { get; init; }

        [FirestoreProperty]
        public bool IsSelected { get; init; }
    }
}
