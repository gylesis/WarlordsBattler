using UnityEngine;
using Warlords.Inventory;

namespace Warlords.Crafting
{
    [CreateAssetMenu(menuName = "Recipes/IngredientRecipe", fileName = "IngredientRecipe", order = 0)]
    public class IngredientItemRecipe : ItemRecipe
    {
        public Ingredient Output;
    }
}