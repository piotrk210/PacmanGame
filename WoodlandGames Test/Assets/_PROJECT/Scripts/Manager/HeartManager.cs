using System;
using _PROJECT.Scripts.Data;
using _PROJECT.Scripts.Settings;
using UnityEngine;

namespace _PROJECT.Scripts.Manager
{
    public class HeartManager : MonoBehaviour
    {
        [SerializeField]
        private int _currentHeartNumber;
        [SerializeField]
        private PlayerTeleportManager _playerTeleportManager;
        [SerializeField]
        private EnemyManager _enemyManager;

        public event Action<int> OnHeartNumberUpdate = EventUtility.Empty;
        public event Action OnLoseAllHearts = EventUtility.Empty;

        private int CurrentHeartNumber
        {
            set
            {
                if (value > 0)
                {
                    _currentHeartNumber = value;
                    OnHeartNumberUpdate.Invoke(value);
                }
                else
                {
                    OnLoseAllHearts.Invoke();
                }
            }
            get => _currentHeartNumber;
        }
    

        public void ResetHearts(Level level)
        {
            CurrentHeartNumber = level.StartingHeartNumber;
        }

        public void LoseHeart()
        {
            CurrentHeartNumber--;
            _playerTeleportManager.SetStartingPosition();
            _enemyManager.BackEnemiesToStartingPositions();
        }
        
        public void ResetOnLoseAllHearts()
        {
            OnLoseAllHearts = EventUtility.Empty;
        }
    }
}
