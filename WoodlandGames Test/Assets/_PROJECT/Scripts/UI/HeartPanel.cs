using System.Collections.Generic;
using _PROJECT.Scripts.Manager;
using _PROJECT.Scripts.Settings;
using UnityEngine;

namespace _PROJECT.Scripts.UI
{
    public class HeartPanel : MonoBehaviour
    {
        [SerializeField]
        private HeartManager _heartManager;
        [SerializeField]
        private GameObject _hearPrefab;

        private readonly List<GameObject> _heartsList = new List<GameObject>();

        private void Start()
        {
            _heartManager.OnHeartNumberUpdate += UpdateHeartAmount;
        }

        private void OnDestroy()
        {
            _heartManager.OnHeartNumberUpdate -= UpdateHeartAmount;
        }

        private void UpdateHeartAmount(int currentHearNumber)
        {
            foreach (var heartImage in _heartsList)
            {
                heartImage.SetActive(false);
            }
            
            for (int i = 0; i < currentHearNumber; i++)
            {
                _heartsList[i].SetActive(true);
            }
        }

        public void FillHearsList(Level level)
        {
            // if (_heartsList.Count < level.StartingHeartNumber)
            // {
            //     
            // }

            int numberOfHeartsToSpawn = _heartsList.Count < level.StartingHeartNumber ?
                                            level.StartingHeartNumber - _heartsList.Count :
                                            0;
            for (int i = 0; i < numberOfHeartsToSpawn; i++)
            {
                var item = Instantiate(_hearPrefab, gameObject.transform);
                _heartsList.Add(item);
            }
        }

        public void ShowPanel()
        {
            gameObject.SetActive(true);
        }

        public void HidePanel()
        {
            gameObject.SetActive(false);
        }
    }
}