using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Warlords.Infrastracture.Installers
{
    public class MainMenuInstaller : MonoInstaller, IInitializable
    {
        [SerializeField] private FractionsContainer _fractionsContainer;
        [SerializeField] private FractionsView _fractionsView;
        [SerializeField] private FractionView _fractionViewPrefab;  
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MainMenuInstaller>().FromInstance(this).AsSingle();
            
            Container.Bind<FractionsContainer>().FromInstance(_fractionsContainer).AsSingle();

            Container.Bind<FractionsViewFactory>().AsSingle();

            Container.Bind<FractionView>().FromInstance(_fractionViewPrefab).AsSingle();

            Container.Bind<PlayerInfoSetter>().AsSingle();
            
            Container.Bind<FilteredFractions>().AsSingle();

            Container.Bind<IGeneratable>().To<FractionsView>().FromInstance(_fractionsView);
        }

        public async void Initialize()
        {
            await Load();
        }
        
        private async Task Load()
        {
           // Debug.Log("Load");
            
            var generatables = Container.ResolveAll<IGeneratable>();

            foreach (IGeneratable generatable in generatables)
            {
                await generatable.Generate();
            }

           // Debug.Log("Load Completed");
        }
        
    }
}