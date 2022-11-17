namespace SwampAttack.Runtime.Root.SystemUpdates
{
    public interface ISystemUpdate
    {
        public void Add(params IUpdatable[] updatables);
        public void Remove(IUpdatable updatable);
        public void UpdateAll();
    }
}