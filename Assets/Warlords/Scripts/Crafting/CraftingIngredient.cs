using UnityEngine;
using Warlords.Inventory;

namespace Warlords.Crafting
{
    [CreateAssetMenu(menuName = "Recipes/CraftingIngredient", fileName = "CraftingIngredient", order = 0)]
    public class CraftingIngredient : ScriptableObject
    {
        public IngredientType Type;
        public IngredientColor Color;
        public string ID;
    }
}