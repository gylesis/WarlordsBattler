using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Warlords.Infrastracture.Installers
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        
        [Inject]
        private void Init(SceneLoader sceneLoader)
        {
            _button.onClick.AddListener((() => sceneLoader.LoadScene("BattleLevel")));
        }
        
    }
}