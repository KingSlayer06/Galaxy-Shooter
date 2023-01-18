using System;
using GalaxyShooter.Core;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GalaxyShooter.Destructibles
{
    public class Enemy : Destructible
    {
        #region Variables

        [SerializeField] private GameObject _laserPrefab;
        [SerializeField] private float _fireRate = 5f;
        
        private float _canFire = -1f;
        
        #endregion
        
        #region Enemy Behaviour

        protected override void Movement()
        {
            base.Movement();
            transform.Translate(Vector3.down * (_speed * Time.deltaTime));
        }
        
        private void Shoot()
        {
            if (_canFire < Time.time)
            {
                _canFire = Time.time + _fireRate;
                
                Instantiate(_laserPrefab, transform.position + _playerSO.LaserSpawnOffset, Quaternion.identity);
            }
        }

        #endregion

        #region Unity Methods

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            
            if (other.CompareTag("Enemy"))
                return;
        }

        #endregion
    }
}