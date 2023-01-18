using GalaxyShooter.Managers;
using UnityEngine;

namespace GalaxyShooter.Core.PowerUps
{
    public abstract class PowerBuff : MonoBehaviour
    {
        #region Variables

        [SerializeField] protected PlayerSO playerSo;
        [SerializeField] protected float _speed;
        [SerializeField] protected float _powerUpDuration;

        #endregion

        #region Unity Methods

        private void Update()
        {
            transform.Translate(Vector3.down * (_speed * Time.deltaTime));
        
            if (transform.position.y <= -4.5f)
                Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) 
                return;
            
            var player = other.GetComponent<Player>();
            EnablePowerUp(player);
            GameManager.Instance.audioManager.PlaySound("powerUp");
            Destroy(gameObject);
        }

        #endregion

        #region PowerUp Behaviour

        protected abstract void EnablePowerUp(Player player);

        #endregion
    }
}