using _PROJECT.Scripts.Data;
using UnityEngine;

namespace _PROJECT.Scripts.StateMachine
{
    public class WinState : BaseState
    {
        public WinState(GameStateMachine gameStateMachine) : base(gameStateMachine)
        { }

        public override void InitializeState()
        {
            AssignExitEvents();
            _stateMachine.GameUIManager.ShowResultUI(GameLevelResult.Win);
            PauseGame();
        }

        public override void DisposeState()
        {
            UnAssignExitEvents();
            _stateMachine.GameUIManager.HideResultUI();
            ResumeGame();
        }

        private void AssignExitEvents()
        {
            _stateMachine.GameUIManager.OnClick += () =>
                                                   {
                                                       _stateMachine.CreateNewState(new StartState(_stateMachine));
                                                   };
        }
        
        private void UnAssignExitEvents()
        {
            _stateMachine.GameUIManager.ResetEventsAssignedToButton();
        }
        
        private void PauseGame ()
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        private void ResumeGame ()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
    }
    
}