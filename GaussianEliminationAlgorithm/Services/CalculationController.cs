using GaussianEliminationAlgorithm.Interfaces;
using GaussianEliminationAlgorithm.Logging;
using GaussianEliminationAlgorithm.Models;
using GaussianEliminationAlgorithm.Services.Eliminators;
using System.Collections.Generic;

namespace GaussianEliminationAlgorithm.Services
{
    /// <summary>
    /// Manages the execution of Gaussian Elimination steps and retrieves calculation logs.
    /// </summary>
    public class CalculationController
    {
        private readonly CalculationLogger _logger;
        private readonly IEliminator _forwardEliminator;
        private readonly IEliminator _backwardEliminator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalculationController"/> class.
        /// </summary>
        /// <param name="logger">The logger used for tracking calculations.</param>
        /// <param name="forwardEliminator">The forward eliminator instance.</param>
        /// <param name="backwardEliminator">The backward eliminator instance.</param>
        /// <exception cref="ArgumentNullException">Thrown if any of the parameters are null.</exception>
        public CalculationController(CalculationLogger logger, IEliminator forwardEliminator, IEliminator backwardEliminator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _forwardEliminator = forwardEliminator ?? throw new ArgumentNullException(nameof(forwardEliminator));
            _backwardEliminator = backwardEliminator ?? throw new ArgumentNullException(nameof(backwardEliminator));
        }

        /// <summary>
        /// Performs the Gaussian Elimination algorithm on the given matrix.
        /// </summary>
        /// <param name="matrix">The matrix to process using Gaussian Elimination.</param>
        /// <param name="rightHandSide">The right-hand side vector for solving equations.</param>
        /// <returns>
        /// The solution vector after performing forward and backward elimination.
        /// </returns>
        public Vector PerformGaussianElimination(Matrix matrix, Vector rightHandSide)
        {
            Log("Starting Gaussian Elimination.");

            // Step 1: Forward Elimination
            Matrix upperTriangularMatrix = (Matrix)_forwardEliminator.Execute(matrix);

            // Step 2: Backward Substitution
            Vector solution = (Vector)_backwardEliminator.Execute(upperTriangularMatrix, rightHandSide);

            Log("Gaussian Elimination completed.");
            return solution;
        }

        /// <summary>
        /// Retrieves the calculation logs.
        /// </summary>
        /// <returns>A list of log messages.</returns>
        public IEnumerable<string> GetCalculationLogs()
        {
            return _logger.GetLogs();
        }

        /// <summary>
        /// Logs a message to the shared logger.
        /// </summary>
        /// <param name="message">The message to log.</param>
        private void Log(string message)
        {
            _logger.Log(message);
        }
    }
}
