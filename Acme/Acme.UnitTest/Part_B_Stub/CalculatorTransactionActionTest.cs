using Acme.API.Interface.Part_B_Stub;
using Acme.Transaction.Action.Part_B_Stub;
using Xunit;

namespace Acme.UnitTest.Part_B_Stub
{
    public class CalculatorTransactionActionTest
    {
        private readonly CalculatorTransactionAction calculatorTransactionAction;

        public CalculatorTransactionActionTest()
        {
            calculatorTransactionAction = new CalculatorTransactionAction();
        }

        [Fact]
        public void Add_PositiveComplexNumber_ReturnPositiveComplexNumber()
        {
            // arrange
            var number1 = new OneComplexNumberStub();
            var number2 = new ThreeComplexNumberStub();
            var expectedResult = 4L;

            // act
            var result = calculatorTransactionAction.Add(number1, number2);

            // assert
            Assert.Equal(expectedResult, result.Number);
        }

        private class OneComplexNumberStub : IComplexNumber // <- this is stub
        {
            public long Number => 1L;
        }

        private class ThreeComplexNumberStub : IComplexNumber // <- this is stub
        {
            public long Number => 3L;
        }
    }
}
