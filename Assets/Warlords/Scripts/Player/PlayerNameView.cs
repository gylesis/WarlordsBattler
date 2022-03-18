using System;
using UnityEngine;

namespace Warlords.Player
{
    public class PlayerNameView : PlayerInfoView
    {
        public override void PlayerInfoChanged(PlayerInfo playerInfo)
        {
            var playerName = playerInfo.Name;
            
            Debug.Log(playerName);
            
            if (playerName == String.Empty)
            {
                _infoView.text = "Unnamed";
            }
            else
            {
                _infoView.text = playerName;
            }
        }

        public override void PlayerInfoDiscarded(PlayerInfo playerInfo)
        {
            if (playerInfo.Name == String.Empty)
            {
                _infoView.text = "Unnamed";
            }
            else
            {
                _infoView.text = playerInfo.Name;
            }
        }
    }
}