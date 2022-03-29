using GameofLife;

using System;
using System.IO;
using System.Reflection;

using Xunit;

namespace XUnitTestCase
{
    public class GameofLifeTestCase
    {
        #region Mock Objects
        string basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location.Replace("bin\\Debug\\netcoreapp3.1", string.Empty));
        string pathTestCase1 = @"TestCases\TestCase1.txt";
        string pathTestCase2 = @"TestCases\TestCase2.txt";
        string pathTestCase3 = @"TestCases\TestCase3.txt";

        string outputTestCase1 = "[(1,2),(2,2),(3,2)]";
        string outputTestCase2 = "[(9,10),(10,11),(10,12),(11,10),(11,11)]";
        string outputTestCase3 = "[(1,2),(2,1),(2,3),(3,2)]";
        #endregion
        [Fact]
        public void TestCase1()
        {
            //Act
            var location = Path.Combine(basePath, pathTestCase1);

            //Arrange
            string result = Program.FindGeneration(location);

            //Assert
            Assert.Equal(outputTestCase1, result);
        }

        [Fact]
        public void TestCase2()
        {
            //Act
            var location = Path.Combine(basePath, pathTestCase2);

            //Arrange
            string result = Program.FindGeneration(location);

            //Assert
            Assert.Equal(outputTestCase2, result);
        }

        [Fact]
        public void TestCase3()
        {
            //Act
            var location = Path.Combine(basePath, pathTestCase3);

            //Arrange
            string result = Program.FindGeneration(location);

            //Assert
            Assert.Equal(outputTestCase3, result);
        }
    }
}
