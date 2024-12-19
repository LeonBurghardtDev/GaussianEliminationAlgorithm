using System.Collections.ObjectModel;
using System.Windows.Input;
using GaussianEliminationAlgorithm.ResultObjects;
using GaussianEliminationAlgorithm.Services;
using GaussianEliminationAlgorithm.Helpers;
using GaussianEliminationAlgorithm.Converters;
using System.Windows;
using GaussianEliminationAlgorithm.Models;

namespace GaussianEliminationAlgorithm.ViewModels
{
    /// <summary>
    /// ViewModel for managing the Gaussian Elimination UI and operations.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private int _matrixSize;
        private int _currentMatrixSize;
        private ObservableCollection<MatrixCell> _matrix;
        private ObservableCollection<MatrixCell> _rightHandSide; // Represents vector b, using matrix cells for UI simplicity

        /// <summary>
        /// Size of the matrix (n x n).
        /// </summary>
        public int MatrixSize
        {
            get => _matrixSize;
            set
            {
                if (value > 0 && value <= 10) // Limit the matrix size to 10 for UI simplicity
                {
                    _matrixSize = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Current size of the matrix, used internally.
        /// </summary>
        public int CurrentMatrixSize => _currentMatrixSize;

        /// <summary>
        /// ObservableCollection representing the matrix cells.
        /// </summary>
        public ObservableCollection<MatrixCell>? Matrix
        {
            get => _matrix;
            private set
            {
                _matrix = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// ObservableCollection representing the right-hand side (vector b).
        /// </summary>
        public ObservableCollection<MatrixCell>? RightHandSide
        {
            get => _rightHandSide;
            private set
            {
                _rightHandSide = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Command to generate the matrix structure.
        /// </summary>
        public ICommand GenerateMatrixCommand { get; }

        /// <summary>
        /// Command to calculate the result of the matrix.
        /// </summary>
        public ICommand CalculateCommand { get; }

        /// <summary>
        /// Command to reset the matrix and UI.
        /// </summary>
        public ICommand ResetCommand { get; }

        /// <summary>
        /// Command to fill the matrix with random numbers.
        /// </summary>
        public ICommand FillMatrixWithRandomNumbersCommand { get; }

        /// <summary>
        /// Initializes the MainViewModel and its commands.
        /// </summary>
        public MainViewModel()
        {
            GenerateMatrixCommand = new RelayCommand(GenerateMatrix);
            CalculateCommand = new RelayCommand(CalculateMatrix);
            ResetCommand = new RelayCommand(ResetMatrix);
            FillMatrixWithRandomNumbersCommand = new RelayCommand(FillMatrixWithRandomNumbers);

            _currentMatrixSize = 0;
        }

        /// <summary>
        /// Generates an empty matrix and initializes the right-hand side vector.
        /// </summary>
        private void GenerateMatrix()
        {
            _currentMatrixSize = _matrixSize;
            Matrix = new ObservableCollection<MatrixCell>();
            RightHandSide = new ObservableCollection<MatrixCell>();

            for (int i = 1; i <= _matrixSize; i++) // Row
            {
                for (int j = 1; j <= _matrixSize; j++) // Column
                {
                    Matrix.Add(new MatrixCell { Index = CellHelpers.GetCellIndex('x', i, j), Value = "0" });
                }

                RightHandSide.Add(new MatrixCell { Index = CellHelpers.GetCellIndex('b', i), Value = "0" });
            }
        }

        /// <summary>
        /// Fills the matrix and right-hand side with random numbers, ensuring a solvable system.
        /// </summary>
        private void FillMatrixWithRandomNumbers()
        {
            if (Matrix == null || RightHandSide == null || _currentMatrixSize == 0)
                return;

            if (_currentMatrixSize != _matrixSize)
            {
                GenerateMatrix();
            }

            RandomSolvableSystemResultObject randomSolvableSystemResultObject = LinearEquationGenerator.GenerateRandomSolvableSystem(_matrixSize);

            int matrixIndex = 0;
            for (int i = 0; i < _matrixSize; i++)
            {
                for (int j = 0; j < _matrixSize; j++)
                {
                    Matrix[matrixIndex++].Value = randomSolvableSystemResultObject.Matrix[i, j].ToString();
                }
            }

            for (int i = 0; i < _matrixSize; i++)
            {
                RightHandSide[i].Value = randomSolvableSystemResultObject.RightHandSide[i].ToString();
            }

            // Forcing UI update here
            Matrix = new ObservableCollection<MatrixCell>(Matrix);
            RightHandSide = new ObservableCollection<MatrixCell>(RightHandSide);
        }

        /// <summary>
        /// Placeholder for calculating the result of the matrix.
        /// </summary>
        private void CalculateMatrix()
        {
            try
            {
                GaussianElimination.Execute(Matrix, RightHandSide, _currentMatrixSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while calculating the matrix: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Resets the matrix size, current matrix, and right-hand side.
        /// </summary>
        private void ResetMatrix()
        {
            MatrixSize = 0;
            _currentMatrixSize = 0;
            Matrix = null;
            RightHandSide = null;
        }
    }
}
