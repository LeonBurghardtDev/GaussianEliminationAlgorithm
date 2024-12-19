using GaussianEliminationAlgorithm.Models;

namespace GaussianEliminationAlgorithm.Helpers
{
    /// <summary>
    /// Provides utility methods for operations on matrices, such as determinant calculation and submatrix extraction.
    /// </summary>
    public class MatrixUtilities
    {
        /// <summary>
        /// Checks if the given matrix is invertible.
        /// </summary>
        /// <param name="matrix">The matrix to check.</param>
        /// <returns>True if the matrix is invertible, otherwise false.</returns>
        public static bool IsMatrixInvertible(Matrix matrix)
        {
            return CalculateDeterminant(matrix) != 0;
        }

        /// <summary>
        /// Calculates the determinant of the given matrix.
        /// </summary>
        /// <param name="matrix">The matrix for which to calculate the determinant.</param>
        /// <returns>The determinant of the matrix.</returns>
        public static double CalculateDeterminant(Matrix matrix)
        {
            int n = matrix.Rows;

            if (n == 1) return matrix[0, 0];
            if (n == 2) return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

            double determinant = 0;
            for (int p = 0; p < n; p++)
            {
                Matrix subMatrix = CreateSubMatrix(matrix, 0, p);
                determinant += matrix[0, p] * CalculateDeterminant(subMatrix) * (p % 2 == 0 ? 1 : -1);
            }

            return determinant;
        }

        /// <summary>
        /// Creates a submatrix by excluding the specified row and column from the given matrix.
        /// </summary>
        /// <param name="matrix">The original matrix.</param>
        /// <param name="excludeRow">The row to exclude.</param>
        /// <param name="excludeColumn">The column to exclude.</param>
        /// <returns>The submatrix with the specified row and column excluded.</returns>
        public static Matrix CreateSubMatrix(Matrix matrix, int excludeRow, int excludeColumn)
        {
            int n = matrix.Rows;
            Matrix subMatrix = new Matrix(n - 1, n - 1);
            int r = 0;

            for (int i = 0; i < n; i++)
            {
                if (i == excludeRow) continue;
                int c = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j == excludeColumn) continue;
                    subMatrix[r, c] = matrix[i, j];
                    c++;
                }
                r++;
            }

            return subMatrix;
        }
    }
}