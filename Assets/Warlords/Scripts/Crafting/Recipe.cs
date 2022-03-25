using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Warlords.Inventory;

namespace Warlords.Crafting
{
    public abstract class Recipe : ScriptableObject
    {
        public List<CraftingIngredient> Ingredients = new List<CraftingIngredient>(5) {null, null, null, null, null};

        public abstract Item Output { get; }
        
        public bool AreIngredientsFit(Ingredient[] ingredients)
        {
            var craftingIngredients = new List<CraftingIngredient>(Ingredients);

            foreach (Ingredient ingredient in ingredients)
            {
                Debug.Log($"target ingredient {ingredient.Color}, {ingredient.Type}");
                
                CraftingIngredient craftingIngredient =
                    craftingIngredients.FirstOrDefault(x =>
                    {
                        Debug.Log($"search ingredient {x.Color}, {x.Type}");
                        return x.Color == ingredient.Color && x.Type == ingredient.Type;
                    });

                if (craftingIngredient == null) return false;

                craftingIngredients.Remove(craftingIngredient);
            }

            return craftingIngredients.Count == 0;
        }

#if UNITY_EDITOR

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

#endif
    }
}