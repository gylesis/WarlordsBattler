using UnityEngine;
using Warlords.Inventory;

namespace Warlords.Crafting
{
    public class ItemsRecipesDictionary
    {
        private readonly RecipesContainer _recipesContainer;

        public ItemsRecipesDictionary(RecipesContainer recipesContainer)
        {
            _recipesContainer = recipesContainer;
        }
        
        public bool TryGetRecipeByIngredients(Ingredient[] ingredients, out ItemRecipe itemRecipe)
        {
            foreach (ItemRecipe recip in _recipesContainer.Recipes)
            {
                var check = recip.AreIngredientsFit(ingredients);

                if (check)
                {
                    itemRecipe = recip;
                    return true;
                }
            }

            itemRecipe = null;
            return false;

        }
        
    }
}