using UnityEngine;
using Warlords.Inventory;

namespace Warlords.UI.Menu
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private Sprite _sprite;

        [ContextMenu(nameof(TestSomething))]
        private void TestSomething()
        {
            Item item = new Ingredient {Color = IngredientColor.Gray, Name = "Gaaaa", Type = IngredientType.Fragment};

            var json = JsonUtility.ToJson(item);

            var itemFromJson = JsonUtility.FromJson<Item>(json);
            var ingredientFromJson = (Ingredient) itemFromJson;

            Debug.Log(itemFromJson.Name);

            Debug.Log(
                $"Name {ingredientFromJson.Name}, Color {ingredientFromJson.Color}, Type {ingredientFromJson.Type}");
        }

    }
}