using UnityEngine;

namespace Warlords.Board.UI
{
    [RequireComponent(typeof(UIBoardTileButton))]
    public class UIBoardTile : MonoBehaviour
    {
        public UIBoardTileButton Button;

        private void Reset()
        {
            Button = GetComponent<UIBoardTileButton>();
        }

        public void Init(UIBoardData data)
        {
            if(Button == null) Button = GetComponent<UIBoardTileButton>();
            
            Button.Init(this,data);
        }
        
        
    }
}