﻿using System;
using UniRx;
using UnityEngine;

namespace Warlords.Player.Attributes
{
    public class PlayerInfoPreSaver
    {
        public PlayerInfo PlayerInfo => _playerInfo;
        
        private PlayerInfo _playerInfo;
        private PlayerInfo _oldPlayerInfo;

        private readonly ISaveLoadDataService _saveLoadDataService;
        private readonly PlayerInfoChangedDispatcher _playerInfoChangedDispatcher;
        public Subject<PlayerInfo> PlayerInfoDiscarded { get; } = new Subject<PlayerInfo>();
        public Subject<Unit> PlayerInfoSaved { get; } = new Subject<Unit>();
        
        public PlayerInfoPreSaver(ISaveLoadDataService saveLoadDataService, PlayerInfoChangedDispatcher playerInfoChangedDispatcher)
        {
            _playerInfoChangedDispatcher = playerInfoChangedDispatcher;
            _saveLoadDataService = saveLoadDataService;
            _playerInfo = _saveLoadDataService.Data.PlayerInfo;
            _oldPlayerInfo = _playerInfo.Copy();
        }

        public void Overwrite(Action<PlayerInfo> overwrite)
        {
            overwrite?.Invoke(_playerInfo);

            _playerInfoChangedDispatcher.ChangePlayerInfo(_playerInfo);
        }

        public void Save()
        {
            PlayerInfoSaved.OnNext(Unit.Default);
            
            _saveLoadDataService.Overwrite(playerInfo =>
            {
                PlayerInfo playerInfoCopy = _playerInfo.Copy();
                
                playerInfo.PlayerInfo = playerInfoCopy;
                _oldPlayerInfo = playerInfoCopy;
            });
        }

        public void Discard()
        {
            _playerInfo = _oldPlayerInfo.Copy();
            
            PlayerInfoDiscarded.OnNext(_playerInfo);
        }
    }
}