namespace SwampAttack.Root
{
    public interface ISystemUpdate
    {
        public void Add(params IUpdatable[] updatables);
        public void Remove(IUpdatable updatable);
        public void UpdateAll();
    }
}