using System;
using _PROJECT.Scripts.Data;
using UnityEngine;

namespace _PROJECT.Scripts
{
    public class Coin : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _playerLayer;
    
        public event Action<Coin> OnCoinTake = EventUtility.Empty;
        private void OnTriggerEnter(Collider other)
        {
            if ((_playerLayer.value & (1 << other.transform.gameObject.layer)) > 0)
            {
                OnCoinTake.Invoke(this);
            }
        }

        private void OnDestroy()
        {
            OnCoinTake = EventUtility.Empty;
        }
        
        public void ShowCoin()
        {
            gameObject.SetActive(true);
        }
    
    }
}
