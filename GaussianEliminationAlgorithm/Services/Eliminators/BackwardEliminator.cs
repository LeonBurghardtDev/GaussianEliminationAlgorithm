using System;
using GaussianEliminationAlgorithm.Interfaces;
using GaussianEliminationAlgorithm.Logging;
using GaussianEliminationAlgorithm.Models;

namespace GaussianEliminationAlgorithm.Services.Eliminators
{
    /// <summary>
    /// Performs backward substitution to solve a linear system of equations.
    /// </summary>
    public class BackwardEliminator : IEliminator
    {
        private readonly CalculationLogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BackwardEliminator"/> class.
        /// </summary>
        /// <param name="logger">The logger used to log steps in the substitution process.</param>
        public BackwardEliminator(CalculationLogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Executes the backward substitution process to solve the system of equations.
        /// </summary>
        /// <param name="matrix">The upper triangular matrix.</param>
        /// <param name="rightHandSide">The right-hand side vector of the equation system.</param>
        /// <returns>The solution vector.</returns>
        public object Execute(Matrix matrix, Vector rightHandSide = null)
        {
            if (rightHandSide == null)
                throw new ArgumentNullException(nameof(rightHandSide), "Right-hand side vector is required for backward substitution.");

            _logger.Log("Starting backward substitution.");

            int n = matrix.Rows;
            Vector solution = new Vector(n);

            // Step 1: Compute x_n
            _logger.Log($"Step 1: Computing x_{n} = b'_{n} / a'_{n},{n}");
            solution[n - 1] = rightHandSide[n - 1] / matrix[n - 1, n - 1];
            _logger.Log($"x_{n} = {solution[n - 1]:F2}");

            // Step 2: Compute x_i for i = n-1, ..., 1
            for (int i = n - 2; i >= 0; i--)
            {
                _logger.Log($"Step 2: Computing x_{i + 1}.");
                double sum = 0;
                for (int j = i + 1; j < n; j++)
                {
                    _logger.Log($"Adding a'_{i + 1},{j + 1} * x_{j + 1} to the sum.");
                    sum += matrix[i, j] * solution[j];
                }

                _logger.Log($"Calculating x_{i + 1} = (b'_{i + 1} - sum) / a'_{i + 1},{i + 1}.");
                solution[i] = (rightHandSide[i] - sum) / matrix[i, i];
                _logger.Log($"x_{i + 1} = {solution[i]:F2}");
            }

            _logger.Log("Backward substitution completed.");
            return solution;
        }
    }
}
