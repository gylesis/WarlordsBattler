using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace Warlords.Infrastracture
{
    public interface IAsyncLoad
    {
        UniTask AsyncLoad();
    }
}