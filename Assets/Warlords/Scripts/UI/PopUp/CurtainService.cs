using UnityEngine;

namespace Warlords.UI.PopUp
{
    public class CurtainService : MonoBehaviour
    {
        [SerializeField] private GameObject _curtainObj;
        
        public void Show()
        { 
            _curtainObj.SetActive(true);
        }

        public void Hide()
        {
            _curtainObj.SetActive(false);
        }
        
    }
}