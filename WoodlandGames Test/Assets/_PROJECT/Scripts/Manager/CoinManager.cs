using System;
using System.Collections.Generic;
using _PROJECT.Scripts.Data;
using _PROJECT.Scripts.Settings;
using UnityEngine;

namespace _PROJECT.Scripts.Manager
{
    public class CoinManager : MonoBehaviour
    {
        [SerializeField]
        private List<Coin> _coins = new List<Coin>();
        [SerializeField]
        private List<Transform> _placesToSpawnCoins = new List<Transform>();
        [SerializeField]
        private Coin _coinPrefab;

        public event Action OnGatherAllCoins = EventUtility.Empty;
        
        [SerializeField]
        private int _gatheredCoins;
        private Level _currentLevel;
        
        private int GatheredCoins
        {
            get => _gatheredCoins;
            set
            {
                _gatheredCoins = value;

                if (_gatheredCoins >= _currentLevel.CoinNumberToWin)
                {
                    OnGatherAllCoins.Invoke();
                }
            }
        }

        public void InitCoinsForNewLevel(Level level)
        {
            _currentLevel = level;
            
            ResetCoins();

            for (int i = 0; i < level.CoinNumberToWin; i++)
            {
                var coin = Instantiate(_coinPrefab, _placesToSpawnCoins[i]);
                _coins.Add(coin);
                coin.OnCoinTake += UpdateGatheredCoinNumber;
            }
        }

        private void UpdateGatheredCoinNumber(Coin coin)
        {
            GatheredCoins++;
            DestroyCoinObject(coin);
            _coins.Remove(coin);
        }

        private void ResetCoins()
        {
            GatheredCoins = 0;


            for (int i = 0; i < _coins.Count; i++)
            {
                DestroyCoinObject(_coins[i]);
            }
            _coins.Clear();
        }

        private void DestroyCoinObject(Coin coin)
        {
            coin.OnCoinTake -= UpdateGatheredCoinNumber;
            Destroy(coin.gameObject);
        }

        public void ResetOnGatherAllCoins()
        {
            OnGatherAllCoins = EventUtility.Empty;
        }

    }
}