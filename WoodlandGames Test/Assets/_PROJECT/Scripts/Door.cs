using UnityEngine;

namespace _PROJECT.Scripts
{
    public class Door : MonoBehaviour
    {
        [SerializeField]
        private GameObject _doorModel;
        [SerializeField]
        private LayerMask _openingLayers;

        [SerializeField]
        private int _agentsInTrigger;

        private void Open()
        {
            _doorModel.SetActive(false);
        }

        private void Close()
        {
            _doorModel.SetActive(true);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if ((_openingLayers.value & (1 << other.transform.gameObject.layer)) > 0)
            {
                Open();
                _agentsInTrigger++;
                

                //Debug.Log("in" + _agentsInTrigger);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            //to do: check is everyone how can open left trigger area
            if((_openingLayers.value & (1 << other.transform.gameObject.layer)) > 0)
            {
                _agentsInTrigger--;
                //Debug.Log("out" + _agentsInTrigger);
                if (_agentsInTrigger == 0)
                {
                    Close();
                }
            }
        }

        public void ResetDoorState()
        {
            _agentsInTrigger = 0;
            Close();
        }
    }
}
