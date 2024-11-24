using System.ComponentModel;
using System.Collections.Generic;

namespace BlazorCustomControls.ViewModels;

/// <summary>
/// The ViewModel that holds the state for the demo page.
/// Implements INotifyPropertyChanged to enable binding and state updates.
/// </summary>
public class HomeViewModel : INotifyPropertyChanged
{
    /// <summary>
    /// List of countries for the dropdown field.
    /// </summary>
    public List<string> Countries { get; } = new() { "USA", "Canada", "Mexico" };

    /// <summary>
    /// Dictionary to simulate dynamic property storage using indexers.
    /// </summary>
    private readonly Dictionary<string, string> _values = new();

    /// <summary>
    /// Status selection for the enum dropdown.
    /// </summary>
    public StatusEnum Status { get; set; } = StatusEnum.Pending;

    /// <summary>
    /// Selected option in the radio group.
    /// </summary>
    public string SelectedOption { get; set; } = "Option1";

    private DateTime dateOfBirth = DateTime.Now;

    /// <summary>
    /// Date input value for the date picker.
    /// </summary>
    public DateTime DateOfBirth
    {
        get => dateOfBirth;
        set
        {
            dateOfBirth = value;
            OnPropertyChanged(nameof(DateOfBirth));
        }
    }

    /// <summary>
    /// Dynamic property access via indexer.
    /// </summary>
    public string this[string key]
    {
        get => _values.ContainsKey(key) ? _values[key] : string.Empty;
        set
        {
            _values[key] = value;
            OnPropertyChanged(key);
        }
    }

    /// <summary>
    /// First name input field.
    /// </summary>
    public string FirstName
    {
        get => this[nameof(FirstName)];
        set
        {
            this[nameof(FirstName)] = value;
            OnPropertyChanged(nameof(FullName)); // Update FullName when FirstName changes
        }
    }

    /// <summary>
    /// Computed full name from FirstName and LastName.
    /// </summary>
    public string FullName => $"{FirstName} {this["LastName"]}";

    /// <summary>
    /// Read-only mode toggle for controls.
    /// </summary>
    public bool IsReadOnlyMode { get; set; } = false;

    /// <summary>
    /// Number input values.
    /// </summary>
    public int SignedValue { get; set; }
    public uint UnsignedValue { get; set; }
    public decimal DecimalValue { get; set; }
    public double DoubleValue { get; set; }

    /// <summary>
    /// Description for the textarea field.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Toggle button state.
    /// </summary>
    public bool IsFeatureEnabled { get; set; }

    /// <summary>
    /// Event for property changes.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Triggers property change notifications.
    /// </summary>
    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

/// <summary>
/// Enum used in the EnumDropdownField.
/// </summary>
public enum StatusEnum
{
    Active,
    Inactive,
    Pending,
    Completed
}
