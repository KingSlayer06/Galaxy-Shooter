using UnityEngine;

namespace GalaxyShooter.Destructibles
{
    public class Astroid : Destructible
    {
        #region Variables

        [SerializeField] private float _rotationSpeed;
        
        #endregion
        
        #region Astroid Behaviour

        protected override void Movement()
        {
            base.Movement();
            transform.Translate(Vector3.down * (_speed * Time.deltaTime));
        }
        
        #endregion

        #region Unity Methods
        
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            
            if (other.CompareTag("Astroid"))
                return;
        }

        #endregion
    }
}
