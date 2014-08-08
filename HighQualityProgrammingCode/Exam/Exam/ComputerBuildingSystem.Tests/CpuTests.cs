using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;

namespace ComputerBuildingSystem.Tests
{
    [TestClass]
    public class CpuTests
    {
        private const int InitialTestsCpuCores = 4;
        private const int Initial32BitCpu = 32;
        private const int Initial64BitCpu = 64;
        private const int Initial128BitCpu = 128;

        private ICpu cpuWith32Bits;
        private ICpu cpuWith64Bits;
        private ICpu cpuWith128Bits;

        [TestInitialize]
        public void InitializeCpu()
        {
            this.Initialize32BitCpu();
            this.Initialize64BitCpu();
            this.Initialize128BitCpu();
        }

        // Random number generating tests
        [TestMethod]
        public void CpusGetRandomNumberFrom1To1Test()
        {
            var actualValueFrom32BitsCpu = this.cpuWith32Bits.GenerateRandomNumber(1, 1);
            var actualValueFrom64BitsCpu = this.cpuWith64Bits.GenerateRandomNumber(1, 1);
            var actualValueFrom128BitsCpu = this.cpuWith128Bits.GenerateRandomNumber(1, 1);
            var expectedValue = 1;

            Assert.AreEqual(expectedValue, actualValueFrom32BitsCpu);
            Assert.AreEqual(expectedValue, actualValueFrom64BitsCpu);
            Assert.AreEqual(expectedValue, actualValueFrom128BitsCpu);
        }

        [TestMethod]
        public void CpusGetRandomNumberInRangeTest()
        {
            var actualValueFrom32BitsCpu = this.cpuWith32Bits.GenerateRandomNumber(1, 10);
            var actualValueFrom64BitsCpu = this.cpuWith64Bits.GenerateRandomNumber(10, 20);
            var actualValueFrom128BitsCpu = this.cpuWith128Bits.GenerateRandomNumber(20, 30);

            var isGeneratedBy32BitsCpuValueInRange = actualValueFrom32BitsCpu >= 1 && actualValueFrom32BitsCpu <= 10;
            var isGeneratedBy64BitsCpuValueInRange = actualValueFrom64BitsCpu >= 10 && actualValueFrom64BitsCpu <= 20;
            var isGeneratedBy128BitsCpuValueInRange = actualValueFrom128BitsCpu >= 20 && actualValueFrom128BitsCpu <= 30;

            Assert.AreEqual(true, isGeneratedBy32BitsCpuValueInRange);
            Assert.AreEqual(true, isGeneratedBy64BitsCpuValueInRange);
            Assert.AreEqual(true, isGeneratedBy128BitsCpuValueInRange);
        }

        // Random number generating test with Just Mock
        [TestMethod]
        public void CpuRandomNumberGeneratorTestWithJustMock()
        {
            var mocked = Mock.Create<ICpu>();

            Mock.Arrange(() => mocked.GenerateRandomNumber(Arg.AnyInt, Arg.AnyInt)).Returns(5);

            Assert.AreEqual(5, mocked.GenerateRandomNumber(1, 20));
            Assert.AreEqual(5, mocked.GenerateRandomNumber(18, 20));
            Assert.AreEqual(5, mocked.GenerateRandomNumber(90, 100));
            Assert.AreEqual(5, mocked.GenerateRandomNumber(1, 2));
        }

        // Square number in range tests
        [TestMethod]
        public void CpuGetFormattedSquareNumberInRangeResult()
        {
            var numberToTest = 200;
            var expectedValue = 200 * 200;
            var expectedFormattedResult = string.Format(BaseSquareNumberFinder.PrintedMessageFormat, numberToTest, expectedValue);

            var actualFormattedResultBy32BitsCpu = this.cpuWith32Bits.GetFormattedSquareNumber(numberToTest);
            var actualFormattedResultBy64BitsCpu = this.cpuWith64Bits.GetFormattedSquareNumber(numberToTest);
            var actualFormattedResultBy128BitsCpu = this.cpuWith128Bits.GetFormattedSquareNumber(numberToTest);

            Assert.AreEqual(expectedFormattedResult, actualFormattedResultBy32BitsCpu);
            Assert.AreEqual(expectedFormattedResult, actualFormattedResultBy64BitsCpu);
            Assert.AreEqual(expectedFormattedResult, actualFormattedResultBy128BitsCpu);
        }

        [TestMethod]
        public void Cpu32BitsGetFormattedSquareNumberInUpperBoundaryRangeResult()
        {
            var numberToTest = Cpu32BitsSquareNumberFinder.MaximumNumberValue;
            var expectedValue = numberToTest * numberToTest;
            var expectedFormattedResult = string.Format(BaseSquareNumberFinder.PrintedMessageFormat, numberToTest, expectedValue);

            var actualFormattedResult = this.cpuWith64Bits.GetFormattedSquareNumber(numberToTest);

            Assert.AreEqual(expectedFormattedResult, actualFormattedResult);
        }

        [TestMethod]
        public void Cpu64BitsGetFormattedSquareNumberInUpperBoundaryRangeResult()
        {
            var numberToTest = Cpu64BitsSquareNumberFinder.MaximumNumberValue;
            var expectedValue = numberToTest * numberToTest;
            var expectedFormattedResult = string.Format(BaseSquareNumberFinder.PrintedMessageFormat, numberToTest, expectedValue);

            var actualFormattedResult = this.cpuWith64Bits.GetFormattedSquareNumber(numberToTest);

            Assert.AreEqual(expectedFormattedResult, actualFormattedResult);
        }

