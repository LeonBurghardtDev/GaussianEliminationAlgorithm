using System;

namespace GaussianEliminationAlgorithm.Models
{
    /// <summary>
    /// Represents a mathematical vector.
    /// </summary>
    public class Vector
    {
        public double[] Values { get; private set; }

        /// <summary>
        /// Gets the number of elements in the vector.
        /// </summary>
        public int Length => Values.Length;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector"/> class.
        /// </summary>
        /// <param name="size">The size of the vector.</param>
        public Vector(int size)
        {
            if (size <= 0)
                throw new ArgumentException("Vector size must be greater than 0.", nameof(size));

            Values = new double[size];
        }

        /// <summary>
        /// Indexer for accessing vector elements.
        /// </summary>
        /// <param name="index">The index of the element.</param>
        /// <returns>The value at the specified index.</returns>
        public double this[int index]
        {
            get => Values[index];
            set => Values[index] = value;
        }

        /// <summary>
        /// Creates a deep copy of the vector.
        /// </summary>
        public Vector DeepCopy()
        {
            Vector copy = new Vector(Length);
            for (int i = 0; i < Length; i++)
            {
                copy[i] = this[i];
            }
            return copy;
        }


        /// <summary>
        /// Converts the vector to a string representation.
        /// </summary>
        /// <returns>A string representation of the vector.</returns>
        public override string ToString()
        {
            return string.Join(", ", Values);
        }

        /// <summary>
        /// Creates a copy of the vector.
        /// </summary>
        /// <returns>A new vector with the same values.</returns>
        public Vector Clone()
        {
            var clone = new Vector(Length);
            Array.Copy(Values, clone.Values, Length);
            return clone;
        }
    }
}
