using Cysharp.Threading.Tasks;
using Warlords.Infrastructure;

namespace Warlords.Board
{
    public class BoardUnitsInitializer : IAsyncLoad
    {
        private readonly UnitsFactory _unitsFactory;
        private readonly BoardDataService _boardDataService;
        private ISaveLoadDataService _saveLoadDataService;

        public BoardUnitsInitializer(ISaveLoadDataService saveLoadDataService, BoardDataService boardDataService,
            UnitsFactory unitsFactory)
        {
            _boardDataService = boardDataService;
            _saveLoadDataService = saveLoadDataService;
            _unitsFactory = unitsFactory;
        }

        public async UniTask AsyncLoad()
        {
            for (int i = 1; i <= 4; i++)
            {
                var unitContext = new UnitContext();
                BattlefieldUnitInfo battlefieldUnitInfo = _boardDataService.Battlefields[i - 1].BattlefieldUnitInfo;
                
                unitContext.UnitPivotTransform = battlefieldUnitInfo.Pivot;
                unitContext.Stats = new Stats(){ AttackPower = 1,AttackSpeed = 1,CastSpeed = 1,MagicResistance = 1,MovementSpeed = 1, HitPoints = 1, SpellPower = 1};

                Unit unit = _unitsFactory.Create(unitContext);

                await UniTask.Delay(50);
                battlefieldUnitInfo.Unit = unit;
            }
        }
    }
}