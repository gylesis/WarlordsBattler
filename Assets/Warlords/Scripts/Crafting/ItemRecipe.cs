using UnityEngine;
using Warlords.Inventory;

namespace Warlords.Crafting
{
    [CreateAssetMenu(menuName = "Recipes/ItemRecipe", fileName = "ItemRecipe", order = 0)]
    public class ItemRecipe : Recipe
    {
        [SerializeField] private Item _item;

        public override Item Output => _item;
    }
}