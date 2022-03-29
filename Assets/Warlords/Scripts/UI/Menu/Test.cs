#if UNITY_EDITOR
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using Warlords.Inventory;

namespace Warlords.UI.Menu
{
    public class Test : MonoBehaviour, IPreprocessBuildWithReport, IPostprocessBuildWithReport
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

        public int callbackOrder { get; }
        public void OnPostprocessBuild(BuildReport report)
        {
            Debug.Log("Ended build process" + report.summary.result);
        }

        public void OnPreprocessBuild(BuildReport report)
        {
            Debug.Log("Started to build process" + report.summary.result);
        }
    }
}
#endif