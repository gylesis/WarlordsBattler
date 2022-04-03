using UnityEngine;
using Zenject;

namespace Warlords.Board.UI
{
    public class BoardCustomizationPanel : MonoBehaviour
    {
        [SerializeField] private UIBoard _board;
        
        [Inject]
        private void Init()     
        {
            var boardBoardTiles = _board.BoardTiles;
            
            foreach (UIBoardTile boardBoardTile in boardBoardTiles)
            {
                var uiBoardData = new UIBoardData();
                uiBoardData.Upgrade = new TileUpgrade();
                uiBoardData.Upgrade.Name = $" {Random.Range(0, 999)} ";

                boardBoardTile.Init(uiBoardData);
                
                /*boardBoardTile.Button.Clicked
                    .TakeUntilDestroy(this)
                    .Subscribe(ProcessClick);*/
            }
        }

        private void ProcessClick(UIBoardData data)
        {
            
        }
        
        
    }
}