using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Warlords.Inventory;

namespace Warlords.Crafting
{
    public class WorkbenchSlotsService
    {
        private readonly Dictionary<WorkbenchSlot, Ingredient> _workbenchSlots = new Dictionary<WorkbenchSlot, Ingredient>();
        private ItemsRecipesDictionary _itemsRecipes;

        public bool IsWorkbenchFull
        {
            get
            {
                int slotsBusyCount = 0;
                
                foreach (Ingredient ingredient in _workbenchSlots.Values)
                {
                    var isNotEmpty = ingredient != null;

                    if (isNotEmpty) slotsBusyCount++;
                }

                if (slotsBusyCount == 5) return true;
                return false;
            }
        }

        public WorkbenchSlotsService(ItemsRecipesDictionary itemsRecipes)
        {
            _itemsRecipes = itemsRecipes;
        }
        
        public void Put(WorkbenchSlot workbenchSlot, Ingredient ingredient)
        {
            _workbenchSlots[workbenchSlot] = ingredient;
        }

        public bool TryCraft(out Item item)
        {
            item = null;
            var ingredients = _workbenchSlots.Values.ToArray();

            var tryGetRecipeByIngredients = _itemsRecipes.TryGetRecipeByIngredients(ingredients, out var recipe);

            if (tryGetRecipeByIngredients)
            {
                if (recipe is IngredientItemRecipe ingredientItemRecipe)
                {
                    item = ingredientItemRecipe.Output;
                    return true;
                }                
            }

            return false;
        }
        
        public void ResetWorkbenchSlots()
        {
            foreach (var keyValuePair in _workbenchSlots)
            {
                _workbenchSlots[keyValuePair.Key] = null;
            }
        }
        
    }
}