using Cysharp.Threading.Tasks;
using UnityEngine;
using Warlords.Player.Attributes;
using Warlords.Utils;
using Zenject;

namespace Warlords.Infrastructure.Factory
{
    public class PlayerAttributeViewFactory
    {
        private readonly Transform _spawnParent;
        private readonly DiContainer _container;

        public PlayerAttributeViewFactory(PlayerAttributesViewFactoryContext context, DiContainer container)
        {
            _container = container;
            _spawnParent = context.SpawnParent;
        }
        
        public async UniTask<PlayerAttributeView> CreatePlayerAttributeView()
        {
            var playerAttributeView = await LoadAndSpawn<PlayerAttributeView>(AssetsPath.PlayerAttribute);

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
    public struct PlayerAttributesViewFactoryContext
    {
        public Transform SpawnParent;
    }
}