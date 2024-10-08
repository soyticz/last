using Google.Cloud.Firestore;
using System;
using System.ComponentModel.DataAnnotations;

namespace wpf1.Models
{
    [FirestoreData]
    public record ScheduleModel
    {
        [FirestoreProperty]
        [Required(ErrorMessage = "Full name is required.")]
        public string FullName { get; init; }

        [FirestoreProperty]
        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; init; }

        [FirestoreProperty]
        [Required(ErrorMessage = "Services are required.")]
        public string Services { get; init; }

        [FirestoreProperty]
        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; init; }

        [FirestoreProperty]
        [Required(ErrorMessage = "Doctor is required.")]
        public Doctor Doctor { get; init; }

        [FirestoreProperty]
        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; init; }
    }

    [FirestoreData]
    public record Doctor
    {
        [FirestoreProperty]
        [Required(ErrorMessage = "Doctor ID is required.")]
        public string ID { get; init; }

        [FirestoreProperty]
        [Required(ErrorMessage = "Doctor name is required.")]
        public string Name { get; init; }
    }
}
