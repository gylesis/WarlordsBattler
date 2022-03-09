using Cysharp.Threading.Tasks;
using UnityEngine;
using Warlords.UI.PopUp;
using Warlords.Utils;
using Zenject;

namespace Warlords.Infrastructure.Factory
{
    public class PopUpsFactory
    {
        private readonly Transform _spawnParent;
        private readonly DiContainer _container;

        public PopUpsFactory(PopUpFactoryContext factoryContext, DiContainer container)
        {
            _container = container;
            _spawnParent = factoryContext.SpawnParent;
        }
        
        public async UniTask<PlayerNamePopUp> CreatePlayerNamePopUp()
        {
            var playerNamePopUp = await LoadAndSpawn<PlayerNamePopUp>(AssetsPath.ChangePlayerNamePopUp);
            return playerNamePopUp;
        }

        public async UniTask<RedirectionPopUp> CreateRedirectionPopUp()
        {
            var playerAttributeView = await LoadAndSpawn<RedirectionPopUp>(AssetsPath.RedirectionPopUp);

            return playerAttributeView;
        }

        private async UniTask<T> LoadAndSpawn<T>(string path) where T : MonoBehaviour
        {
            var loadedPopUp = Resources.Load<T>(path);

            UniTask delay = UniTask.Delay(50);

            await delay;

            T instance = _container.InstantiatePrefabForComponent<T>(loadedPopUp, _spawnParent);

            return instance;
        }
    }


    public struct PopUpFactoryContext
    {
        public Transform SpawnParent;
    }
}