﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Warlords.Inventory;

namespace Warlords.Crafting
{
    [CreateAssetMenu(menuName = "Recipes/Recipe", fileName = "Recipe", order = 0)]
    public class Recipe : ScriptableObject
    {
        public string Output;
        
        public List<CraftingIngredient> Ingredients = new List<CraftingIngredient>(5) {null, null, null, null, null};

        public bool AreIngredientsFit(Ingredient[] ingredients)
        {
            var craftingIngredients = new List<CraftingIngredient>(Ingredients);  

            foreach (Ingredient ingredient in ingredients)
            {
                CraftingIngredient craftingIngredient = craftingIngredients.FirstOrDefault(x => x.Color == ingredient.Color && x.Type == ingredient.Type);

                if (craftingIngredient == null) return false;
                
                craftingIngredients.Remove(craftingIngredient);
            }

            return craftingIngredients.Count == 0;
        }
        
        private void OnValidate()
        {
            if (Ingredients.Count > 5)
            {
                for (var i = Ingredients.Count - 1; i >= 5; i--)
                {
                    Ingredients.RemoveAt(i);
                }
            }
        }
    }
}