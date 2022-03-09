using UnityEngine;
using Warlords.Utils;

namespace Warlords.UI.Units
{
    public class SplashScreen : MonoBehaviour
    {
        [SerializeField] private RectTransform _transform;

        public void SetPos(Vector2 pos)
        {
           _transform.SetPos(pos);
        }
    }
}