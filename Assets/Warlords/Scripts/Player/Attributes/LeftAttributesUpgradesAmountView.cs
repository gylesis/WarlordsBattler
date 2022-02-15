using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Warlords.Player.Attributes
{
    public class LeftAttributesUpgradesAmountView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _mount;
        
        public void UpdateView(int amount)
        {
            _mount.text = amount.ToString();
        }

        public void NotEnoughColor()
        {
            _mount.DOColor(Color.red, 0.3f).OnComplete((() => _mount.DOColor(Color.white,0.3f)));
        }
        
    }
}