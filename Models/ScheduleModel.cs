using Google.Cloud.Firestore;
using System;
using System.ComponentModel.DataAnnotations;

namespace wpf1.Models
{
    [FirestoreData]
    public record ScheduleModel
    {
        [FirestoreProperty("fullname")]
        [Required(ErrorMessage = "Full name is required.")]
        public string FullName { get; init; }

        [FirestoreProperty("location")]
        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; init; }

        [FirestoreProperty("services")]
        [Required(ErrorMessage = "Services are required.")]
        public string Services { get; init; }

        [FirestoreProperty("status")]
        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; init; }

        [FirestoreProperty("doctor")]
        [Required(ErrorMessage = "Doctor is required.")]
        public Doctor Doctor { get; init; }

        [FirestoreProperty("date")]
        [Required(ErrorMessage = "Date is required.")]
        public string Date { get; init; }
    }

    [FirestoreData]
    public record Doctor
    {
        [FirestoreProperty("id")]
        [Required(ErrorMessage = "Doctor ID is required.")]
        public string ID { get; init; }

        [FirestoreProperty("name")]
        [Required(ErrorMessage = "Doctor name is required.")]
        public string Name { get; init; }
    }
}
