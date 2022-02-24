using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warlords.Player.Attributes;
using Warlords.UI.PopUp;
using Object = UnityEngine.Object;

namespace Warlords.Infrastracture.Factory
{
    public class UIFactory
    {
        public async UniTask<PlayerNamePopUp> CreatePlayerNamePopUp(string path, Transform parent)
        {
            var playerNamePopUp = await LoadAndSpawn<PlayerNamePopUp>(path, parent);
            return playerNamePopUp;
        }

        public async UniTask<PlayerAttributeView> CreatePlayerAttributeView(string path, Transform parent)
        {
            var playerAttributeView = await LoadAndSpawn<PlayerAttributeView>(path, parent);

            return playerAttributeView;
        }

        private async UniTask<T> LoadAndSpawn<T>(string path, Transform parent) where T : MonoBehaviour
        {
            var loadedPopUp = Resources.Load<T>(path);

            UniTask delay = UniTask.Delay(50);

            await delay;

            T namePopUp = Object.Instantiate(loadedPopUp, parent);

            return namePopUp;
        }
    }
}