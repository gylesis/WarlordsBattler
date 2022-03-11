using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Warlords.Infrastructure;
using Warlords.Player.Attributes;
using Warlords.Utils;
using Zenject;

namespace Warlords.Player.Spells
{
    public class MainSpellButtonsHandler : MonoBehaviour, IAsyncLoad
    {
        [SerializeField] private SelectableSpellsViewContainer[] _spellViewContainers;

        private MainSpellView[] _mainSpellViews;
        private ISaveLoadDataService _saveLoadDataService;

        private SpellType _currentSpellType;
        
        [Inject]
        private void Init(ISaveLoadDataService saveLoadDataService, AsyncLoadingsRegister asyncLoadingsRegister,
            MainSpellsViewContainer spellsViewContainer, PlayerInfoPreSaver playerInfoPreSaver)
        {
            asyncLoadingsRegister.Register(this);

            playerInfoPreSaver.PlayerInfoSaved.TakeUntilDestroy(this)
                .Subscribe(unit => UpdateSpellsView(SpellType.None));
            
            _mainSpellViews = spellsViewContainer.MainSpellViews;

            _saveLoadDataService = saveLoadDataService;
        }

        public async UniTask AsyncLoad()
        {
            var spellDatas = _saveLoadDataService.Data.PlayerInfo.SpellInfo.SpellDatas;

            for (var index = 0; index < _mainSpellViews.Length; index++)
            {
                MainSpellView mainSpellView = _mainSpellViews[index];

                if(mainSpellView.SpellType == SpellType.None) continue;
                
                mainSpellView.Init(spellDatas[index]);
                mainSpellView.MainSpellButton.Clicked.TakeUntilDestroy(this).Subscribe(HandleClick);
            }

            OpenSpellViewContainer(SpellType.None);
            
            await UniTask.CompletedTask;
        }

        private void HandleClick(EventContext<SpellType> context)
        {
            UpdateSpellsView(context.Value);
        }

        private void UpdateSpellsView(SpellType spellType)
        {
            SpellType targetSpellType = spellType;

            if (_currentSpellType == targetSpellType) // if double clicked
                targetSpellType = SpellType.None;

            OpenMainSpellView(targetSpellType);
            OpenSpellViewContainer(targetSpellType);

            _currentSpellType = targetSpellType;
        }

        private void OpenMainSpellView(SpellType targetSpellType)
        {
            foreach (MainSpellView mainSpellView in _mainSpellViews)
            {
                if (mainSpellView.SpellType == targetSpellType)
                {
                    mainSpellView.ShowSelection();
                }
                else
                {
                    mainSpellView.HideSelection();
                }
            }
        }

        private void OpenSpellViewContainer(SpellType spellType)
        {
            foreach (SelectableSpellsViewContainer spellViewContainer in _spellViewContainers)
            {
                if (spellViewContainer.SpellType != spellType)
                {
                    spellViewContainer.Hide();
                }
                else
                {
                    spellViewContainer.Show();
                }
            }
        }
        
    }
}