using System;

namespace GaussianEliminationAlgorithm.Models
{
    /// <summary>
    /// Represents a mathematical matrix with methods to simplify matrix operations.
    /// </summary>
    public class Matrix
    {
        /// <summary>
        /// Gets or sets the values of the matrix.
        /// </summary>
        public double[,] Values { get; set; }

        /// <summary>
        /// Gets the number of rows in the matrix.
        /// </summary>
        public int Rows => Values.GetLength(0);

        /// <summary>
        /// Gets the number of columns in the matrix.
        /// </summary>
        public int Columns => Values.GetLength(1);

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class with the specified dimensions.
        /// </summary>
        /// <param name="rows">The number of rows in the matrix.</param>
        /// <param name="columns">The number of columns in the matrix.</param>
        public Matrix(int rows, int columns)
        {
            Values = new double[rows, columns];
        }

        /// <summary>
        /// Provides indexed access to the matrix elements.
        /// </summary>
        /// <param name="row">The row index.</param>
        /// <param name="column">The column index.</param>
        /// <returns>The value at the specified position in the matrix.</returns>
        public double this[int row, int column]
        {
            get => Values[row, column];
            set => Values[row, column] = value;
        }

        /// <summary>
        /// Creates a matrix from a 2D array.
        /// </summary>
        /// <param name="array">The 2D array to convert into a matrix.</param>
        /// <returns>A new matrix initialized with the array's values.</returns>
        public static Matrix FromArray(double[,] array)
        {
            return new Matrix(array.GetLength(0), array.GetLength(1)) { Values = array };
        }

        /// <summary>
        /// Creates a deep copy of the matrix.
        /// </summary>
        public Matrix DeepCopy()
        {
            Matrix copy = new Matrix(Rows, Columns);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    copy[i, j] = this[i, j];
                }
            }
            return copy;
        }

        /// <summary>
        /// Converts the matrix to a string representation.
        /// </summary>
        /// <returns>A string representation of the matrix with formatted values.</returns>
        public override string ToString()
        {
            string result = string.Empty;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result += $"{Values[i, j]:0.00}\t";
                }
                result += "\n";
            }
            return result;
        }
    }
}