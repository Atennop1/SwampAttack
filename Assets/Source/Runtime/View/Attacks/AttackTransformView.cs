using System;
using SwampAttack.Runtime.Model.Attacks;
using UnityEngine;

namespace SwampAttack.Runtime.View.Attacks
{
    public class AttackTransformView : MonoBehaviour
    {
        protected IAttack Attack { get; private set; }

        public void Init(IAttack attack)
        {
            Attack = attack ?? throw new ArgumentException("Attack can't be null");
        }
        
        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (Attack.IsCollisionWithHealth(coll, out var healthTransformView) && 
                !healthTransformView.IsDead && healthTransformView.CanTakeDamage) Attack.Collide(coll);
        }
    }
}