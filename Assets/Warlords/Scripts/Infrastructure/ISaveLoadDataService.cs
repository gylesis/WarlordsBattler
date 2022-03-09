using System;
using System.Threading.Tasks;

namespace Warlords.Infrastructure
{
    public interface ISaveLoadDataService
    {
        SaveData Data { get; }
        Task<SaveData> Load();
        void Overwrite(Action<SaveData> onOverwrite);
    }
}