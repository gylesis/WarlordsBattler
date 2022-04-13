using Cysharp.Threading.Tasks;

namespace Warlords.Infrastructure.States
{
    public interface IState
    {
        UniTask Enter();
        UniTask Exit();
    }
}