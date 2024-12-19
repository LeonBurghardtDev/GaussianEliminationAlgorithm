using GaussianEliminationAlgorithm.Models;
using GaussianEliminationAlgorithm.ViewModels;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace GaussianEliminationAlgorithm.Views
{
    /// <summary>
    /// Interaction logic for DisplayResultView.xaml.
    /// Represents a view for displaying the results of Gaussian Elimination,
    /// including the original matrix, right-hand side vector, solution vector, and logs.
    /// </summary>
    public partial class DisplayResultView : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayResultView"/> class.
        /// </summary>
        /// <param name="matrix">The original matrix used in the Gaussian Elimination process.</param>
        /// <param name="rightHandSide">The right-hand side vector associated with the matrix.</param>
        /// <param name="solution">The solution vector resulting from Gaussian Elimination.</param>
        /// <param name="logs">The calculation logs generated during the elimination process.</param>
        public DisplayResultView(Models.Matrix originalMatrix, Models.Matrix convertedMatrix, Models.Vector rightHandSide, Models.Vector solution, string logs)
        {
            InitializeComponent();

            // Initialize the ViewModel with the provided data and set it as the DataContext
            DataContext = new DisplayResultViewModel(
                originalMatrix,
                convertedMatrix,
                rightHandSide,
                solution,
                logs,
                Close // Action to close the view
            );
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
        /// Handles the Loaded event of the logs TextBox to scroll to the bottom automatically.
        /// </summary>
        /// <param name="sender">The event source, expected to be a TextBox.</param>
        /// <param name="e">The event arguments.</param>
        private void ScrollToBottom(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                // Scroll the logs TextBox to the bottom
                textBox.ScrollToEnd();
            }
        }
    }
}
