using Acme.Constant;

namespace Acme.Transaction.Action.Part_F_ProvidingData
{
    public class SimpleCalculatorTransactionAction
    {
        public long? Calculate(long number1, AppConstants.Operator op, long number2)
        {
            if (op == AppConstants.Operator.ADD) {
                return number1 + number2;
            }
            if (op == AppConstants.Operator.SUBSTRACT) {
                return number1 - number2;
            }
            return null;
        }
    }
}
