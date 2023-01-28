using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SwampAttack.Model.Input
{
    public class RaycastThrower : SerializedMonoBehaviour, IRaycastThrower
    { 
        [SerializeField] private Camera _camera;
        [SerializeField] private List<IRaycastHittable> _hittables;

        private const int RAYCAST_LAYER_MASK = 1 << 3;

        public void AddHittable(IRaycastHittable hittable)
        {
            if (hittable == null)
                throw new ArgumentNullException(nameof(hittable));
            
            _hittables.Add(hittable);
        }
        
        private void Update()
        {
            if (!UnityEngine.Input.GetMouseButtonDown(0))
                return;

            var clickPosition = _camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            var hit = Physics2D.Raycast(clickPosition, Vector2.zero, 1000f, RAYCAST_LAYER_MASK);

            if (hit.collider == null)
                return;
            
            foreach (var hittable in _hittables.Where(hittable => hittable.Collider == hit.collider))
                hittable.Hit();
        }
    }
}