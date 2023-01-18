using System;
using System.Collections;
using System.Collections.Generic;
using GalaxyShooter.Core;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GalaxyShooter.Managers
{
    public class SpawnManager : MonoBehaviour
    {
        #region Variables
        
        [SerializeField] private List<GameObject> _enemyPrefabs;
        [SerializeField] private List<GameObject> _powerUpPrefabs;
        
        [SerializeField] private Transform _enemyContainer;
        [SerializeField] private float _enemySpawnDelay;
        [SerializeField] private float _powerUpSpawnDelay;

        private bool _spawnItems = true;

        #endregion

        #region Unity Methods

        private void OnEnable()
        {
            GameManager.OnGameStateChanged += SpawnEnemy;
            GameManager.OnGameStateChanged += SpawnPowerUps;
        }

        private void OnDisable()
        {
            GameManager.OnGameStateChanged -= SpawnEnemy;
            GameManager.OnGameStateChanged -= SpawnPowerUps;
        }

        #endregion

        #region Spawn Behaviour

        private void SpawnEnemy(GameManager.GameState gameState)
        {
            StartCoroutine(SpawnEnemyRoutine());
        }
        
        IEnumerator SpawnEnemyRoutine()
        {
            while (_spawnItems)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 6.5f, 0);
                
                int enemyID = Random.Range(0, _enemyPrefabs.Count);
                GameObject enemy = Instantiate(_enemyPrefabs[enemyID], spawnPosition, Quaternion.identity);
                enemy.transform.parent = _enemyContainer;
                yield return new WaitForSeconds(_enemySpawnDelay);
            }
        }

        private void SpawnPowerUps(GameManager.GameState gameState)
        {
            StartCoroutine(SpawnPowerUps());
        }

        IEnumerator SpawnPowerUps()
        {
            while (_spawnItems)
            {
                yield return new WaitForSeconds(_powerUpSpawnDelay);
                Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 6.5f, 0);
                
                int powerUpID = Random.Range(0, _powerUpPrefabs.Count);
                GameObject tripleShot = Instantiate(_powerUpPrefabs[powerUpID], spawnPosition, Quaternion.identity);
                tripleShot.transform.parent = transform;
            }
        }

        private void SpawnItems(GameManager.GameState gameState)
        {
            _spawnItems = (gameState == GameManager.GameState.Start);
        }

        #endregion
    }
}