using Cysharp.Threading.Tasks;
using Warlords.Infrastructure;

namespace Warlords.Player
{
    public interface ISaveDataInitializer
    {
        UniTask<SaveData> Initialize();
    }
}   