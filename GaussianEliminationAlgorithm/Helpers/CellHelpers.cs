namespace GaussianEliminationAlgorithm.Helpers
{
    /// <summary>
    /// Provides helper methods for generating cell indices and converting numbers to subscript format.
    /// </summary>
    public class CellHelpers
    {
        /// <summary>
        /// Generates the cell index string for a matrix cell using a variable name and row/column indices.
        /// </summary>
        /// <param name="var">The variable name (e.g., 'x' or 'b').</param>
        /// <param name="row">The row index of the cell.</param>
        /// <param name="column">The column index of the cell.</param>
        /// <returns>The formatted cell index string.</returns>
        public static string GetCellIndex(char var, int row, int column)
        {
            return $"{var}{ConvertToSubscript(row)}{ConvertToSubscript(column)}";
        }

        /// <summary>
        /// Generates the cell index string for a right-hand side cell using a variable name and row index.
        /// </summary>
        /// <param name="var">The variable name (e.g., 'b').</param>
        /// <param name="row">The row index of the cell.</param>
        /// <returns>The formatted cell index string.</returns>
        public static string GetCellIndex(char var, int row)
        {
            return $"{var}{ConvertToSubscript(row)}";
        }

        /// <summary>
        /// Converts an integer number to its corresponding subscript representation.
        /// </summary>
        /// <param name="number">The number to convert.</param>
        /// <returns>The number in subscript format as a string.</returns>
        private static string ConvertToSubscript(int number)
        {
            char[] subscriptDigits = new[] { '\u2080', '\u2081', '\u2082', '\u2083', '\u2084', '\u2085', '\u2086', '\u2087', '\u2088', '\u2089' };
            string subscript = string.Empty;
            foreach (char digit in number.ToString())
            {
                subscript += subscriptDigits[digit - '0'];
            }
            return subscript;
        }
    }
}