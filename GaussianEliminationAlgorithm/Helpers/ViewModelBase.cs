using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GaussianEliminationAlgorithm
{
    /// <summary>
    /// Base class for ViewModels, implementing INotifyPropertyChanged to enable property change notifications.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Event triggered when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event for a specified property.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed. Automatically set by the CallerMemberName attribute.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
