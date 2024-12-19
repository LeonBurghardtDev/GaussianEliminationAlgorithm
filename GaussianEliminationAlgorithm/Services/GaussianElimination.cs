using GaussianEliminationAlgorithm.Converters;
using GaussianEliminationAlgorithm.Models;
using GaussianEliminationAlgorithm.ResultObjects;
using GaussianEliminationAlgorithm.ViewModels;
using GaussianEliminationAlgorithm.Views;
using System.Collections.ObjectModel;
using System.Windows;

namespace GaussianEliminationAlgorithm.Services
{
    /// <summary>
    /// Provides a static service to execute Gaussian Elimination on a given system of equations.
    /// </summary>
    public static class GaussianElimination
    {
        /// <summary>
        /// Executes the Gaussian Elimination process on the provided user inputs.
        /// </summary>
        /// <param name="Matrix">The user-provided ObservableCollection representing the matrix cells.</param>
        /// <param name="RightHandSide">The user-provided ObservableCollection representing the right-hand side vector cells.</param>
        /// <param name="CurrentMatrixSize">The size of the matrix (n x n).</param>
        /// <exception cref="System.Exception">Thrown if the system of equations has no solution.</exception>
        public static void Execute(ObservableCollection<MatrixCell> Matrix, ObservableCollection<MatrixCell> RightHandSide, int CurrentMatrixSize)
        {
            // Convert user input into a structured format for calculations
            InputConversionResult inputConversionResult = InputConverter.ConvertInput(Matrix, RightHandSide, CurrentMatrixSize);

            // Retrieve the original matrix and vector
            Models.Matrix originalMatrix = inputConversionResult.Matrix;
            Models.Vector vector = inputConversionResult.RightHandSide;

            // Create a deep copy of the original matrix for manipulation during calculations
            Models.Matrix convertedMatrix = originalMatrix.DeepCopy();

            // Perform Gaussian elimination on the copied matrix
            SolveLinearEquationSystem solveLinearEquationSystem = new SolveLinearEquationSystem();
            Models.Vector solution = solveLinearEquationSystem.Solve(convertedMatrix, vector);

            if (solution == null)
            {
                throw new System.Exception("The system of equations has no solution.");
            }

            // Retrieve the logs generated during the elimination process
            string logs = solveLinearEquationSystem.GetLogs();

            // Display the results in a dedicated view
            DisplayResultView displayResultView = new DisplayResultView(originalMatrix: originalMatrix, convertedMatrix: convertedMatrix, vector, solution, logs);
            displayResultView.Show();
        }
    }
}
