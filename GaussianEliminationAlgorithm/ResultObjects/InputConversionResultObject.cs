using GaussianEliminationAlgorithm.Models;
using System;

namespace GaussianEliminationAlgorithm.ResultObjects
{
    /// <summary>
    /// Represents the result of converting user input into structured data.
    /// </summary>
    public class InputConversionResult
    {
        /// <summary>
        /// Gets the matrix from the conversion result.
        /// </summary>
        public Matrix Matrix { get; }

        /// <summary>
        /// Gets the right-hand side vector from the conversion result.
        /// </summary>
        public Vector RightHandSide { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputConversionResult"/> class.
        /// </summary>
        /// <param name="matrix">The converted matrix.</param>
        /// <param name="rightHandSide">The converted right-hand side vector.</param>
        public InputConversionResult(Matrix matrix, Vector rightHandSide)
        {
            Matrix = matrix ?? throw new ArgumentNullException(nameof(matrix));
            RightHandSide = rightHandSide ?? throw new ArgumentNullException(nameof(rightHandSide));
        }
    }
}
