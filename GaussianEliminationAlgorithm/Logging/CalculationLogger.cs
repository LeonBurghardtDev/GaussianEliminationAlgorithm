using System.Collections.Generic;
using System.Linq;

namespace GaussianEliminationAlgorithm.Logging
{
    /// <summary>
    /// Logger to store calculation steps.
    /// For simplicity, this logger only stores strings in a stack and does not provide log files etc.
    /// Tho it could be extended to do so pretty easily if necessary.
    /// </summary>
    public class CalculationLogger
    {
        private readonly Stack<string> _logStack = new();

        /// <summary>
        /// Logs a step in the calculation process.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Log(string message)
        {
            _logStack.Push(message);
        }

        /// <summary>
        /// Retrieves all logged steps in reverse order.
        /// </summary>
        /// <returns>A list of log messages.</returns>
        public IEnumerable<string> GetLogs()
        {
            
            return _logStack.Reverse();
        }

        /// <summary>
        /// Clears the log stack.
        /// </summary>
        public void Clear()
        {
            _logStack.Clear();
        }
    }
}
