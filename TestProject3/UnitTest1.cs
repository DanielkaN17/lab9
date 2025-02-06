using Lab9;
using System.Text;

namespace TestProject3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldInitializeDeafaultValues()
        {
            // Arrange
            int expectedSpeed = 1;
            int expectedDistance = 1;

            // Act
            Runner r = new Runner();

            // Assert
            Assert.AreEqual(expectedSpeed, r.Speed);
            Assert.AreEqual(expectedDistance, r.Distance);
        }

        [TestMethod]
        public void ShouldInitializeDeafaultProperties()
        {
            // Arrange
            double speed = 52;
            double distance = 38;

            // Act
            Runner runner = new Runner(speed, distance);

            // Assert
            Assert.AreEqual(speed, runner.Speed);
            Assert.AreEqual(distance, runner.Distance);
        }

        [TestMethod]
        public void ShouldInitializeWithSameValues()
        {
            // Arrange
            Runner r1 = new Runner(52, 38);

            // Act
            Runner r2 = new Runner(r1);

            // Assert
            Assert.AreEqual(r1.Speed, r2.Speed);
            Assert.AreEqual(r2.Distance, r1.Distance);
        }

        [TestMethod]
        public void Speed_ShouldThrowArgumentException()
        {
            // Arrange
            Runner runner = new Runner();

            // Act & Assert
            var ex = Assert.ThrowsException<ArgumentException>(() => runner.Speed = -1);
            Assert.AreEqual("Скорость не может быть отрицательна", ex.Message);
        }

        [TestMethod]
        public void Distance_ShouldThrowArgumentException()
        {
            // Arrange
            Runner runner = new Runner();

            // Act & Assert
            var ex = Assert.ThrowsException<ArgumentException>(() => runner.Distance = -1);
            Assert.AreEqual("Расстояние не может быть отрицательным", ex.Message);
        }

        [TestMethod]
        public void CalculatingTime_ShouldReturnCorrectTime()
        {
            // Arrange
            Runner runner = new Runner(33, 44);

            // Act
            double time = runner.CalculatingTime();

            // Assert
            Assert.AreEqual(1.33, time);
        }

        [TestMethod]
        public void CalculatingTime_ShouldThrowInvalidOperationException()
        {
            // Arrange
            Runner runner = new Runner(0, 100);

            // Act & Assert
            var ex = Assert.ThrowsException<InvalidOperationException>(() => runner.CalculatingTime());
            Assert.AreEqual("Скорость не может быть равна нулю.", ex.Message);
        }

        [TestMethod]
        public void TimeStatic_ShouldReturnCorrectTime()
        {
            // Arrange
            double speed = 52;
            double distance = 38;

            // Act
            double time = Runner.TimeStatic(speed, distance);

            // Assert
            Assert.AreEqual(0.73, time);
        }

        [TestMethod]
        public void TimeStatic_ShouldThrowArgumentException()
        {
            // Arrange
            double speed = 0;
            double distance = 100;

            // Act & Assert
            var ex = Assert.ThrowsException<ArgumentException>(() => Runner.TimeStatic(speed, distance));
            Assert.AreEqual("Скорость не может быть равна нулю.", ex.Message);
        }

        [TestMethod]
        public void TimeStatic_ShouldThrowArgumentNullException()
        {
            // Arrange & Act & Assert
            var ex = Assert.ThrowsException<ArgumentNullException>(() => Runner.TimeStatic(null));
            Assert.AreEqual("Передан пустой объект (Parameter 'runner')", ex.Message);
        }

        [TestMethod]
        public void TimeStatic_ShouldThrowInvalidOperationException()
        {
            // Arrange
            Runner runner = new Runner(0, 100);

            // Act & Assert
            var ex = Assert.ThrowsException<InvalidOperationException>(() => Runner.TimeStatic(runner));
            Assert.AreEqual("Скорость не может быть равна нулю", ex.Message);
        }

        [TestMethod]
        public void ToString_ShouldReturnCorrectString()
        {
            // Arrange
            var runner = new Runner(52, 38);
            string expected = $"Расстояние: 38 км, Скорость: 52 км/ч,  Время: {runner.CalculatingTime()} ч.";

            // Act
            string result = runner.ToString();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IncrementOperation_ShouldIncreaseDistance()
        {
            // Arrange
            var runner = new Runner(52, 38);
            double initialDistance = runner.Distance;

            // Act
            runner++;

            // Assert
            Assert.AreEqual(initialDistance + 0.1, runner.Distance);
        }

        [TestMethod]
        public void DecrementOperation_ShouldDecreaseSpeed()
        {
            // Arrange
            var runner = new Runner(52, 38);
            double initialSpeed = runner.Speed;

            // Act
            runner--;

            // Assert
            Assert.AreEqual(initialSpeed - 0.05, runner.Speed);
        }

        [TestMethod]
        public void DecrementOperation_ShouldThrowArgumentException()
        {
            // Arrange
            var runner = new Runner(0.04, 100);

            // Act & Assert
            var ex = Assert.ThrowsException<ArgumentException>(() => runner--);
            Assert.AreEqual("Скорость не может быть меньше 0", ex.Message);
        }


        [TestMethod]
        public void ExplicitConversionToDouble_ShouldReturnCorrectValue()
        {
            // Arrange
            var runner = new Runner(10, 100);
            double expected = Math.Round((runner.Distance / (runner.CalculatingTime() * 0.95)) - runner.Speed, 2);

            // Act 
            double result = (double)runner;
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ExplicitConversionToDouble_ShouldThrowArgumentException()
        {
            // Arrange
            var runner = new Runner(0, 100);

            // Act & Assert
            var ex = Assert.ThrowsException<ArgumentException>(() => (double)runner);
            Assert.AreEqual("Скорость должна быть больше нуля.", ex.Message);
        }

        [TestMethod]
        public void ImplicitConversionToString_ShouldReturnCorrectTimeString()
        {
            // Arrange
            var runner = new Runner(52, 38);
            string expected = $"{(int)(runner.CalculatingTime()):D2}:43:48";

            // Act
            string result = (string)runner;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ImplicitConversionToString_ShouldThrowArgumentException()
        {
            // Arrange
            var runner = new Runner(0, 100);

            // Act & Assert
            var ex = Assert.ThrowsException<ArgumentException>(() => (string)runner);
            Assert.AreEqual("Скорость должна быть больше нуля.", ex.Message);
        }

        [TestMethod]
        public void SubtractionOperator_ShouldRetunMeetingDistance()
        {
            // Arrange
            var r1 = new Runner(10, 100);
            var r2 = new Runner(10, 100);

            // Act
            double distance = r1 - r2;

            // Assert
            Assert.AreEqual(7.5, distance);
        }

        [TestMethod]
        public void OperatorMinus_ShouldRetunCorrectDistance()
        {
            // Arrange
            var r1 = new Runner(5, 0);
            var r2 = new Runner(10, 0);
            double expectedDistance = 5; // (5 * (15 / (5 + 10)))

            // Act
            double result = r1 - r2;

            // Assert
            Assert.AreEqual(expectedDistance, result);
        }

        [TestMethod]
        public void OperatorMinus_ShouldRetunNegativeOne()
        {
            // Arrange
            var r1 = new Runner(0, 0);
            var r2 = new Runner(0, 0);

            // Act
            double result = r1 - r2;

            // Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void OperatorCaret_ShouldRetunNewRunnerWithIncreaseSpeed()
        {
            // Arrange
            var runner = new Runner(5, 0);
            double speedIncrease = 3;
            double expectedNewSpeed = 8;

            // Act
            Runner newRunner = runner ^ speedIncrease;

            // Assert
            Assert.AreEqual(expectedNewSpeed, newRunner.Speed);
            Assert.AreEqual(runner.Distance, newRunner.Distance);
        }

        [TestMethod]
        public void Equals_ShouldRetunTrue()
        {
            // Arrange
            var r1 = new Runner(5, 0);
            var r2 = new Runner(5, 0);

            // Act
            bool result = r1.Equals(r2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_ShouldRetunFaalse()
        {
            // Arrange
            var r1 = new Runner(5, 0);
            var r2 = new Runner(6, 0);

            // Act
            bool result = r1.Equals(r2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetHashCode_ShouldRetunSameHashCodeForEqualRunners()
        {
            // Arrange
            var r1 = new Runner(5, 0);
            var r2 = new Runner(5, 0);

            // Act
            int hashCode1 = r1.GetHashCode();
            int hashCode2 = r2.GetHashCode();

            // Assert
            Assert.AreEqual(hashCode1, hashCode2);
        }

        [TestMethod]
        public void ReadNumber_WithValidInput_ShouldReturnCorrectNumber()
        {
            // Arrange
            var input = new StringReader("5");
            Console.SetIn(input);

            // Act
            int result = RunnerArray.ReadNumber();

            // Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void ReadNumber_WithInvalidThenValidInput_ShouldReturnCorrectNumber()
        {
            // Arrange
            var input = new StringReader("-1\n0\n7");
            Console.SetIn(input);

            // Act
            int result = RunnerArray.ReadNumber();

            // Assert
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void CollectionCount_Increases_When_NewInstanceIsCreated()
        {
            // Arrange
            int initialCount = RunnerArray.CollectionCount;

            // Act
            var runnerArray1 = new RunnerArray(5);
            var runnerArray2 = new RunnerArray(3);

            // Assert
            Assert.AreEqual(initialCount + 2, RunnerArray.CollectionCount);
        }

        [TestMethod]
        public void CopyConstructor_ShouldCreateDeepCopy()
        {
            // Arrange
            var originalArray = new RunnerArray(3);
            var originalFirst = originalArray[0];

            // Act
            var copiedArray = new RunnerArray(originalArray);

            // Assert
            Assert.AreNotSame(originalArray[0], copiedArray[0]);
            Assert.AreEqual(originalFirst.Distance, copiedArray[0].Distance);
            Assert.AreEqual(originalFirst.Speed, copiedArray[0].Speed);
        }

        [TestMethod]
        public void Constructor_ShouldCreateArrayWithGivenSize()
        {
            // Arrange
            int size = 5;

            // Act
            var runnerArray = new RunnerArray(size);

            // Assert
            Assert.AreEqual(size, runnerArray.Count);
        }

        [TestMethod]
        public void PrintRunner_ShouldWriteToConsole()
        {
            // Arrange
            var runnerArray = new RunnerArray(2)
            {
                [0] = new Runner(100, 10),
                [1] = new Runner(200, 20)
            };

            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            runnerArray.PrintRunner();

            // Assert
            var output = consoleOutput.ToString();
            Assert.IsTrue(output.Contains("Бегун 1"));
            Assert.IsTrue(output.Contains("Бегун 2"));
        }

        [TestMethod]
        public void SortRunners_ShouldPrintMessage()
        {
            // Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            var runnerArray = new RunnerArray(0);

            // Act
            runnerArray.SortRunners();

            // Assert
            Assert.IsTrue(consoleOutput.ToString().Contains("Массив пуст"));
        }

        [TestMethod]
        public void Indexer_ShouldReturnCorrectRunner()
        {
            // Arrange
            var runnerArray = new RunnerArray(3);
            var firstRunner = runnerArray[0];

            // Assert
            Assert.IsNotNull(firstRunner);
        }

        [TestMethod]
        public void Indexer_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            var runnerArray = new RunnerArray(3);

            // Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => runnerArray[-1]);
            Assert.ThrowsException<IndexOutOfRangeException>(() => runnerArray[3]);
        }

        [TestMethod]
        public void CollectionCount_ShouldIncrementWithEachNewArray()
        {
            // Arrange
            int initialCount = RunnerArray.CollectionCount;

            // Act
            var array1 = new RunnerArray(3);
            var array2 = new RunnerArray(array1);

            // Assert
            Assert.AreEqual(initialCount + 2, RunnerArray.CollectionCount);
        }

        [TestMethod]
        public void Count_ShouldReturnZero()
        {
            // Arrange
            RunnerArray nullArray = null;

            // Assert
            Assert.AreEqual(0, nullArray?.Count ?? 0);
        }

        [TestMethod]
        public void PrintRunner_ShouldNotThrowExceptionForEmptyArray()
        {
            // Arrange
            var emptyArray = new RunnerArray(0);

            // Act & Assert (Ensures no exception is thrown)
            emptyArray.PrintRunner();
        }

        [TestMethod]
        public void Constructor_ShouldThrowArgumentOutOfRangeException()
        {
            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new RunnerArray(-1));
        }

        [TestMethod]
        public void CalculatingTime_ShouldCalculateCorrectly()
        {
            // Arrange
            var runner = new Runner(10, 100);

            // Act
            double time = runner.CalculatingTime();

            // Assert
            Assert.AreEqual(10, time);
        }
    }
}