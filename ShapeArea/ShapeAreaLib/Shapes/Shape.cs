namespace ShapeAreaLib.Shapes
{
    using System;
    using System.Linq;

    /// <summary>
    /// Base shape class.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// </summary>
        /// <param name="lengths"> The lengths of the sides. </param>
        public Shape(params double[] lengths)
        {
            Validate(lengths);
        }

        /// <summary>
        /// Gets the value of shape area.
        /// </summary>
        public abstract double Area { get; }

        /// <summary>
        /// The length parameter cannot be negative.
        /// </summary>
        /// <param name="lengths"> The lengths of the sides. </param>
        protected void Validate(params double[] lengths)
        {
            if (lengths.Any(l => l <= 0))
            {
                throw new ArgumentException("The side length can't be negative or equal to zero");
            }

            AdditionalValidate(lengths);
        }

        /// <summary>
        /// Additional specific validations.
        /// </summary>
        /// <param name="lengths"> The lengths of the sides. </param>
        protected virtual void AdditionalValidate(params double[] lengths)
        {
        }
    }
}
