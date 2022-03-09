namespace Warlords.Infrastructure.States
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}