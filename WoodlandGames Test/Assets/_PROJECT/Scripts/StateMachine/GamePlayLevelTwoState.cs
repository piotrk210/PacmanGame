using _PROJECT.Scripts.Data;

namespace _PROJECT.Scripts.StateMachine
{
    public class GamePlayLevelTwoState : BaseState
    {
        public GamePlayLevelTwoState(GameStateMachine stateMachine) : base(stateMachine)
        { }

        public override void InitializeState()
        {
            _stateMachine.PlayerTeleportManager.SetStartingPosition();
            var level = _stateMachine.GameSettings.GetLevel(ELevel.Two);
            _stateMachine.CoinManager.InitCoinsForNewLevel(level);
            _stateMachine.EnemyManager.SpawnEnemy(level, _stateMachine.PlayerTransform);
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
                += () => { _stateMachine.CreateNewState(new WinState(_stateMachine)); };
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