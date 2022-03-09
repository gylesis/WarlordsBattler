using TMPro;
using UniRx;
using UnityEngine;
using Warlords.Utils;

namespace Warlords.UI.Menu
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private DefaultReactiveButton _reactiveButton;
        
        private void Awake()
        {

            _reactiveButton.Clicked.TakeUntilDestroy(this).Subscribe((unit =>
            {
                var texts = FindObjectsOfType<TMP_Text>(true);
                
                foreach (TMP_Text tmpText in texts)
                {
                    tmpText.isTextObjectScaleStatic = true;
                }
                
                Debug.Log($"All textes on scene: {texts.Length}");
            }));
        }
       
    }
}