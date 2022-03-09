using UnityEngine;
using Warlords.Player.Spells;
using Zenject;

namespace Warlords.Infrastructure.Installers
{
    public class SpellsInstaller : MonoInstaller
    {
        [SerializeField] private SpellDataContainer _spellDataContainer;
        [SerializeField] private MainSpellsViewContainer _mainSpellsViewContainer;  
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MainSpellsViewService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SpellsChangingDispatcher>().AsSingle().NonLazy();
            Container.Bind<MainSpellsViewContainer>().FromInstance(_mainSpellsViewContainer).AsSingle();
            Container.Bind<SpellDataContainer>().FromInstance(_spellDataContainer).AsSingle();
            Container.BindInterfacesAndSelfTo<SelectableSpellsButtonsHandler>().AsSingle().NonLazy();
        }
    }
}