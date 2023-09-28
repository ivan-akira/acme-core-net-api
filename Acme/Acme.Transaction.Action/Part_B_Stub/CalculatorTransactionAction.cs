using Acme.API.Interface.Part_B_Stub;

namespace Acme.Transaction.Action.Part_B_Stub
{
    public class CalculatorTransactionAction
    {
        public IComplexNumber Add(IComplexNumber number1, IComplexNumber number2)
        {
            return new ComplexNumber()
            {
                Number = number1.Number + number2.Number
            };
        }

        private class ComplexNumber : IComplexNumber
        {
            public long Number { get; set; }
        }
    }
}
