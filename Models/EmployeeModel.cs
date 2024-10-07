using System.ComponentModel.DataAnnotations; // Add this namespace
using Google.Cloud.Firestore;
using wpf1.interfaces;

namespace wpf1.Models
{
    [FirestoreData]
    public record EmployeeModel : IEmpoyee
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
        public string EID { get; init; } // Use init-only setters for immutability

        [FirestoreProperty]
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; init; } // Use init-only setters for immutability

        [FirestoreProperty]
        [Required(ErrorMessage = "Position is required.")]
        public string? Position { get; init; } // Use init-only setters for immutability

        [FirestoreProperty]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; init; } // Use init-only setters for immutability

        [FirestoreProperty]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public long? PhoneNumber { get; init; } // Use init-only setters for immutability

        [FirestoreProperty]
        public bool IsSelected { get; init; } // Use init-only setters for immutability
    }
}
