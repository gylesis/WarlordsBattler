using UnityEngine;

namespace Warlords.Crafting
{
    [CreateAssetMenu(menuName = "Recipes/RecipesContainer", fileName = "RecipesContainer", order = 0)]
    public class RecipesContainer : ScriptableObject
    {
        public Recipe[] Recipes;
    }
}