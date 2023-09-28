namespace Acme.API.Interface.Part_A_Dummy
{
    public interface IMovementStrategy
    {
        void Move(long currentPosition, long nextPosition);
    }
}
