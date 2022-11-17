namespace SwampAttack.Runtime.AI.StateMachine
{
    public interface IState
    {
        void Tick();
        void OnEnter();
        void OnExit();
    }
}