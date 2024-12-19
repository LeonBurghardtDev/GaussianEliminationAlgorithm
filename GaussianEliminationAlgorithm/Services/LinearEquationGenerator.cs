using System;
using GaussianEliminationAlgorithm.Models;
using GaussianEliminationAlgorithm.Helpers;
using GaussianEliminationAlgorithm.ResultObjects;

namespace GaussianEliminationAlgorithm.Services
{
    /// <summary>
    /// Provides functionality to generate random solvable linear equation systems.
    /// </summary>
    public static class LinearEquationGenerator
    {
        /// <summary>
        /// Generates a random solvable linear equation system.
        /// </summary>
        /// <param name="size">The size of the square matrix (n x n).</param>
        /// <returns>A <see cref="RandomSolvableSystemResultObject"/> containing the matrix and right-hand side vector.</returns>
        /// <exception cref="ArgumentException">Thrown if the matrix size is less than or equal to zero.</exception>
        public static RandomSolvableSystemResultObject GenerateRandomSolvableSystem(int size)
        {
            if (size <= 0) throw new ArgumentException("Matrix size must be greater than 0.", nameof(size));

            Random random = new Random();
            Matrix matrix;
            double[] rightHandSide;
            bool isSolvable = false;

            do
            {
                matrix = new Matrix(size, size);
                rightHandSide = new double[size];

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        matrix[i, j] = random.Next(1, 10);
                    }
                    rightHandSide[i] = random.Next(1, 10);
                }

                if (MatrixUtilities.IsMatrixInvertible(matrix))
                {
                    isSolvable = true;
                }
            } while (!isSolvable);

            return new RandomSolvableSystemResultObject(matrix, rightHandSide);
        }
    }
}
