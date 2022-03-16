using UnityEditor;
using UnityEngine;

namespace Warlords.Crafting
{
    [CreateAssetMenu(menuName = "Recipes/CraftingIngredientsContainer", fileName = "CraftingIngredientsContainer", order = 0)]
    public class CraftingIngredientsContainer : ScriptableObject
    {
        public CraftingIngredient[] Ingredients;

        [ContextMenu(nameof(GenerateIds))]
        private void GenerateIds()
        {
            foreach (CraftingIngredient craftingIngredient in Ingredients)
            {
                craftingIngredient.ID = GUID.Generate().ToString();
            }
        }
        
        
    }
}