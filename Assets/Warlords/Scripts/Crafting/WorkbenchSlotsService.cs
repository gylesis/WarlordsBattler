using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using Warlords.Inventory;

namespace Warlords.Crafting
{
    public class WorkbenchSlotsService
    {
        private readonly Dictionary<WorkbenchSlot, Ingredient> _workbenchSlots =
            new Dictionary<WorkbenchSlot, Ingredient>();

        private readonly ItemsRecipesDictionary _itemsRecipes;

        public Subject<Item> WorkbenchRecipeAvailable { get; } = new Subject<Item>();

        public WorkbenchSlotsService(ItemsRecipesDictionary itemsRecipes)
        {
            _itemsRecipes = itemsRecipes;
        }

        public void Put(WorkbenchSlot workbenchSlot, Ingredient ingredient)
        {
            _workbenchSlots[workbenchSlot] = ingredient;

            CheckRecipeAvailability();
        }

        private void CheckRecipeAvailability()
        {
            if (TryGetItemFromRecipes(out var item))
            {
                WorkbenchRecipeAvailable.OnNext(item);
            }
            else
            {
                WorkbenchRecipeAvailable.OnNext(null);
            }
        }

        private bool TryGetItemFromRecipes(out Item item)
        {
            var ingredients = _workbenchSlots.Values.Where(x => x != null).ToArray();

            var tryGetRecipeByIngredients = _itemsRecipes.TryGetRecipeByIngredients(ingredients, out var recipe);

            if (tryGetRecipeByIngredients)
            {
                if (recipe is IngredientRecipe ingredientItemRecipe)
                {
                    item = ingredientItemRecipe.Output;

                  //  Debug.Log($"Ingredient {item.Name}");
                    return true;
                }

                item = recipe.Output;
                //Debug.Log($"Not Ingredient {item.Name}");
                return true;
            }

            item = null;
            return false;
        }

        public bool TryCraft(out Item item)
        {
            var successCraft = TryGetItemFromRecipes(out item);

            if (successCraft)
            {
                ConsumeIngredients();
            }

            return successCraft;
        }

        private void ConsumeIngredients()
        {
            var workbenchSlots = _workbenchSlots.Keys.ToList();
            
            _workbenchSlots.Clear();

            foreach (WorkbenchSlot workbenchSlot in workbenchSlots)
            {
                _workbenchSlots.Add(workbenchSlot, null);
                workbenchSlot.SetItem(null);
            }

            CheckRecipeAvailability();
        }

        public void RemoveItemFromSlot(WorkbenchSlot workbenchSlot, bool withRecipeChecking = false)
        {
            _workbenchSlots[workbenchSlot] = null;
            workbenchSlot.SetItem(null);

            if (withRecipeChecking)
                CheckRecipeAvailability();
        }
    }
}