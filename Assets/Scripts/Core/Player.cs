using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

using GalaxyShooter.InputActions;

namespace GalaxyShooter.Core
{
    public class Player : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerSO _playerSO;
        [SerializeField] private float _fireRate = 0.15f;
        

        private PlayerInputActions _playerInputActions;
        private GameObject _spawnManager;

        private float _canFire = -1f;

        #endregion

        #region Unity Methods

        private void OnEnable()
        {
            _playerInputActions.Enable();
        }
        
        private void OnDisable()
        {
            _playerInputActions.Disable();
        }

        private void Awake()
        {
            _playerInputActions = new PlayerInputActions();
        }

        private void Start()
        {
            PlayerInputActions.PlayerActions player = _playerInputActions.Player;
            _playerInputActions.Player.Shoot.performed += Shoot;
        }

        private void FixedUpdate()
        {
            Vector2 direction = _playerInputActions.Player.Movement.ReadValue<Vector2>();
            transform.Translate(direction * (_playerSO.Speed * Time.deltaTime));

            MovementBounds();
        }

        #endregion

        #region Player Behaviour

        private void MovementBounds()
        {
            // Clamp y-axis of the player
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y,-3f, 0f));

            // wrap x-axis of the player
            if (transform.position.x >= 9.5f)
                transform.position = new Vector3(-9.5f, transform.position.y, 0);
            else if (transform.position.x <= -9.5f)
                transform.position = new Vector3(9.5f, transform.position.y, 0);
        }

        private void Shoot(InputAction.CallbackContext callbackContext)
        {
            if (_canFire < Time.time)
            {
                _canFire = Time.time + _fireRate;
                
                if (!_playerSO.TripleShotEnabled)
                    Instantiate(_playerSO.LaserPrefab, transform.position + _playerSO.LaserSpawnOffset, Quaternion.identity);
                else
                    Instantiate(_playerSO.TripleShotLaserLaserPrefab, transform.position + _playerSO.LaserSpawnOffset, Quaternion.identity);
            }
        }

        #endregion

        #region PowerUps

        public void TripleShotEnabled(float duration)
        {
            StartCoroutine(EnableTripleShot(duration));
        }

        IEnumerator EnableTripleShot(float duration)
        {
            _playerSO.TripleShotEnabled = true;
            yield return new WaitForSeconds(duration);
            _playerSO.TripleShotEnabled = false;
        }

        public void SpeedBoostEnabled(float speed, float duration)
        {
            StartCoroutine(EnableSpeedBoost(speed, duration));
        }

        IEnumerator EnableSpeedBoost(float speed, float duration)
        {
            _playerSO.Speed += speed;
            yield return new WaitForSeconds(duration);
            _playerSO.Speed -= speed;
        }

        public void ShieldEnabled(float duration)
        {
            StartCoroutine(EnableShield(duration));
        }

        IEnumerator EnableShield(float duration)
        {
            GameObject shield = Instantiate(_playerSO.ShieldPrefab, transform.position, transform.rotation);
            shield.transform.parent = transform;
            yield return new WaitForSeconds(duration);
            Destroy(shield);
        }

        #endregion
    }
}