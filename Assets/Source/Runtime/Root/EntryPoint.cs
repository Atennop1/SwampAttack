using System.Collections.Generic;
using SwampAttack.Runtime.Root.Interfaces;
using UnityEngine;

namespace SwampAttack.Runtime.Root
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private List<CompositeRoot> _roots;
        
        private void Awake() 
            => _roots.ForEach(root => root.Compose());
    }
}