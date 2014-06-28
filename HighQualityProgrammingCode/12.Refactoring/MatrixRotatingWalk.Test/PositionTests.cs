namespace MatrixRotatingWalk.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Matrix;

    [TestClass]
    public class PositionTests
    {
        [TestMethod]
        public void FiveRowsConstructorTest()
        {
            var expectedRowPosition = 15;

            Position position = new Position(15, 3);
            Assert.AreEqual(expectedRowPosition, position.Row);
        }

        [TestMethod]
        public void FiveColsConstructorTest()
        {
            var expectedColPosition = 12;

            Position position = new Position(3, 12);
            Assert.AreEqual(expectedColPosition, position.Column);
        }

        [TestMethod]
        public void ParameterlessRowsConstructorTest()
        {
            var expectedRowPosition = 0;

            Position position = new Position();
            Assert.AreEqual(expectedRowPosition, position.Row);
        }

        [TestMethod]
        public void ParameterlessColsConstructorTest()
        {
            var expectedColPosition = 0;

            Position position = new Position();
            Assert.AreEqual(expectedColPosition, position.Column);
        }

        [TestMethod]
        public void PositionToStringTest()
        {
            var expectedToStringResult = "43 -31";

            Position position = new Position(43, -31);
            Assert.AreEqual(expectedToStringResult, position.ToString());
        }
    }
}
