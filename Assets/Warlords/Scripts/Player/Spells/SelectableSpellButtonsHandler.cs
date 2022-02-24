using System.Linq;
using ModestTree;
using UniRx;
using Warlords.Player.Attributes;
using Warlords.Utils;

namespace Warlords.Player.Spells
{
    public class SelectableSpellButtonsHandler
    {
        private readonly PlayerInfoPreSaver _playerInfoPreSaver;

        public SelectableSpellButtonsHandler(PlayerInfoPreSaver playerInfoPreSaver)
        {
            _playerInfoPreSaver = playerInfoPreSaver;
        }
        
        public void Register(SelectableSpellButton spellButton)
        {
            spellButton.Clicked.TakeUntilDestroy(spellButton).Subscribe((HandleClick));
        }

        private void HandleClick(ButtonContext<SpellData> context)
        {
            _playerInfoPreSaver.Overwrite((playerInfo =>
            {
                var spellInfoSpellDatas = playerInfo.SpellInfo.SpellDatas;
                
                SpellData spellData = spellInfoSpellDatas.First(spell => spell.Type == context.Value.Type);

                var index = spellInfoSpellDatas.IndexOf(spellData);

                spellInfoSpellDatas[index] = context.Value;
            }));
            
        }
    }
}