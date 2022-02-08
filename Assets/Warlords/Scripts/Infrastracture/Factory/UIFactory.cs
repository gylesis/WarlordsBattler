using System.Threading.Tasks;
using UnityEngine;
using Warlords.UI.PopUp;
using Object = UnityEngine.Object;

namespace Warlords.Infrastracture
{
    public class UIFactory
    {
        public async Task<PlayerNamePopUp> Create(string path, Transform parent)
        {
            var loadedPopUp = Resources.Load<PlayerNamePopUp>(path);

            Task delay = Task.Delay(500);

            await delay;

            PlayerNamePopUp namePopUp = Object.Instantiate(loadedPopUp, parent);

            return namePopUp;
        }
        
    }
}