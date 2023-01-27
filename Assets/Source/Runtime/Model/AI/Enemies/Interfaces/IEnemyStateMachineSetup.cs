namespace SwampAttack.Model.AI.Enemies
{
    public interface IEnemyStateMachineFactory
    {
        Model.AI.StateMachine.StateMachine Create();
    }
}