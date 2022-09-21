using System.Collections.Generic;
using UnityEngine;

namespace _PROJECT.Scripts.Manager
{
    public class DoorManager : MonoBehaviour
    {
        [SerializeField]
        private List<Door> _doors = new List<Door>();

        public void ResetDoorsState()
        {
            foreach (var door in _doors)
            {
                door.ResetDoorState();
            }
        }
    }
}