using System.Threading.Tasks;
using UnityEngine;
using Warlords.Player.Attributes;
using Warlords.UI.PopUp;
using Object = UnityEngine.Object;

namespace Warlords.Infrastracture.Factory
{
    public class UIFactory
    {
        public async Task<PlayerNamePopUp> CreatePopUp(string path, Transform parent)
        {
            var async = LoadAndSpawn<PlayerNamePopUp>(path, parent);
            await async;
            return async.Result;
        }

        public async Task<PlayerAttributeView> CreatePlayerAttributeView(string path, Transform parent)
        {
            var async = LoadAndSpawn<PlayerAttributeView>(path, parent);
            await async;
            return async.Result;
        }

        private async Task<T> LoadAndSpawn<T>(string path, Transform parent) where T : MonoBehaviour
        {
            var loadedPopUp = Resources.Load<T>(path);

            Task delay = Task.Delay(50);

            await delay;

            T namePopUp = Object.Instantiate(loadedPopUp, parent);

            return namePopUp;
        }
    }
}