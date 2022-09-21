using _PROJECT.Scripts.Data;
using _PROJECT.Scripts.Manager;
using UnityEngine;

namespace _PROJECT.Scripts
{
    public class PlayerCollider : MonoBehaviour
    {
        [SerializeField]
        private HeartManager _heartManager;
    
        private void OnTriggerEnter(Collider other)
        {


            if(other.gameObject.layer == Keys.Layers.ENEMY )
            {
                _heartManager.LoseHeart();
            }
        }

    
        private void OnTriggerExit(Collider other)
        {

        }
    }
}
