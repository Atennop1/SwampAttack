namespace SwampAttack.Model.AI.Enemies
{
    public interface IEnemyStateMachineSetup
    {
        Model.AI.StateMachine.StateMachine BuildStateMachine();
    }
}