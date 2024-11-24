﻿using System.ComponentModel;
using System.Collections.Generic;

namespace BlazorCustomConrols.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public List<string> Countries = new() { "USA", "Canada", "Mexico" };
        private readonly Dictionary<string, string> _values = new();
        public StatusEnum Status { get; set; } = StatusEnum.Pending;
        private DateTime dateOfBirth = DateTime.Now;
        public string SelectedOption { get; set; } = "Option1";

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { 
                dateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
            }
        }

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
        public bool IsReadOnlyMode = false;
        public int SignedValue { get; set; }
        public uint UnsignedValue { get; set; }
        public decimal DecimalValue { get; set; }
        public double DoubleValue { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsFeatureEnabled { get; set; }

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
