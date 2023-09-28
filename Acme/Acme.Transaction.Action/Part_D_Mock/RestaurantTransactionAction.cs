using Acme.Entities.Part_D_Mock;
using System.Collections.Generic;

namespace Acme.Transaction.Action.Part_D_Mock
{
    public class RestaurantTransactionAction
    {
        private readonly IKitchenTransactionAction kitchenTransactionAction;

        public RestaurantTransactionAction(IKitchenTransactionAction kitchenTransactionAction)
        {
            this.kitchenTransactionAction = kitchenTransactionAction;
        }

        public List<MealEntity> OrderTakeoutMeals(int quantity)
        {
            var meals = new List<MealEntity>();

            for (int i = 0; i < quantity; i++)
            {
                var meal = kitchenTransactionAction.DoCookMeal();

                if (meal != null)
                {
                    meals.Add(meal);
                }
            }

            return meals;
        }
    }
}
