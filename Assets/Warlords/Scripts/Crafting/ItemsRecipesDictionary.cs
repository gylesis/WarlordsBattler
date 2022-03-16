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
        
        public bool TryGetRecipeByIngredients(Ingredient[] ingredients, out Recipe recipe)
        {
            foreach (Recipe recip in _recipesContainer.Recipes)
            {
                var check = recip.AreIngredientsFit(ingredients);

                if (check)
                {
                    recipe = recip;
                    return true;
                }
            }

            recipe = null;
            return false;

        }
        
    }
}