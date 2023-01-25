namespace SwampAttack.Factories
{
    public interface IFactory<T>
    {
        T Create();
    }
}