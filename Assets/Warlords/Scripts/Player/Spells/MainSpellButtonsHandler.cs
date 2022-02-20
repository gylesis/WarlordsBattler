using System.Threading.Tasks;
using UniRx;
using UnityEngine;
using Warlords.Infrastracture;
using Warlords.Utils;
using Zenject;

namespace Warlords.Player.Spells
{
    public class MainSpellButtonsHandler : MonoBehaviour, IAsyncLoad
    {
        [SerializeField] private MainSpellView[] _mainSpellViews;
        [SerializeField] private SelectableSpellsViewContainer[] _spellViewContainers;
        
        private ISaveLoadDataService _saveLoadDataService;

        [Inject]
        private void Init(ISaveLoadDataService saveLoadDataService, AsyncLoadingsRegister asyncLoadingsRegister)
        {
            asyncLoadingsRegister.Register(this);
            
            _saveLoadDataService = saveLoadDataService;
        }

        public async Task AsyncLoad()
        {
            var spellDatas = _saveLoadDataService.Data.PlayerInfo.SpellInfo.SpellDatas;

            for (var index = 0; index < _mainSpellViews.Length; index++)
            {
                MainSpellView spellView = _mainSpellViews[index];
                
                spellView.Init(spellDatas[index]);
                spellView.MainSpellButton.Clicked.TakeUntilDestroy(this).Subscribe(HandleClick);
            }

            await Task.Delay(1);
        }

        private void HandleClick(ButtonContext<SpellType> context)
        {
            SpellType targetSpellType = context.Value;

            foreach (SelectableSpellsViewContainer spellViewContainer in _spellViewContainers)
            {
                if (spellViewContainer.SpellType != targetSpellType)
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