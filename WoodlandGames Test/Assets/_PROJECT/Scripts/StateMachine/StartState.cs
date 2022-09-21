using _PROJECT.Scripts.Data;
using UnityEngine;

namespace _PROJECT.Scripts.StateMachine
{
    public class StartState : BaseState
    {
        public StartState(GameStateMachine stateMachine) : base(stateMachine)
        { }
        
        
        public override void InitializeState()
        {
            _stateMachine.PlayerTeleportManager.SetStartingPosition();
            var level = _stateMachine.GameSettings.GetLevel(ELevel.One);
            _stateMachine.CoinManager.InitCoinsForNewLevel(level);
            _stateMachine.GameUIManager.InitGameUI(level);
            _stateMachine.HeartManager.ResetHearts(level);
            _stateMachine.PlayerTeleportManager.SetTeleports();
            _stateMachine.EnemyManager.SpawnEnemy(level, _stateMachine.PlayerTransform);

            
            _stateMachine.CreateNewState(new GamePlayLevelOneState(_stateMachine));
        }
    }
}