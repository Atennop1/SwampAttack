namespace SwampAttack.Runtime.Tools.SaveSystem
{
    public interface IStorage
    {
        void Save<T>(T item, string path);
        T Load<T>(string path);

        bool Exist(string path);
        void DeleteSave(string path);
    }
}