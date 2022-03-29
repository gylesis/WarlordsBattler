using System;
using System.Collections.Generic;
using UnityEngine;
using Warlords.Infrastructure;
using Zenject;

namespace Warlords.Board
{
    public class BattlefieldView : MonoBehaviour
    {
        [SerializeField] private Transform _pivot;

        public Transform Pivot => _pivot;


        public void Init(BattlefieldData data)
        {   
            
        }
        
    }


    public class BattlefieldsRegistry
    {
        private Dictionary<BattlefieldView, BattlefieldData> _battlefieldDatas =
            new Dictionary<BattlefieldView, BattlefieldData>();


        public BattlefieldsRegistry()
        {
            
        }
        
    }
    

    public class UnitsMover
    {

        public void Move(Movable movable, BattlefieldView battlefieldView)  
        {
            
        }
        
        
    }

    public abstract class Movable : MonoBehaviour
    {
        public abstract void Move();
        
    }

    public class SmoothMovable : Movable
    {
        public override void Move()
        {
            
        }
    }
    
    
    public class BattlefieldData
    {
        public int Index;
        public CellContext CellData;

    }

    public struct CellContext
    {
        public GameObject GameObject;
        public Vector3 Pos;
    }
    
    
    
}