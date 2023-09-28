using Acme.Entities.Part_D_Mock;
using System;

namespace Acme.Transaction.Action.Part_D_Mock
{
    public class KitchenTransactionAction : IKitchenTransactionAction
    {
        public MealEntity DoCookMeal()
        {
            return new MealEntity()
            {
                MealId = Guid.NewGuid(),
                MealName = "Pizza"
            };
        }
    }
}
