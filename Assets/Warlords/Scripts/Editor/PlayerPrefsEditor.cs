using UnityEditor;
using UnityEngine;

namespace Warlords.Scripts.Editor
{
    public class PlayerPrefsEditor : EditorWindow
    {
        [MenuItem("Edit/PlayerPrefs Reset")]
        private static void ShowWindow()
        {
            /*var window = GetWindow<PlayerPrefs>();
            window.titleContent = new GUIContent("TITLE");
            window.Show();*/
            
            PlayerPrefs.DeleteAll();
        }

        private void OnGUI()
        {
            
        }
    }
}