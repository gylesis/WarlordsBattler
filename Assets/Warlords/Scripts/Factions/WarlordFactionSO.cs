using UnityEditor;
using UnityEngine;

namespace Warlords.Factions
{
    [CreateAssetMenu(menuName = "StaticData/WarlordFactionSO", fileName = "WarlordFactionSO", order = 0)]
    public class WarlordFactionSO : ScriptableObject
    {
        public Faction Value;
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            EditorUtility.SetDirty(this);
            name = Value.Name;
        }
#endif
        
    }
}