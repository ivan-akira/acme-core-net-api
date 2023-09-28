using Acme.API.Interface.Part_A_Dummy;
using Acme.Transaction.Action;
using Xunit;

namespace Acme.UnitTest.Part_A_Dummy
{
    public class MoveRobotTransactionActionTest
    {
        private readonly MoveRobotTransactionAction moveRobotTransactionAction;

        public MoveRobotTransactionActionTest()
        {
            moveRobotTransactionAction = new MoveRobotTransactionAction();
        }

        [Fact]
        public void Move_PositiveStep_ReturnCorrectPosition()
        {
            // arrange
            var initialPosition = 10L;
            var step = 3L;
            var expectedPosition = 13L;

            var movementStrategy = new MovementStrategyDummy();

            moveRobotTransactionAction.SetInitialPosition(initialPosition);

            // act
            var result = moveRobotTransactionAction.Move(step, movementStrategy);

            // assert
            Assert.Equal(expectedPosition, result);
        }

        private class MovementStrategyDummy : IMovementStrategy // <- this is dummy
        {
            public void Move(long currentPosition, long nextPosition)
            {
            }
        }
    }
}
