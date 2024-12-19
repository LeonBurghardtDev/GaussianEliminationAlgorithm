using GaussianEliminationAlgorithm.Models;
using GaussianEliminationAlgorithm.ResultObjects;
using System.Collections.ObjectModel;

namespace GaussianEliminationAlgorithm.Converters
{
    /// <summary>
    /// Converts user input from the UI into a structured format for calculations.
    /// </summary>
    public class InputConverter
    {
        /// <summary>
        /// Converts matrix and right-hand side input into a structured result object.
        /// </summary>
        /// <param name="matrixCells">The ObservableCollection of matrix cells from the view model.</param>
        /// <param name="rightHandSideCells">The ObservableCollection of right-hand side cells from the view model.</param>
        /// <param name="matrixSize">The size of the matrix (n x n).</param>
        /// <returns>A structured result object containing the matrix and right-hand side vector.</returns>
        public static InputConversionResult ConvertInput(
            ObservableCollection<MatrixCell> matrixCells,
            ObservableCollection<MatrixCell> rightHandSideCells,
            int matrixSize)
        {
            ValidateInput(matrixCells, rightHandSideCells, matrixSize);

            Matrix matrix = CreateMatrix(matrixCells, matrixSize);
            Vector rightHandSide = CreateRightHandSide(rightHandSideCells, matrixSize);

            return new InputConversionResult(matrix, rightHandSide);
        }

        /// <summary>
        /// Validates the user input for matrix and right-hand side consistency.
        /// </summary>
        /// <param name="matrixCells">The collection of matrix cells to validate.</param>
        /// <param name="rightHandSideCells">The collection of right-hand side cells to validate.</param>
        /// <param name="matrixSize">The expected size of the matrix (n x n).</param>
        private static void ValidateInput(
            ObservableCollection<MatrixCell> matrixCells,
            ObservableCollection<MatrixCell> rightHandSideCells,
            int matrixSize)
        {
            if (matrixCells == null || rightHandSideCells == null)
            {
                throw new ArgumentNullException("Matrix or right-hand side inputs cannot be null.");
            }

            if (matrixSize <= 0)
            {
                throw new ArgumentException("Matrix size must be greater than 0.");
            }

            if (matrixCells.Count != matrixSize * matrixSize || rightHandSideCells.Count != matrixSize)
            {
                throw new ArgumentException("Input size does not match the specified matrix size.");
            }
        }

        /// <summary>
        /// Creates a matrix from the given collection of matrix cells.
        /// </summary>
        /// <param name="matrixCells">The collection of matrix cells to process.</param>
        /// <param name="matrixSize">The size of the matrix (n x n).</param>
        /// <returns>A <see cref="Matrix"/> object populated with the provided values.</returns>
        private static Matrix CreateMatrix(ObservableCollection<MatrixCell> matrixCells, int matrixSize)
        {
            Matrix matrix = new Matrix(matrixSize, matrixSize);

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    string cellValue = matrixCells[i * matrixSize + j].Value;

                    if (!double.TryParse(cellValue, out double parsedValue))
                    {
                        throw new FormatException($"Invalid value in matrix cell ({i + 1}, {j + 1}): {cellValue}");
                    }

                    matrix[i, j] = parsedValue;
                }
            }

            return matrix;
        }

        /// <summary>
        /// Creates a vector from the given collection of right-hand side cells.
        /// </summary>
        /// <param name="rightHandSideCells">The collection of right-hand side cells to process.</param>
        /// <param name="matrixSize">The size of the vector (equal to the matrix size).</param>
        /// <returns>A <see cref="Vector"/> object populated with the provided values.</returns>
        private static Vector CreateRightHandSide(ObservableCollection<MatrixCell> rightHandSideCells, int matrixSize)
        {
            Vector rightHandSide = new Vector(matrixSize);

            for (int i = 0; i < matrixSize; i++)
            {
                string rhsValue = rightHandSideCells[i].Value;

                if (!double.TryParse(rhsValue, out double parsedValue))
                {
                    throw new FormatException($"Invalid value in right-hand side cell {i + 1}: {rhsValue}");
                }

                rightHandSide[i] = parsedValue;
            }

            return rightHandSide;
        }
    }
}