using UnityEngine;
using System.Collections.Generic;

namespace SwampAttack.Root
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private List<CompositeRoot> _roots;

        private void Awake() => _roots.ForEach(root => root.Compose());
    }
}