using System;
using System.Threading.Tasks;
using UnityEngine;
using Warlords.Infrastracture;
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

        private int _tempIndex = 1;
        private SelectableSpellButtonsHandler _spellButtonsHandler;
        private SelectableSpellView _selectableSpellViewPrefab;

        [Inject]
        private void Init(SpellDataContainer spellDataContainer, SelectableSpellButtonsHandler spellButtonsHandler, AsyncLoadingsRegister asyncLoadingsRegister)
        {
            asyncLoadingsRegister.Register(this);
            
            _spellButtonsHandler = spellButtonsHandler;
            _spellDataContainer = spellDataContainer;
        }
        
        public async Task AsyncLoad()
        {
            _selectableSpellViewPrefab = Resources.Load<SelectableSpellView>(AssetsPath.SelectableSpellViewPrefab);

            await Task.Delay(100);
            
            foreach (SpellInfoContext spellInfoContext in _spellDataContainer.SpellInfos)
            {
                foreach (SpellInfo spellInfo in spellInfoContext.Infos)
                {
                    Spawn(spellInfo.Type);
                }
            }
        }

        private void Spawn(SpellType type)
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
            spellData.Index = _tempIndex;

            selectableSpellView.Init(spellData);

            _spellButtonsHandler.Register(selectableSpellView.SelectableSpellButton);
            
            _tempIndex++;
        }
        
        
    }
}