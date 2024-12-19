using GaussianEliminationAlgorithm.Models;

namespace GaussianEliminationAlgorithm.Interfaces
{
    /// <summary>
    /// Interface for matrix eliminators.
    /// </summary>
    public interface IEliminator
    {
        /// <summary>
        /// Executes the elimination process.
        /// </summary>
        /// <param name="matrix">The matrix to process.</param>
        /// <param name="rightHandSide">The right-hand side vector (optional for forward elimination).</param>
        /// <returns>The result of the elimination process (matrix or solution vector).</returns>
        object Execute(Matrix matrix, Vector rightHandSide = null);
    }
}
