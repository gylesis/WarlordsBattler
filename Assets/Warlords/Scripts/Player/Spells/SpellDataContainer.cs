using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Warlords.Player.Spells
{
    [CreateAssetMenu(menuName = "StaticData/SpellDataContainer", fileName = "SpellDataContainer", order = 0)]
    public class SpellDataContainer : ScriptableObject
    {
       public List<SpellInfoContext> SpellInfos;

       private void OnValidate()
       {
           EditorUtility.SetDirty(this);
           
           foreach (SpellInfoContext spellInfoContext in SpellInfos)
           {
               spellInfoContext.Name = spellInfoContext.Infos[0].Type.ToString();

               for (var i = 0; i < spellInfoContext.Infos.Length; i++)
               {
                   SpellInfo spellInfo = spellInfoContext.Infos[i];
                   spellInfo.Name = $"{spellInfo.Type} {i + 1}";
               }
           }
       }
    }

    [Serializable]
    public class SpellInfoContext
    {
        [HideInInspector] public string Name;        
        public SpellInfo[] Infos;
    }
    
}       