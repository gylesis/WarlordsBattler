using UnityEngine;

namespace Warlords
{
    public class ClearSaveDataService : MonoBehaviour
    {
        public void ClearPrefs()
        {
            PlayerPrefs.DeleteAll();
            Application.Quit();
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}