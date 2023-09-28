using Acme.API.Interface.Part_B_Stub;
using Acme.Transaction.Action.Part_B_Stub;
using Xunit;

namespace Acme.UnitTest.Part_B_Stub
{
    public class CalculatorTransactionActionTest_Alternative
    {
        private readonly CalculatorTransactionAction calculatorTransactionAction;

        public CalculatorTransactionActionTest_Alternative()
        {
            calculatorTransactionAction = new CalculatorTransactionAction();
        }

        [Fact]
        public void Add_PositiveComplexNumber_ReturnPositiveComplexNumber()
        {
            // arrange
            var number1 = new ComplexNumberStub()
            {
                Number = 1L
            };
            var number2 = new ComplexNumberStub()
            {
                Number = 3L
            };
            var expectedResult = 4L;

            // act
            var result = calculatorTransactionAction.Add(number1, number2);

            // assert
            Assert.Equal(expectedResult, result.Number);
        }

        private class ComplexNumberStub : IComplexNumber // <- this is stub
        {
            public long Number { get; set; }
        }
    }
}
