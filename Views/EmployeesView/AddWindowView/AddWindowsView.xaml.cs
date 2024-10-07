using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;
using wpf1.Models; // Ensure this namespace includes EmployeeModel
using wpf1.Firebase.Firestore; // Ensure this namespace includes FirestoreService

namespace wpf1.Views.EmployeesView.AddWindowView
{
    public partial class AddWindowsView : Window
    {
        public AddWindowsView()
        {
            InitializeComponent();
        }

        // Save button click event handler
        private async void SaveButton(object sender, RoutedEventArgs e)
        {
            // Generate a new unique ID
            string eid = Guid.NewGuid().ToString();

            // Create a new instance of EmployeeModel and set properties manually (since constructor is removed)
            var newEmployee = new EmployeeModel
            {
                EID = eid,
                Name = txtName.Text,
                Position = txtPosition.Text,
                Email = txtEmail.Text,
                PhoneNumber = long.TryParse(txtPhone.Text, out long phoneNumber) ? phoneNumber : (long?)null,
                IsSelected = false // Or any default value as needed
            };

            // Validate the employee model
            var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var validationContext = new ValidationContext(newEmployee);
            bool isValid = Validator.TryValidateObject(newEmployee, validationContext, validationResults, true);

            if (!isValid)
            {
                // Show validation errors
                string errors = string.Join(Environment.NewLine, validationResults.Select(vr => vr.ErrorMessage));
                MessageBox.Show($"Please correct the following errors:\n{errors}", "Validation Errors", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Call FirestoreService to add the employee
            var firestoreService = FirestoreService.Instance;
            await firestoreService.AddEmployeeAsync(newEmployee.Name, newEmployee.Position, newEmployee.Email, newEmployee.PhoneNumber, newEmployee.IsSelected, "Location"); // Provide the appropriate location

            // Optionally, show a success message and close the window
            MessageBox.Show("Employee added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close(); // Close the window after saving
        }

        // Change button background color on mouse enter
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button button) // Use pattern matching
            {
                button.Background = new SolidColorBrush(Color.FromRgb(102, 51, 153)); // Darker color on hover
            }
        }

        // Reset button background color on mouse leave
        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button button) // Use pattern matching
            {
                button.Background = new SolidColorBrush(Color.FromRgb(120, 79, 242)); // Original color
            }
        }
    }
}
