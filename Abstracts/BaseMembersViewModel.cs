using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using wpf1.Commands;
using wpf1.ViewModels;

namespace wpf1.Abstracts
{
    public abstract class BaseMembersViewModel<T> : INotifyPropertyChanged where T : class
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<T> Members { get; }

        protected BaseMembersViewModel()
        {
            Members = new ObservableCollection<T>();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
