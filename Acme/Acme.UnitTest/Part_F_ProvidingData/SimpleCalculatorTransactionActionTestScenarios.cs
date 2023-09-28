using Acme.Constant;
using System.Collections.Generic;

namespace Acme.UnitTest.Part_F_ProvidingData
{
    public static class SimpleCalculatorTransactionActionTestScenarios
    {
        public static IEnumerable<object[]> GetBothNumber()
        {
            yield return new object[] { -1L, AppConstants.Operator.ADD, -1L, -2L };
            yield return new object[] { 1L, AppConstants.Operator.ADD, 1L, 2L };
            yield return new object[] { -1L, AppConstants.Operator.SUBSTRACT, -1L, 0L };
            yield return new object[] { 1L, AppConstants.Operator.SUBSTRACT, 1L, 0L };
        }
    }
}
