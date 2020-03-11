namespace ShapeAreaLib
{
    using System;
    using System.Collections.Generic;
    using ShapeAreaLib.Shapes;

    /// <summary>
    /// Class for calculating shape area.
    /// </summary>
    public class AreaCalculator
    {
        private Dictionary<int, Type> _getShapeBySidesCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="AreaCalculator"/> class.
        /// </summary>
        /// <param name="useDefaults"> Include default shapes:
        /// one argument - circle;
        /// two arguments - right triangle;
        /// three arguments - triangle.
        /// </param>
        public AreaCalculator(bool useDefaults)
        {
            _getShapeBySidesCount = new Dictionary<int, Type>();
            if (useDefaults)
            {
                _getShapeBySidesCount.Add(1, typeof(Circle));
                _getShapeBySidesCount.Add(2, typeof(RightTriangle));
                _getShapeBySidesCount.Add(3, typeof(Triangle));
            }
        }

        /// <summary>
        /// Add new type to calculations.
        /// </summary>
        /// <param name="sidesCount"> Number of sides. </param>
        /// <param name="t"> Type to include. </param>
        public void AddShapeSidesCountConformity(int sidesCount, Type t)
        {
            _getShapeBySidesCount.Add(sidesCount, t);
        }

        /// <summary>
        /// Remove type from calculations.
        /// </summary>
        /// <param name="sidesCount"> Number of sides. </param>
        public void RemoveShapeSidesCountConformity(int sidesCount)
        {
            _getShapeBySidesCount.Remove(sidesCount);
        }

        /// <summary>
        /// Calculate the area of the shape.
        /// </summary>
        /// <param name="shape"> The shape. </param>
        /// <returns> The shape area. </returns>
        public double Calculate(Shape shape)
        {
            return shape.Area;
        }

        /// <summary>
        /// Calculate the area of the shape by number of arguments,
        /// without knowing type of shape.
        /// </summary>
        /// <param name="sideLengths"> Side lengths. </param>
        /// <returns> Area of the shape. </returns>
        public double Calculate(params double[] sideLengths)
        {
            if (_getShapeBySidesCount.TryGetValue(sideLengths.Length, out var shapeType))
            {
                var shape = (Shape)Build(shapeType, sideLengths);
                return shape.Area;
            }
            else
            {
                throw new ArgumentException("Relevant shape not found");
            }
        }

        private static object Build(Type t, double[] parameters)
        {
            var ctor = t.GetConstructors()[0];
            var objParams = new object[parameters.Length];
            for (var i = 0; i < parameters.Length; i++)
            {
                objParams[i] = parameters[i];
            }

            return ctor.Invoke(objParams);
        }
    }
}
