using Acme.API.Interface.Part_A_Dummy;

namespace Acme.Transaction.Action
{
    public class MoveRobotTransactionAction
    {
        private long position;

        public void SetInitialPosition(long position)
        {
            this.position = position;
        }

        public long Move(long step, IMovementStrategy movementStrategy)
        {
            var currentPosition = position;
            var nextPosition = currentPosition + step;

            movementStrategy.Move(currentPosition, nextPosition);

            return nextPosition;
        }
    }
}
