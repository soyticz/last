using Google.Cloud.Firestore;
using System.ComponentModel.DataAnnotations;
using wpf1.interfaces; // Import the necessary namespace for validation

namespace wpf1.Models
{
    [FirestoreData]
    public record AttendanceModel : IEmpoyee
    {
        public AttendanceModel(string aid, string eid, string? name, bool isSelected, string? timeIn, string? timeOut, long? phoneNumber)
        {
            AID = aid;
            EID = eid;
            Name = name;
            IsSelected = isSelected;
            TimeIn = timeIn;
            TimeOut = timeOut;
            PhoneNumber = phoneNumber;
        }

        [FirestoreProperty]
        [Required(ErrorMessage = "AID is required.")]
        public string AID { get; init; } // Use init-only setters for immutability

        [FirestoreProperty]
        [Required(ErrorMessage = "EID is required.")]
        public string EID { get; init; } // Use init-only setters for immutability

        [FirestoreProperty]
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; init; } // Use init-only setters for immutability

        [FirestoreProperty]
        public bool IsSelected { get; init; } // Use init-only setters for immutability

        [FirestoreProperty]
        [DataType(DataType.Time)]
        public string? TimeIn { get; init; } // Use init-only setters for immutability

        [FirestoreProperty]
        [DataType(DataType.Time)]
        public string? TimeOut { get; init; } // Use init-only setters for immutability

        [FirestoreProperty]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public long? PhoneNumber { get; init; } // Use init-only setters for immutability
    }
}
