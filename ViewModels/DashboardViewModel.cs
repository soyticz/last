

using System.ComponentModel;
namespace wpf1.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        public DashboardViewModel()
        {
           
        }

     

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
