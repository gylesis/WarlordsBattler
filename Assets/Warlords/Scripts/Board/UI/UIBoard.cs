using UnityEngine;

namespace Warlords.Board.UI
{
    public class UIBoard : MonoBehaviour
    {
        [SerializeField] private UIBoardTile[] _boardTiles;

        public UIBoardTile[] BoardTiles => _boardTiles;

        [ContextMenu(nameof(FindTiles))]
        public void FindTiles()
        {
            _boardTiles = GetComponentsInChildren<UIBoardTile>(true);
        }


        public void LightTile()
        {
            
        }
        
        
    }
}