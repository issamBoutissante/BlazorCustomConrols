using System.ComponentModel;
using System.Collections.Generic;

namespace BlazorCustomConrols.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public List<string> Countries = new() { "USA", "Canada", "Mexico" };
        private readonly Dictionary<string, string> _values = new();
        public StatusEnum Status { get; set; } = StatusEnum.Pending;
        public string this[string key]
        {
            get => _values.ContainsKey(key) ? _values[key] : string.Empty;
            set
            {
                _values[key] = value;
                OnPropertyChanged(key);
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
    public enum StatusEnum
    {
        Active,
        Inactive,
        Pending,
        Completed
    }
}
