using System;
using GaussianEliminationAlgorithm.Logging;
using GaussianEliminationAlgorithm.Models;
using GaussianEliminationAlgorithm.Helpers;
using GaussianEliminationAlgorithm.Interfaces;

namespace GaussianEliminationAlgorithm.Services.Eliminators
{
    /// <summary>
    /// Performs forward elimination for Gaussian elimination.
    /// </summary>
    public class ForwardEliminator : IEliminator
    {
        private readonly CalculationLogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ForwardEliminator"/> class.
        /// </summary>
        /// <param name="logger">The logger used to log steps in the elimination process.</param>
        public ForwardEliminator(CalculationLogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Executes forward elimination on the given matrix.
        /// </summary>
        /// <param name="matrix">The matrix to process.</param>
        /// <param name="rightHandSide">The right-hand side vector of the equation system (optional).</param>
        /// <returns>The matrix after forward elimination.</returns>
        public object Execute(Matrix matrix, Vector rightHandSide = null)
        {
            _logger.Log("Starting forward elimination.");

            int n = matrix.Rows;

            for (int k = 0; k < n; k++)
            {
                _logger.Log($"Step {k + 1}: Ensuring pivot a[{k + 1},{k + 1}] is non-zero.");
                EnsureNonZeroPivot(matrix, k);

                _logger.Log($"Step {k + 1}: Eliminating entries below pivot a[{k + 1},{k + 1}].");
                EliminateBelowPivot(matrix, k, rightHandSide);

                _logger.Log($"Step {k + 1} completed.");
            }

            _logger.Log("Forward elimination completed.");
            return matrix; // Returns the upper triangular matrix.
        }

        /// <summary>
        /// Ensures the pivot element is non-zero by performing row swaps if necessary.
        /// </summary>
        /// <param name="matrix">The matrix to modify.</param>
        /// <param name="pivotIndex">The current pivot index.</param>
        private void EnsureNonZeroPivot(Matrix matrix, int pivotIndex)
        {
            if (matrix[pivotIndex, pivotIndex] == 0)
            {
                _logger.Log($"Pivot a[{pivotIndex + 1},{pivotIndex + 1}] is zero. Attempting to swap rows.");
                bool swapped = RowOperations.TrySwapRows(matrix, pivotIndex);
                if (swapped)
                {
                    _logger.Log($"Swapped rows to ensure a[{pivotIndex + 1},{pivotIndex + 1}] is non-zero.");
                }
                else
                {
                    _logger.Log("Matrix is singular and cannot be reduced further.");
                    throw new InvalidOperationException("Matrix is not invertible.");
                }
            }
            else
            {
                _logger.Log($"Pivot a[{pivotIndex + 1},{pivotIndex + 1}] is already non-zero.");
            }
        }

        /// <summary>
        /// Eliminates all entries below the pivot in the current column.
        /// </summary>
        /// <param name="matrix">The matrix to process.</param>
        /// <param name="pivotIndex">The current pivot index.</param>
        /// <param name="rightHandSide">The right-hand side vector (optional).</param>
        private void EliminateBelowPivot(Matrix matrix, int pivotIndex, Vector rightHandSide = null)
        {
            int n = matrix.Rows;

            for (int i = pivotIndex + 1; i < n; i++)
            {
                double factor = matrix[i, pivotIndex] / matrix[pivotIndex, pivotIndex];
                _logger.Log($"Eliminating row {i + 1}: Multiplying row {pivotIndex + 1} by {factor:F2} and subtracting from row {i + 1}.");

                RowOperations.SubtractRow(matrix, i, pivotIndex, factor);

                if (rightHandSide != null)
                {
                    rightHandSide[i] -= factor * rightHandSide[pivotIndex];
                }

                _logger.Log($"Row {i + 1} eliminated using factor {factor:F2}.");
            }
        }
    }
}
