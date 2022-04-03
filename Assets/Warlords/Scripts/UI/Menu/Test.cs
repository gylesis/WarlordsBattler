using UniRx;
using UnityEngine;
using Warlords.Inventory;
using Warlords.Utils;
using Zenject;

namespace Warlords.UI.Menu
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private DefaultReactiveButton _defaultReactiveButton;
        
        private SceneLoader _sceneLoader;

        [Inject]
        private void Init(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _defaultReactiveButton.Clicked.Take(1).Subscribe((unit => _sceneLoader.LoadScene(Constants.SceneNames.MainMenu)));
        }

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
