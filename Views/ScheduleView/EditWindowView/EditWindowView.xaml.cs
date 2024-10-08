using System.Windows;
using wpf1.ViewModels;
using wpf1.Models;
using wpf1.Firebase.FirebaseRepository;
using wpf1.Firebase.Firestore;

namespace wpf1.Views.ScheduleView.EditWindowView
{
    public partial class EditWindowView : Window
    {


        public EditWindowView() // Constructor takes EID as parameter
        {
            InitializeComponent();
            // Load the employee data when the window opens
        }



        private async void Save_Button(object sender, RoutedEventArgs e)
        {

        }
    }
}
