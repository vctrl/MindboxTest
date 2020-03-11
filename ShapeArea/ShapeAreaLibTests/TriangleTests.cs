namespace ShapeAreaLibTests
{
    using System;
    using ShapeAreaLib.Shapes;
    using NUnit.Framework;

    public class TriangleTests
    {
        [Test]
        public void TestNegativeOrZeroValues()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(-1, 1, 1));
            Assert.Throws<ArgumentException>(() => new Triangle(1, -1, 1));
            Assert.Throws<ArgumentException>(() => new Triangle(1, 1, -1));

            Assert.Throws<ArgumentException>(() => new Triangle(0, 1, 1));
            Assert.Throws<ArgumentException>(() => new Triangle(1, 0, 1));
            Assert.Throws<ArgumentException>(() => new Triangle(1, 1, 0));
        }

        [Test]
        public void TestIsRight()
        {
            var rightTriangle1 = new Triangle(8d, 9d, 12.0415945d);
            Assert.IsTrue(rightTriangle1.IsRight);
            var rightTriangle2 = new RightTriangle(13d, 46d);
            Assert.IsTrue(rightTriangle2.IsRight);
            var notRightTriangle = new Triangle(3d, 4d, 6d);
            Assert.IsFalse(notRightTriangle.IsRight);
        }

        [Test]
        public void TestInequality()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(4, 5, 11));
            Assert.Throws<ArgumentException>(() => new Triangle(4, 11, 5));
            Assert.Throws<ArgumentException>(() => new Triangle(16, 1, 2));
        }

        [Test]
        public void TestAreaCalculate()
        {
            var triangle1 = new Triangle(3, 4, 5);
            Assert.AreEqual(triangle1.Area, 6);
            var triangle2 = new Triangle(11, 12, 13);
            Assert.AreEqual(triangle2.Area, 61.481704595757591d);
        }
    }
}
