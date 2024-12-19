using System;
using GaussianEliminationAlgorithm.Models;

namespace GaussianEliminationAlgorithm.Helpers
{
    /// <summary>
    /// Provides helper methods for performing row operations on matrices.
    /// </summary>
    public static class RowOperations
    {
        /// <summary>
        /// Attempts to swap rows in the matrix to ensure the pivot is non-zero.
        /// </summary>
        /// <param name="matrix">The matrix to modify.</param>
        /// <param name="pivotIndex">The index of the pivot row.</param>
        /// <returns>True if a swap was performed; otherwise, false.</returns>
        public static bool TrySwapRows(Matrix matrix, int pivotIndex)
        {
            int n = matrix.Rows;

            for (int i = pivotIndex + 1; i < n; i++)
            {
                if (matrix[i, pivotIndex] != 0)
                {
                    SwapRows(matrix, pivotIndex, i);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Swaps two rows in the matrix.
        /// </summary>
        /// <param name="matrix">The matrix to modify.</param>
        /// <param name="row1">The first row to swap.</param>
        /// <param name="row2">The second row to swap.</param>
        public static void SwapRows(Matrix matrix, int row1, int row2)
        {
            int columns = matrix.Columns;
            for (int j = 0; j < columns; j++)
            {
                double temp = matrix[row1, j];
                matrix[row1, j] = matrix[row2, j];
                matrix[row2, j] = temp;
            }
        }

        /// <summary>
        /// Subtracts a multiple of one row from another row to eliminate an entry.
        /// </summary>
        /// <param name="matrix">The matrix to modify.</param>
        /// <param name="targetRow">The row to be modified.</param>
        /// <param name="pivotRow">The row used as the pivot.</param>
        /// <param name="factor">The multiple of the pivot row to subtract.</param>
        public static void SubtractRow(Matrix matrix, int targetRow, int pivotRow, double factor)
        {
            int columns = matrix.Columns;
            for (int j = 0; j < columns; j++)
            {
                matrix[targetRow, j] -= factor * matrix[pivotRow, j];
            }
        }
    }
}
