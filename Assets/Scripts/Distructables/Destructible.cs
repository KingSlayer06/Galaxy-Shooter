using GalaxyShooter.Core;
using GalaxyShooter.Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GalaxyShooter.Destructibles
{
    public class Destructible : MonoBehaviour
    {
        #region Variables

        [SerializeField] protected PlayerSO _playerSO;
        [SerializeField] protected float _speed;
        [SerializeField] protected GameObject _explosionPrefab;
        
        protected Animator _animator;
        
        #endregion

        #region Unity Methods

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        protected virtual void Update()
        {
            Movement();
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Bullet"))
            {
                Destroy(other.gameObject);
                _playerSO.Score += 10;
            }

            if (other.CompareTag("Player"))
                other.GetComponent<Health>()?.TakeDamage();
            
            _speed = 0;
            
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            GameManager.Instance.audioManager.PlaySound("explosion");
            Destroy(gameObject);
        }

        #endregion

        #region Destructible Behaviour

        protected virtual void Movement()
        {
            var xPosition = Random.Range(-8f, 8f);
            if (transform.position.y <= -4.5f)
                transform.position = new Vector3(xPosition, 6.5f, 0);
        }

        #endregion
    }
}
