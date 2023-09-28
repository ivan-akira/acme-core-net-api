using Acme.API.Interface.Part_C_Spy;
using Acme.Transaction.Action.Part_C_Spy;
using Moq;
using Xunit;

namespace Acme.UnitTest.Part_C_Spy
{
    public class TransportationTransactionActionTest_Alternative
    {
        private readonly TransportationTransactionAction transportationTransactionAction;
        private readonly Mock<IVehicleService> vehicleService; // <- this is spy

        public TransportationTransactionActionTest_Alternative()
        {
            transportationTransactionAction = new TransportationTransactionAction();
            vehicleService = new Mock<IVehicleService>();
        }

        [Fact]
        public void MoveVehicle_EndGreaterThanStartPosition_VehicleMoveForward()
        {
            // arrange
            var startPosition = 10L;
            var endPosition = 13L;
            var expectedStep = 3L;

            // act
            transportationTransactionAction.MoveVehicle(startPosition, endPosition, vehicleService.Object);

            // assert
            vehicleService.Verify(v => v.MoveForward(expectedStep), Times.Exactly(1));
        }
    }
}
