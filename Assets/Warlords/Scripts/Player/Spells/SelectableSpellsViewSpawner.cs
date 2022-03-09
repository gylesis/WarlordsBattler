using System;
using System.Linq;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warlords.Infrastructure;
using Warlords.Utils;
using Zenject;

namespace Warlords.Player.Spells
{
    public class SelectableSpellsViewSpawner : MonoBehaviour, IAsyncLoad
    {
        [SerializeField] private Transform _spell1Parent;
        [SerializeField] private Transform _spell2Parent;
        [SerializeField] private Transform _spell3Parent;
        [SerializeField] private Transform _ultimateParent;
        [SerializeField] private Transform _counterParent;
        [SerializeField] private Transform _reactionParent;

        private SpellDataContainer _spellDataContainer;

        private int _tempNameIndex = 1;
        private SelectableSpellsButtonsHandler _spellsButtonsHandler;
        private SelectableSpellView _selectableSpellViewPrefab;
        private ISaveLoadDataService _saveLoadDataService;

        [Inject]
        private void Init(SpellDataContainer spellDataContainer, SelectableSpellsButtonsHandler spellsButtonsHandler,
            AsyncLoadingsRegister asyncLoadingsRegister, ISaveLoadDataService saveLoadDataService)
        {
            _saveLoadDataService = saveLoadDataService;
            asyncLoadingsRegister.Register(this);

            _spellsButtonsHandler = spellsButtonsHandler;
            _spellDataContainer = spellDataContainer;
        }

        public async UniTask AsyncLoad()
        {
            ResourceRequest resourceRequest =
                Resources.LoadAsync<SelectableSpellView>(AssetsPath.SelectableSpellView);

            await resourceRequest;

            _selectableSpellViewPrefab = resourceRequest.asset as SelectableSpellView;

            var playerSpellDatas = _saveLoadDataService.Data.PlayerInfo.SpellInfo.SpellDatas;

            foreach (SpellInfoContext spellInfoContext in _spellDataContainer.SpellInfos)
            {
                foreach (SpellInfo spellInfo in spellInfoContext.Infos)
                {
                    if(spellInfo.Type == SpellType.None) continue;
                    
                    SelectableSpellView spellView = Spawn(spellInfo.Type);

                    SpellData selectableSpellView = playerSpellDatas.First(x => x.Type == spellView.SpellData.Type);

                    if (spellView.SpellData.Index == selectableSpellView.Index)
                    {
                        spellView.ShowOutline();
                    }
                    else
                    {
                        spellView.HideOutline();
                    }
                    
                }
            }
        }

        private SelectableSpellView Spawn(SpellType type)
        {
            Transform spawnParent;

            switch (type)
            {
                case SpellType.Spell1:
                    spawnParent = _spell1Parent;
                    break;
                case SpellType.Spell2:
                    spawnParent = _spell2Parent;
                    break;
                case SpellType.Spell3:
                    spawnParent = _spell3Parent;
                    break;
                case SpellType.Ultimate:
                    spawnParent = _ultimateParent;
                    break;
                case SpellType.Counter:
                    spawnParent = _counterParent;
                    break;
                case SpellType.Reaction:
                    spawnParent = _reactionParent;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            SelectableSpellView selectableSpellView = Instantiate(_selectableSpellViewPrefab, spawnParent);

            var spellData = new SpellData();

            spellData.Type = type;
            spellData.Index = _tempNameIndex;

            selectableSpellView.Init(spellData);

            _spellsButtonsHandler.Register(selectableSpellView);

            _tempNameIndex++;
            
            return selectableSpellView;
        }
    }
}