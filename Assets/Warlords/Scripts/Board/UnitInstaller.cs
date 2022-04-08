using UnityEngine;
using Zenject;

namespace Warlords.Board
{
    public class UnitInstaller : MonoInstaller
    {
       // [Inject] private UnitData _unitData;
        
        public override void InstallBindings()
        {
            Debug.Log("bind");
           // Container.Bind<UnitData>().FromInstance(_unitData);
        }
    }
}