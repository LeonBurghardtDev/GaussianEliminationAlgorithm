using System.ComponentModel;

/// <summary>
/// Represents a UI-related matrix cell used for input and display.
/// Not intended for calculations.
/// </summary>
public class MatrixCell : INotifyPropertyChanged
{
    private string _value;

    /// <summary>
    /// Gets or sets the index of the cell (e.g., x₁₁ for row 1, column 1).
    /// </summary>
    public string Index { get; set; }

    /// <summary>
    /// Gets or sets the value of the cell as a string, typically for user input.
    /// </summary>
    public string Value
    {
        get => _value;
        set
        {
            if (_value != value)
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }
    }

    /// <summary>
    /// Event triggered when a property value changes.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Raises the PropertyChanged event for a specified property.
    /// </summary>
    /// <param name="propertyName">The name of the property that changed.</param>
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
