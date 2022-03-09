using Cysharp.Threading.Tasks;

namespace Warlords.Infrastructure
{
    public interface IAsyncLoad
    {
        UniTask AsyncLoad();
    }
}