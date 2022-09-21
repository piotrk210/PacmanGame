namespace _PROJECT.Scripts.StateMachine
{
    public abstract class BaseState 
    {
        protected readonly GameStateMachine _stateMachine;

        protected BaseState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public virtual void InitializeState()
        {
        }

        public virtual void UpdateState()
        {
        }
        public virtual void FixUpdateState()
        {
        }

        public virtual void DisposeState()
        {
        }
        
    }
}
