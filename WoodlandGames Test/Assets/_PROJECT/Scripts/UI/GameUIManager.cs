using System;
using _PROJECT.Scripts.Data;
using _PROJECT.Scripts.Settings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _PROJECT.Scripts.UI
{
    public class GameUIManager : MonoBehaviour
    {
        [SerializeField]
        private HeartPanel _heartPanel;
        [SerializeField]
        private RectTransform _resultPanel;
        [SerializeField]
        private TextMeshProUGUI _resultText;

        [SerializeField]
        private Button _exitButton;

        public event Action OnClick = EventUtility.Empty;
        
        private void OnEnable()
        {
             _exitButton.onClick.AddListener(ClickExitButton);   
        }

        private void OnDestroy()
        {
            ResetEventsAssignedToButton();
        }

        public void InitGameUI(Level level)
        {
            _heartPanel.FillHearsList(level);
            _heartPanel.ShowPanel();
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void ResetGameUI()
        {
            HideResultUI();
        }
        
        public void ShowResultUI(GameLevelResult result)
        {
            _resultText.text = result.ToString();
            _resultPanel.gameObject.SetActive(true);
            
            Cursor.lockState = CursorLockMode.None;
            
            _heartPanel.HidePanel();
        }

        public void HideResultUI()
        {
            _resultPanel.gameObject.SetActive(false);
            _heartPanel.ShowPanel();
            
        }
        
        private void ClickExitButton()
        {
            OnClick.Invoke();
        }

        public void ResetEventsAssignedToButton()
        {
            OnClick = EventUtility.Empty;
        }
        

    }
}