        [TestMethod]
        public void Cpu128BitsGetFormattedSquareNumberInUpperBoundaryRangeResult()
        {
            var numberToTest = Cpu128BitsSquareNumberFinder.MaximumNumberValue;
            var expectedValue = numberToTest * numberToTest;
            var expectedFormattedResult = string.Format(BaseSquareNumberFinder.PrintedMessageFormat, numberToTest, expectedValue);

            var actualFormattedResult = this.cpuWith128Bits.GetFormattedSquareNumber(numberToTest);

            Assert.AreEqual(expectedFormattedResult, actualFormattedResult);
        }

        [TestMethod]
        public void Cpu32BitsGetFormattedSquareNumberInLowerBoundaryRangeResult()
        {
            var numberToTest = Cpu32BitsSquareNumberFinder.MinimumNumberValue;
            var expectedValue = numberToTest * numberToTest;
            var expectedFormattedResult = string.Format(BaseSquareNumberFinder.PrintedMessageFormat, numberToTest, expectedValue);

            var actualFormattedResult = this.cpuWith64Bits.GetFormattedSquareNumber(numberToTest);

            Assert.AreEqual(expectedFormattedResult, actualFormattedResult);
        }

        [TestMethod]
        public void Cpu64BitsGetFormattedSquareNumberInLowerBoundaryRangeResult()
        {
            var numberToTest = Cpu64BitsSquareNumberFinder.MinimumNumberValue;
            var expectedValue = numberToTest * numberToTest;
            var expectedFormattedResult = string.Format(BaseSquareNumberFinder.PrintedMessageFormat, numberToTest, expectedValue);

            var actualFormattedResult = this.cpuWith64Bits.GetFormattedSquareNumber(numberToTest);

            Assert.AreEqual(expectedFormattedResult, actualFormattedResult);
        }

        [TestMethod]
        public void Cpu128BitsGetFormattedSquareNumberInLowerBoundaryRangeResult()
        {
            var numberToTest = Cpu128BitsSquareNumberFinder.MinimumNumberValue;
            var expectedValue = numberToTest * numberToTest;
            var expectedFormattedResult = string.Format(BaseSquareNumberFinder.PrintedMessageFormat, numberToTest, expectedValue);

            var actualFormattedResult = this.cpuWith128Bits.GetFormattedSquareNumber(numberToTest);

            Assert.AreEqual(expectedFormattedResult, actualFormattedResult);
        }

        // Square number out of lower boundary tests
        [TestMethod]
        public void CpusNegativeNumberTests()
        {
            var expectedResult = BaseSquareNumberFinder.NumberTooLowMessage;

            var actualResultFrom32BitsCpu = this.cpuWith32Bits.GetFormattedSquareNumber(-5);
            var actualResultFrom64BitsCpu = this.cpuWith32Bits.GetFormattedSquareNumber(-5);
            var actualResultFrom128BitsCpu = this.cpuWith32Bits.GetFormattedSquareNumber(-5);

            Assert.AreEqual(expectedResult, actualResultFrom32BitsCpu);
            Assert.AreEqual(expectedResult, actualResultFrom64BitsCpu);
            Assert.AreEqual(expectedResult, actualResultFrom128BitsCpu);
        }

        // Square number out of upper boundary tests
        [TestMethod]
        public void Cpu32BitsHigherThanPossibleNumberUpperBoundTest()
        {
            var numberToTestWith = Cpu32BitsSquareNumberFinder.MaximumNumberValue + 10;
            var actualResultFrom32BitsCpu = this.cpuWith32Bits.GetFormattedSquareNumber(numberToTestWith);

            var expectedResult = BaseSquareNumberFinder.NumberTooHighMessage;

            Assert.AreEqual(expectedResult, actualResultFrom32BitsCpu);
        }

        [TestMethod]
        public void Cpu64BitsHigherThanPossibleNumberUpperBoundTest()
        {
            var numberToTestWith = Cpu64BitsSquareNumberFinder.MaximumNumberValue + 10;
            var actualResultFrom64BitsCpu = this.cpuWith64Bits.GetFormattedSquareNumber(numberToTestWith);

            var expectedResult = BaseSquareNumberFinder.NumberTooHighMessage;

            Assert.AreEqual(expectedResult, actualResultFrom64BitsCpu);
        }

        [TestMethod]
        public void Cpu128BitsHigherThanPossibleNumberUpperBoundTest()
        {
            var numberToTestWith = Cpu128BitsSquareNumberFinder.MaximumNumberValue + 10;
            var actualResultFrom128BitsCpu = this.cpuWith128Bits.GetFormattedSquareNumber(numberToTestWith);

            var expectedResult = BaseSquareNumberFinder.NumberTooHighMessage;

            Assert.AreEqual(expectedResult, actualResultFrom128BitsCpu);
        }

        private void Initialize32BitCpu()
        {
            var ram = new Ram(4);
            var videoCard = new ColorfulVideoCard();
            var cpuSquareNumberFinder = new Cpu32BitsSquareNumberFinder();
            this.cpuWith32Bits = new Cpu(InitialTestsCpuCores, Initial32BitCpu, ram, videoCard, cpuSquareNumberFinder);
        }

        private void Initialize64BitCpu()
        {
            var ram = new Ram(8);
            var videoCard = new ColorfulVideoCard();
            var cpuSquareNumberFinder = new Cpu64BitsSquareNumberFinder();
            this.cpuWith64Bits = new Cpu(InitialTestsCpuCores, Initial64BitCpu, ram, videoCard, cpuSquareNumberFinder);
        }

        private void Initialize128BitCpu()
        {
            var ram = new Ram(16);
            var videoCard = new ColorfulVideoCard();
            var cpuSquareNumberFinder = new Cpu128BitsSquareNumberFinder();
            this.cpuWith128Bits = new Cpu(InitialTestsCpuCores, Initial128BitCpu, ram, videoCard, cpuSquareNumberFinder);
        }
    }
}
