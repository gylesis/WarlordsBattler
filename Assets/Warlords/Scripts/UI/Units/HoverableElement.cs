using System.Collections.Generic;
using UnityEngine;

namespace Warlords.UI.Units
{
    public class HoverableElement : UIElement<HoverableElement>
    {
        [SerializeField] private HoverableElement[] _hoverableElements;
        protected override HoverableElement Sender => this;

        public IReadOnlyList<HoverableElement> HoverableElements => _hoverableElements;
        
        /*[Inject]
        private void Init()
        {
            
        }*/
        
    }


    public class UnitsViewSpawner
    {

        public UnitsViewSpawner()
        {
            
        }

    }
    
}