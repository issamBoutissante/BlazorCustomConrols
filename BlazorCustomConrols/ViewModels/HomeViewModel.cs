using System.ComponentModel;
using System.Collections.Generic;

namespace BlazorCustomConrols.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private readonly Dictionary<string, string> _values = new();

        public string this[string key]
        {
            get => _values.ContainsKey(key) ? _values[key] : string.Empty;
            set
            {
                if (key == "LastName")
                {
                    _values[key] = value;
                    OnPropertyChanged(key);
                    OnPropertyChanged(nameof(FullName)); // Update FullName when LastName changes
                }
                else
                {
                    _values[key] = value;
                    OnPropertyChanged(key);
                }
            }
        }

        public string FirstName
        {
            get => this[nameof(FirstName)];
            set
            {
                this[nameof(FirstName)] = value;
                OnPropertyChanged(nameof(FullName)); // Update FullName when FirstName changes
            }
        }

  
        public string FullName => $"{FirstName} {this["LastName"]}";

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
