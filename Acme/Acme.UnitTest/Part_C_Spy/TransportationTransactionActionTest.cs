using Acme.API.Interface.Part_C_Spy;
using Acme.Transaction.Action.Part_C_Spy;
using Xunit;

namespace Acme.UnitTest.Part_C_Spy
{
    public class TransportationTransactionActionTest
    {
        private readonly TransportationTransactionAction transportationTransactionAction;

        public TransportationTransactionActionTest()
        {
            transportationTransactionAction = new TransportationTransactionAction();
        }

        [Fact]
        public void MoveVehicle_EndGreaterThanStartPosition_VehicleMoveForward()
        {
            // arrange
            var startPosition = 10L;
            var endPosition = 13L;
            var expectedStep = 3L;

            var vehicleService = new VehicleServiceSpy();

            // act
            transportationTransactionAction.MoveVehicle(startPosition, endPosition, vehicleService);

            // assert
            Assert.Equal(expectedStep, vehicleService.StepMoveForward);
        }

        private class VehicleServiceSpy : IVehicleService // <- this is spy
        {
            public long StepMoveForward { get; set; }

            public void MoveForward(long step)
            {
                StepMoveForward = step;
            }

            public void MoveBackward(long step)
            {
            }
        }
    }
}
