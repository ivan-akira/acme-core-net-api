using Acme.Entities.Part_D_Mock;

namespace Acme.Transaction.Action.Part_D_Mock
{
    public interface IKitchenTransactionAction
    {
        MealEntity DoCookMeal();
    }
}
