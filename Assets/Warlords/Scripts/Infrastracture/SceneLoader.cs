using System.Collections;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using Warlords.Utils;
using Zenject;

namespace Warlords.Infrastracture
{
    public class SceneLoader : MonoBehaviour
    {
        private CurtainService _curtainService;
        private AsyncLoadingsDispatcher _asyncLoadingsDispatcher;

        [Inject]
        private void Init(AsyncLoadingsDispatcher asyncLoadingsDispatcher, CurtainService curtainService)
        {
            _asyncLoadingsDispatcher = asyncLoadingsDispatcher;
            _curtainService = curtainService;
            
            DontDestroyOnLoad(gameObject);
        }

        public void LoadScene(string sceneName)
        {
           StartCoroutine(LoadSceneAsyncCorutine(sceneName));
        }

        private IEnumerator LoadSceneAsyncCorutine(string sceneName)
        {
            var sceneLoadProgress = new FloatReactiveProperty(0);
            _curtainService.ShowWithProgress(sceneLoadProgress);

            var asyncSceneLoad = SceneManager.LoadSceneAsync(sceneName);
            asyncSceneLoad.allowSceneActivation = false;

            while (asyncSceneLoad.isDone == false)
            {
                sceneLoadProgress.Value = asyncSceneLoad.progress;
                
                if (asyncSceneLoad.progress >= 0.9f)
                {
                    asyncSceneLoad.allowSceneActivation = true;

                    yield return null;
                    yield return null;
                    
                    yield return _asyncLoadingsDispatcher.LoadAsync();
                }
            }
            
            _curtainService.Hide();
        }

    }
}