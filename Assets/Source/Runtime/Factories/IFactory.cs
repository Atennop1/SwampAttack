namespace SwampAttack.Runtime.Factories
{
    public interface IFactory<T>
    {
        T Create();
    }
}