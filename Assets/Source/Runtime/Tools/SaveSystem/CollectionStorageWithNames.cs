using System.Collections.Generic;
using System.IO;

namespace SwampAttack.Runtime.Tools.SaveSystem
{
    public class CollectionStorageWithNames<TUser, TObject>
    {
        private readonly string _path;
        private readonly ICollectionStorage<TObject> _storage;
        
        public CollectionStorageWithNames()
        {
            _storage = new CollectionStorage<TObject>(new BinaryStorage());
            _path = Path.Combine(typeof(TUser).Name, typeof(TObject).Name);
        }

        public void Save(TObject item) => _storage.Save(item, _path);
        public void RemoveElement(TObject item) => _storage.RemoveElement(item, _path);
        public IEnumerable<TObject> Load() => _storage.Load(_path);
        public bool Exist() => _storage.Exist(_path);
        public void DeleteSave() => _storage.DeleteSave(_path);
    }
}