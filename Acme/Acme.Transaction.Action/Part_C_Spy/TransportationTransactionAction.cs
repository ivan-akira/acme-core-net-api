using Acme.API.Interface.Part_C_Spy;

namespace Acme.Transaction.Action.Part_C_Spy
{
    public class TransportationTransactionAction
    {
        public void MoveVehicle(long startPosition, long endPosition, IVehicleService vehicleService)
        {
            if (startPosition < endPosition)
            {
                vehicleService.MoveForward(endPosition - startPosition);
            }
            if (startPosition > endPosition)
            {
                vehicleService.MoveBackward(startPosition - endPosition);
            }
        }
    }
}
