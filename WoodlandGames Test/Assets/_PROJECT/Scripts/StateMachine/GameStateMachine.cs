using _PROJECT.Scripts.Manager;
using _PROJECT.Scripts.Settings;
using _PROJECT.Scripts.UI;
using UnityEngine;

namespace _PROJECT.Scripts.StateMachine
{
    public class GameStateMachine : MonoBehaviour
    {
        private BaseState _currentBaseState;
        [SerializeField]
        public CoinManager CoinManager;
        [SerializeField]
        public GameUIManager GameUIManager;
        [SerializeField]
        public HeartManager HeartManager;
        [SerializeField]
        public PlayerTeleportManager PlayerTeleportManager;
        [SerializeField]
        public EnemyManager EnemyManager;
        [SerializeField]
        public GameSettings GameSettings;
        [SerializeField]
        public Transform PlayerTransform;

        private void Start()
        {
            _currentBaseState = InitFirstState();
            _currentBaseState?.InitializeState();
        }

        private void Update()
        {
            _currentBaseState?.UpdateState();
        }

        private void FixedUpdate()
        {
            _currentBaseState?.FixUpdateState();
        }
        
        public void CreateNewState(BaseState newState)
        {
            _currentBaseState?.DisposeState();
            _currentBaseState = newState;
            _currentBaseState?.InitializeState();
        }

        private BaseState InitFirstState()
        {
            return new StartState(this);
        }

    }
}