using UnityEngine;

namespace Warlords.Player.Attributes
{
    [CreateAssetMenu(menuName = "StaticData/PlayerAttributeSO", fileName = "PlayerAttributeSO", order = 0)]
    public class PlayerAttributeSO : ScriptableObject
    {
        public PlayerAttribute Value;
    }
}