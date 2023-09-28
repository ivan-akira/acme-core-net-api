using Acme.Constant;
using Acme.Transaction.Action.Part_F_ProvidingData;
using System;
using Xunit;

namespace Acme.UnitTest.Part_F_ProvidingData
{
    public class SimpleCalculatorTransactionActionTest
    {
        private readonly SimpleCalculatorTransactionAction simpleCalculatorTransactionAction;

        public SimpleCalculatorTransactionActionTest()
        {
            simpleCalculatorTransactionAction = new SimpleCalculatorTransactionAction();
        }

        [Theory]
        [InlineData(-1L, AppConstants.Operator.ADD, -1L, -2L)]
        [InlineData(1L, AppConstants.Operator.ADD, 1L, 2L)]
        [InlineData(-1L, AppConstants.Operator.SUBSTRACT, -1L, 0L)]
        [InlineData(1L, AppConstants.Operator.SUBSTRACT, 1L, 0L)]
        public void Calculate_BothNumberWithInlineData_ReturnExpectedNumberResult(
            long number1,
            AppConstants.Operator op,
            long number2,
            long expectedResult)
        {
            // arrange

            // act
            var result = simpleCalculatorTransactionAction.Calculate(number1, op, number2);

            // assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [MemberData(
            nameof(SimpleCalculatorTransactionActionTestScenarios.GetBothNumber),
            MemberType = typeof(SimpleCalculatorTransactionActionTestScenarios))]
        public void Calculate_BothNumberWithMemberData_ReturnExpectedNumberResult(
            long number1,
            AppConstants.Operator op,
            long number2,
            long expectedResult)
        {
            // arrange

            // act
            var result = simpleCalculatorTransactionAction.Calculate(number1, op, number2);

            // assert
            Assert.Equal(expectedResult, result);
        }
    }
}
