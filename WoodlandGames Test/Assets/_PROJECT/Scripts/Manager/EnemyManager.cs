using System.Collections.Generic;
using _PROJECT.Scripts.Settings;
using UnityEngine;

namespace _PROJECT.Scripts.Manager
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField]
        private List<Enemy> _enemies = new List<Enemy>();
        [SerializeField]
        private List<Transform> _placesToSpawnEnemies = new List<Transform>();
        private readonly List<int> _availableIndexesOfPlacesToSpawn = new List<int>();
        [SerializeField]
        private Enemy _enemyPrefab;



        public void SpawnEnemy(Level level, Transform playerTransform)
        {
            ResetAvailablePlaceList();
            for (int i = 0; i < level.EnemyCount; i++)
            {
                var index = ChoosePlaceIndex();
                var enemy = Instantiate(_enemyPrefab, _placesToSpawnEnemies[index]);
                _enemies.Add(enemy);
                enemy.SetTarget(playerTransform, _placesToSpawnEnemies[index], level.EnemySpeed);
            }
        }

        public void BackEnemiesToStartingPositions()
        {
            foreach (var enemy in _enemies)
            {
                enemy.BackToStartingPosition();
            }
        }

        public void RemoveEnemies()
        {
            foreach (var enemy in _enemies)
            {
                Destroy(enemy.gameObject);
            }
            _enemies.Clear();
        }

        private void ResetAvailablePlaceList()
        {
            _availableIndexesOfPlacesToSpawn.Clear();

            for (int i = 0; i < _placesToSpawnEnemies.Count; i++)
            {
                _availableIndexesOfPlacesToSpawn.Add(i);
            }
        }

        private int ChoosePlaceIndex()
        {
            var index = _availableIndexesOfPlacesToSpawn[Random.Range(0, _availableIndexesOfPlacesToSpawn.Count)];
            _availableIndexesOfPlacesToSpawn.Remove(index);
            return index;
        }
        
    }
}