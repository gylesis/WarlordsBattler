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
                int temp = 0;
                
                foreach (Ingredient ingredient in _workbenchSlots.Values)
                {
                    var isNotEmpty = ingredient != null;

                    if (isNotEmpty) temp++;
                }

                Debug.Log(temp);
                
                if (temp == 5) return true;
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

        public void TryCraft()
        {
            var ingredients = _workbenchSlots.Values.ToArray();

            var tryGetRecipeByIngredients = _itemsRecipes.TryGetRecipeByIngredients(ingredients, out var recipe);

            if (tryGetRecipeByIngredients)
            {
                
            }
            
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