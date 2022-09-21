using _PROJECT.Scripts.Data;
using UnityEngine;

namespace _PROJECT.Scripts.StateMachine
{
    public class GamePlayLevelOneState : BaseState
    {
        public GamePlayLevelOneState(GameStateMachine gameStateMachine) : base(gameStateMachine)
        { }

        public override void InitializeState()
        {
            AssignExitEvents();
        }

        public override void DisposeState()
        {
            UnAssignExitEvents();
            _stateMachine.EnemyManager.RemoveEnemies();
        }

        private void AssignExitEvents()
        {
            _stateMachine.CoinManager.OnGatherAllCoins 
                += () => { _stateMachine.CreateNewState(new GamePlayLevelTwoState(_stateMachine)); };
            _stateMachine.HeartManager.OnLoseAllHearts
                += () => { _stateMachine.CreateNewState(new FailState(_stateMachine)); };
        }
        
        private void UnAssignExitEvents()
        {
            _stateMachine.CoinManager.ResetOnGatherAllCoins();
            _stateMachine.HeartManager.ResetOnLoseAllHearts();
        }
    }
}