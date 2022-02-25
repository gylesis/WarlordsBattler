using UnityEngine;
using Warlords.Player;
using Warlords.Player.Attributes;
using Warlords.UI.PopUp;
using Zenject;

namespace Warlords.Infrastracture.Installers
{
    public class PlayerInfoInstaller : MonoInstaller
    {        
        [SerializeField] private SaveCancelPlayerInfoService _saveCancelPlayerInfoService;

        public override void InstallBindings()
        {
            Container.Bind<PlayerInfoChangedDispatcher>().AsSingle().NonLazy();
            Container.Bind<PlayerInfoChangeRegister>().AsSingle().NonLazy();
            Container.Bind<PlayerNameSetter>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerNameFilter>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerInfoSetter>().AsSingle().NonLazy();
            Container.Bind<PlayerInfoPreSaver>().AsSingle().NonLazy();
            Container.Bind<SaveCancelPlayerInfoService>().FromInstance(_saveCancelPlayerInfoService).AsSingle();
        }
    }
}