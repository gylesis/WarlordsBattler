using UnityEngine;

namespace Warlords.UI.Menu
{
    public class ApplicationURLOpener
    {
        public static ApplicationURLOpener Instance;

        public ApplicationURLOpener()
        {
            Instance = this;
        }

        public void OpenURL(string URL)
        {
            Application.OpenURL(URL);
        }

    }
}