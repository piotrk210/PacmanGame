using System.Collections.Generic;
using UnityEngine;

namespace _PROJECT.Scripts.Manager
{
    public class PlayerTeleportManager : MonoBehaviour
    {
        [SerializeField]
        private List<TeleportIn> _entranceTeleports = new List<TeleportIn>();
        [SerializeField]
        private List<Transform> _exitTeleports = new List<Transform>();
        [SerializeField]
        private CharacterController _characterController;
        [SerializeField]
        private DoorManager _doorManager;

        public void SetTeleports()
        {
            for (int i = 0; i < _entranceTeleports.Count; i++)
            {
                var teleport = _entranceTeleports[i]; 
                teleport.ResetEvent();
                teleport.SetTargetToTeleport(_exitTeleports[i]);
                teleport.OnTriggerEnterPlayer += TeleportPlayer;
            }
        }

        private void TeleportPlayer(Transform targetTransform)
        {
            _characterController.enabled = false;
            _characterController.transform.position = targetTransform.position;
            _characterController.enabled = true;
            _doorManager.ResetDoorsState();
        }
        
        public void SetStartingPosition()
        {
            TeleportPlayer(_exitTeleports[0]);
        }
        
    }
}