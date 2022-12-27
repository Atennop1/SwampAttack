using System.IO;
using SwampAttack.Runtime.Tools.Extensions;

namespace SwampAttack.Runtime.Tools.SaveSystem
{
    public class StorageWithNames<TUser, TObject>
    {
        private readonly string _path;
        private readonly IStorage _storage;
        
        public StorageWithNames()
        {
            _storage = new BinaryStorage();
            _path = Path.Combine(typeof(TUser).GetFriendlyName(), typeof(TObject).GetFriendlyName());
        }

        public void Save<T>(T item) => _storage.Save(item, _path);
        public T Load<T>() => _storage.Load<T>(_path);
        public bool Exist() => _storage.Exists(_path);
        public void DeleteSave() => _storage.DeleteSave(_path);
    }
}