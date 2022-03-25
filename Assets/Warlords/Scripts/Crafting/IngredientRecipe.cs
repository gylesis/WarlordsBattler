using UnityEngine;
using Warlords.Inventory;

namespace Warlords.Crafting
{
    [CreateAssetMenu(menuName = "Recipes/IngredientRecipe", fileName = "IngredientRecipe", order = 0)]
    public class IngredientRecipe : Recipe
    {
        [SerializeField] private Ingredient _ingredient;

        public override Item Output => _ingredient;
    }
}