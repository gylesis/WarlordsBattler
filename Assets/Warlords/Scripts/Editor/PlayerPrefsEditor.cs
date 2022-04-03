using UnityEditor;
using UnityEngine;
using Warlords.Utils;

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
            
            PlayerPrefs.DeleteKey(Constants.Saves.PrefsKey);
        }

        private void OnGUI()
        {
            
        }
    }
}