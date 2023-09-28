using Acme.Entities.Part_D_Mock;
using Acme.Transaction.Action.Part_D_Mock;
using Moq;
using Xunit;

namespace Acme.UnitTest.Part_D_Mock
{
    public class RestaurantTransactionActionTest
    {
        private readonly RestaurantTransactionAction restaurantTransactionAction;
        private readonly Mock<IKitchenTransactionAction> kitchenTransactionAction; // <- this is mock

        public RestaurantTransactionActionTest()
        {
            kitchenTransactionAction = new Mock<IKitchenTransactionAction>();
            restaurantTransactionAction = new RestaurantTransactionAction(kitchenTransactionAction.Object);
        }

        [Fact]
        public void OrderTakeoutMeals_OrderOneMeal_ReceiveOneMeal()
        {
            // arrange
            var quantity = 1;
            var expectedQuantity = 1;

            kitchenTransactionAction.Setup(k => k.DoCookMeal()).Returns(new MealEntity());

            // act
            var result = restaurantTransactionAction.OrderTakeoutMeals(quantity);

            // assert
            Assert.Equal(expectedQuantity, result.Count);
        }
    }
}
