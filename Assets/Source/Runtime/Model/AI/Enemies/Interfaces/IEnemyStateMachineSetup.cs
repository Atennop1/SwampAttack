namespace SwampAttack.Runtime.Model.AI.Enemies.Interfaces
{
    public interface IEnemyStateMachineSetup
    {
        Model.AI.StateMachine.StateMachine BuildStateMachine();
    }
}