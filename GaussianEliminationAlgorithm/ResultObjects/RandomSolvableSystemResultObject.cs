namespace GaussianEliminationAlgorithm.ResultObjects
{
    /// <summary>
    /// Represents the result of a generated random solvable linear equation system.
    /// </summary>
    public class RandomSolvableSystemResultObject
    {
        private readonly double[] rightHandSide;
        private readonly Models.Matrix matrix;

        /// <summary>
        /// Gets the matrix of the linear equation system.
        /// </summary>
        public Models.Matrix Matrix => matrix;

        /// <summary>
        /// Gets the right-hand side vector of the linear equation system.
        /// </summary>
        public double[] RightHandSide => rightHandSide;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomSolvableSystemResultObject"/> class.
        /// </summary>
        /// <param name="matrix">The matrix of the system.</param>
        /// <param name="rightHandSide">The right-hand side vector of the system.</param>
        public RandomSolvableSystemResultObject(Models.Matrix matrix, double[] rightHandSide)
        {
            this.matrix = matrix;
            this.rightHandSide = rightHandSide;
        }
    }
}
