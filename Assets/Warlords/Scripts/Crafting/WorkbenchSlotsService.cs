using System.Collections.Generic;
using System.Linq;
using UniRx;
using Warlords.Inventory;

namespace Warlords.Crafting
{
    public class WorkbenchSlotsService
    {
        private readonly Dictionary<WorkbenchSlot, Ingredient> _workbenchSlots = new Dictionary<WorkbenchSlot, Ingredient>();
        private readonly ItemsRecipesDictionary _itemsRecipes;

        public Subject<Item> WorkbenchRecipeAvailable { get; } = new Subject<Item>();
        
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
            var ingredients = _workbenchSlots.Values.ToArray();

            var tryGetRecipeByIngredients = _itemsRecipes.TryGetRecipeByIngredients(ingredients, out var recipe);

            if (tryGetRecipeByIngredients)
            {
                if (recipe is IngredientItemRecipe ingredientItemRecipe)
                {
                    item = ingredientItemRecipe.Output;
                    
                    WorkbenchRecipeAvailable.OnNext(item);
                    return true;
                } 
                
            }

            item = null;
            return false;
        }

        public void RemoveItemFromSlot(WorkbenchSlot workbenchSlot)
        {
            _workbenchSlots[workbenchSlot] = null;
            workbenchSlot.SetItem(null);
        }
        
        /*public void ResetWorkbenchSlots()
        {
            foreach (var keyValuePair in _workbenchSlots)
            {
                _workbenchSlots[keyValuePair.Key] = null;
                keyValuePair.Key.SetItem(null);
            }
        }*/
        
    }
}