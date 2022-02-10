using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using Warlords.UI.PopUp;
using Warlords.Utils;
using Zenject;

namespace Warlords.Infrastracture.Installers
{
    public class SceneLoader : MonoBehaviour
    {
        private IAsyncLoad[] _asyncLoads;
        private CurtainService _curtainService;

        [Inject]
        private void Init(AsyncLoadingsContext asyncLoadingsContext, CurtainService curtainService)
        {
            _curtainService = curtainService;
            _asyncLoads = asyncLoadingsContext.AsyncLoads;
            
            DontDestroyOnLoad(gameObject);
        }

        private async void Start()
        {
            _curtainService.Show();
            
            foreach (IAsyncLoad asyncLoad in _asyncLoads)
            {
                await asyncLoad.AsyncLoad();
            }

            _curtainService.Hide();
        }

        public async void LoadScene(string sceneName)
        {
            var asyncSceneLoad = SceneManager
                .LoadSceneAsync(sceneName)
                .AsAsyncOperationObservable();
            
            _curtainService.ShowWithProgress(asyncSceneLoad);
            
            await asyncSceneLoad;
            
            _curtainService.Hide();
        }
        
    }
}