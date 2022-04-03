using Warlords.Utils;

namespace Warlords.Board.UI
{
    public class UIBoardTileButton : ReactiveButton<UIBoardTile,UIBoardData>
    {
        private UIBoardData _data;
        private UIBoardTile _uiBoardTile;
        
        protected override UIBoardData Value => _data;
        protected override UIBoardTile Sender => _uiBoardTile;

        public void Init(UIBoardTile uiBoardTile, UIBoardData data)
        {
            _uiBoardTile = uiBoardTile;
            _data = data;
        }
        
    }
}