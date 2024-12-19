using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace GaussianEliminationAlgorithm.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// Sets the DataContext to the MainViewModel.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new GaussianEliminationAlgorithm.ViewModels.MainViewModel();
        }

        /// <summary>
        /// Handles the <see cref="Hyperlink.RequestNavigate"/> event for navigating to an external URL.
        /// </summary>
        /// <param name="sender">The source of the event, typically the <see cref="Hyperlink"/> control.</param>
        /// <param name="e">The event data containing the navigation URI.</param>
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }


        /// <summary>
        /// Handles numeric input validation for text inputs.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The text composition event arguments.</param>
        private void NumericInputHandler(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.-]+"); // Allows only numbers and a minus sign
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}