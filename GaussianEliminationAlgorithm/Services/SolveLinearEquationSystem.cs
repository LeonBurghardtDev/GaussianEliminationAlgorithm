using GaussianEliminationAlgorithm.Logging;
using GaussianEliminationAlgorithm.Models;
using System;

namespace GaussianEliminationAlgorithm.Services
{
    /// <summary>
    /// Service for solving linear equation systems using Gaussian Elimination.
    /// </summary>
    public class SolveLinearEquationSystem
    {
        private readonly CalculationLogger _logger;
        private readonly CalculationController _calculationController;

        /// <summary>
        /// Initializes a new instance of the <see cref="SolveLinearEquationSystem"/> class.
        /// </summary>
        public SolveLinearEquationSystem()
        {
            _logger = new CalculationLogger();

            // Pass the same logger to both eliminators via CalculationController
            _calculationController = new CalculationController(
                _logger,
                new Eliminators.ForwardEliminator(_logger),
                new Eliminators.BackwardEliminator(_logger)
            );

            _logger.Log("SolveLinearEquationSystem initialized.");
        }

        /// <summary>
        /// Validates the input matrix and right-hand side vector.
        /// </summary>
        /// <param name="matrix">The matrix to validate.</param>
        /// <param name="rightHandSide">The vector to validate.</param>
        /// <returns>True if the inputs are valid; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if any input is null.</exception>
        /// <exception cref="ArgumentException">Thrown if the matrix is not square or dimensions do not match.</exception>
        private bool AreInputsValid(Matrix matrix, Vector rightHandSide)
        {
            _logger.Log("Validating inputs.");

            if (matrix == null)
            {
                _logger.Log("Validation failed: Matrix is null.");
                throw new ArgumentNullException(nameof(matrix));
            }

            if (rightHandSide == null)
            {
                _logger.Log("Validation failed: Right-hand side vector is null.");
                throw new ArgumentNullException(nameof(rightHandSide));
            }

            if (matrix.Rows != matrix.Columns)
            {
                _logger.Log("Validation failed: Matrix is not square.");
                throw new ArgumentException("Matrix must be square.", nameof(matrix));
            }

            if (matrix.Rows != rightHandSide.Length)
            {
                _logger.Log("Validation failed: Matrix and vector dimensions do not match.");
                throw new ArgumentException("Matrix and right-hand side must have the same number of rows.", nameof(rightHandSide));
            }

            _logger.Log("Inputs are valid.");
            return true;
        }

        /// <summary>
        /// Solves a linear equation system using Gaussian Elimination.
        /// </summary>
        /// <param name="matrix">The matrix representing the system.</param>
        /// <param name="rightHandSide">The vector representing the right-hand side of the equations.</param>
        /// <returns>The solution vector, or null if inputs are invalid.</returns>
        public Vector? Solve(Matrix matrix, Vector rightHandSide)
        {
            _logger.Log("Starting the solve process.");

            if (!AreInputsValid(matrix, rightHandSide))
            {
                _logger.Log("Solve process aborted due to invalid inputs.");
                return null;
            }

            _logger.Log("Inputs have been validated.");
            _logger.Log("Solving linear equation system...");

            Vector solution = _calculationController.PerformGaussianElimination(matrix, rightHandSide);

            _logger.Log("Linear equation system solved.");
            return solution;
        }

        /// <summary>
        /// Retrieves the calculation logs.
        /// </summary>
        /// <returns>A string containing all log messages.</returns>
        public string GetLogs()
        {
            _logger.Log("Retrieving logs.");
            return string.Join(Environment.NewLine, _logger.GetLogs());
        }
    }
}
