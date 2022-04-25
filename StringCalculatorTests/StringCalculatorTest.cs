using System;
using SimpleStringCalculator;
using Xunit;

namespace StringCalculatorTests
{
    public class StringCalculatorTest
    {
        private readonly StringCalculator _stringCalculator;
        public StringCalculatorTest()
        {
            _stringCalculator = new StringCalculator();
        }

        [Fact]
        public void AddShouldReturnZeroIfInputIsNullOrEmpty()
        {
            //Act
            int results = _stringCalculator.Add("");

            //Assert
            Assert.Equal(0, results);
        }

        [Theory]
        [InlineData("1",1)]
        [InlineData("2", 2)]
        [InlineData("3", 3)]
        public void AddShouldReturnSameNumberIfInputStringIsOneValidNumber(string number, int expectedResult)
        {
            //Act
            int results = _stringCalculator.Add(number);

            //Assert
            Assert.Equal(expectedResult, results);
        }
        [Theory]
        [InlineData("1,3", 4)]
        [InlineData("2,2", 4)]
        [InlineData("3,5", 8)]
        public void AddShouldReturnSumOfValidSeparatedCommaStringInput(string number, int expectedResult)
        {
            //Act
            int results = _stringCalculator.Add(number);
            //Assert
            Assert.Equal(expectedResult, results);
        }

        [Theory]
        [InlineData("\"12,\\n", "Input string was not in a correct format.")]
        [InlineData("\"12,56,8\\n", "Input string was not in a correct format.")]
        public void AddShouldThrowFormatExceptionIfStringIsInvalid(string number , string expectedError)
        {
           
           var ex = Assert.Throws<FormatException>(()=>_stringCalculator.Add(number));

           //Assert
           Assert.Equal(expectedError, ex.Message);
        }

        [Theory]
        [InlineData("-1,-5,-6", "Negative numbers are not allowed: -1,-5,-6")]
        [InlineData("-1,-6", "Negative numbers are not allowed: -1,-6")]
        [InlineData("-1,-6,9,2,5,6,7", "Negative numbers are not allowed: -1,-6")]
        public void AddShouldThrowExceptionIfStringInputContainsNegativeNumbers(string number, string expectedResult)
        {
            //Act
            var ex = Assert.Throws<FormatException>(()=>_stringCalculator.Add(number));

            //Assert
            Assert.Equal(expectedResult, ex.Message);
        }

        [Theory]
        [InlineData("2\n3", 5)]
        [InlineData("2\n2", 4)]
        [InlineData("3\n5", 8)]
        public void AddShouldReturnSumOfValidSeparatedNewLineStringInput(string number, int expectedResult)
        {
            //Act
            int results = _stringCalculator.Add(number);
            //Assert
            Assert.Equal(expectedResult, results);
        }



        [Theory]
        [InlineData("//???\n90???12", 102)]
        [InlineData("//???\n1???4???9", 14)]
        [InlineData("//???\n1???4???9???1???1???1???2", 19)]
        public void AddShouldReturnSumOfCustomerDelimiterForValidStringInput(string number, int expected)
        {
            //Act
            int result = _stringCalculator.Add(number);


            Assert.Equal(expected,result);
        }
    }
}
