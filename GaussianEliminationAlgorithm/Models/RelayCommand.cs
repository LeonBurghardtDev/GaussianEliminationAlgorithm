using System;
using System.Windows.Input;

namespace GaussianEliminationAlgorithm
{
    /// <summary>
    /// Implementation of the ICommand interface to handle command logic.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="execute">The action to execute when the command is triggered.</param>
        /// <param name="canExecute">The function to determine if the command can execute. Optional.</param>
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">The command parameter (not used).</param>
        /// <returns>True if the command can execute; otherwise, false.</returns>
        public bool CanExecute(object parameter) => _canExecute?.Invoke() ?? true;

        /// <summary>
        /// Executes the command's action.
        /// </summary>
        /// <param name="parameter">The command parameter (not used).</param>
        public void Execute(object parameter) => _execute();

        /// <summary>
        /// Event triggered when the execution state changes.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Raises the CanExecuteChanged event to signal a change in execution state.
        /// </summary>
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}