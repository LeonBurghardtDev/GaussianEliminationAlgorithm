using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using GaussianEliminationAlgorithm.Models;

namespace GaussianEliminationAlgorithm.ViewModels
{
    /// <summary>
    /// ViewModel for displaying the results of Gaussian Elimination in a math-correct format.
    /// </summary>
    public class DisplayResultViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets the formatted conerted matrix for display in math notation.
        /// </summary>
        public string FormattedConvertedMatrix { get; }

        /// <summary>
        /// Gets the formatted original matrix for display in math notation.
        /// </summary>
        public string FormattedOriginalMatrix { get; }


        /// <summary>
        /// Gets the formatted right-hand side vector for display in math notation.
        /// </summary>
        public string FormattedRightHandSide { get; }

        /// <summary>
        /// Gets the formatted solution vector for display in math notation.
        /// </summary>
        public string FormattedSolution { get; }

        /// <summary>
        /// Gets the logs generated during the calculation process.
        /// </summary>
        public string Logs { get; }

        /// <summary>
        /// Command to close the result view.
        /// </summary>
        public ICommand CloseCommand { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayResultViewModel"/> class.
        /// </summary>
        /// <param name="matrix">The matrix used in the calculations.</param>
        /// <param name="rightHandSide">The right-hand side vector.</param>
        /// <param name="solution">The solution vector.</param>
        /// <param name="logs">The logs from the calculations.</param>
        /// <param name="closeAction">The action to execute when the view is closed.</param>
        public DisplayResultViewModel(Models.Matrix originalMatrix, Models.Matrix convertedMatrix, Vector rightHandSide, Vector solution, string logs, Action closeAction)
        {
            if (convertedMatrix == null) throw new ArgumentNullException(nameof(convertedMatrix));
            if (originalMatrix == null) throw new ArgumentNullException(nameof(originalMatrix));
            if (rightHandSide == null) throw new ArgumentNullException(nameof(rightHandSide));
            if (solution == null) throw new ArgumentNullException(nameof(solution));

            FormattedConvertedMatrix = FormatMatrix(convertedMatrix);
            FormattedOriginalMatrix = FormatMatrix(originalMatrix);
            FormattedRightHandSide = FormatVector(rightHandSide, "");
            FormattedSolution = FormatVector(solution, "");
            Logs = logs;

            CloseCommand = new RelayCommand(() => closeAction());
        }

        /// <summary>
        /// Formats the matrix into a math-correct string representation.
        /// </summary>
        /// <param name="matrix">The matrix to format.</param>
        /// <returns>A string representing the formatted matrix.</returns>
        private string FormatMatrix(Matrix matrix)
        {
            var builder = new StringBuilder();
            builder.AppendLine("[");
            for (int i = 0; i < matrix.Rows; i++)
            {
                builder.Append("  [ ");
                for (int j = 0; j < matrix.Columns; j++)
                {
                    builder.Append($"{matrix[i, j],6:F2}");
                    if (j < matrix.Columns - 1)
                        builder.Append(", ");
                }
                builder.AppendLine(" ]");
            }
            builder.AppendLine("]");
            return builder.ToString();
        }

        /// <summary>
        /// Formats a vector into a math-correct string representation.
        /// </summary>
        /// <param name="vector">The vector to format.</param>
        /// <param name="label">The label for the vector (e.g., "b" or "x").</param>
        /// <returns>A string representing the formatted vector.</returns>
        private string FormatVector(Vector vector, string label)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{label}[");
            for (int i = 0; i < vector.Length; i++)
            {
                builder.AppendLine($"  {vector[i],6:F2}");
            }
            builder.AppendLine("]");
            return builder.ToString();
        }
    }
}