namespace ShapeAreaLib.Shapes
{
    using System;

    /// <summary>
    /// The circle shape
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="radius"> The radius. </param>
        public Circle(double radius) : base(radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Gets the radius.
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// The area of the circle.
        /// </summary>
        public override double Area => Math.PI * Math.Pow(Radius, 2);

        public override string ToString()
        {
            return $"Circle with radius {Radius}";
        }
    }
}
