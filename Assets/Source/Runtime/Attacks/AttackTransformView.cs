using UnityEngine;

namespace SwampAttack.Runtime.Attacks
{
    public class AttackTransformView : MonoBehaviour
    {
        protected IAttack _attack;

        public void Init(IAttack attack)
        {
            _attack = attack;
        }
        
        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (_attack.IsCollisionWithHealth(coll, out _))
                _attack.Collide(coll);
        }
    }
}