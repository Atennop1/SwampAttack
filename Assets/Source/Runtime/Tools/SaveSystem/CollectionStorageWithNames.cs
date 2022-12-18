using System;
using System.Collections.Generic;
using System.IO;
using SwampAttack.Runtime.Tools.Extensions;

namespace SwampAttack.Runtime.Tools.SaveSystem
{
    public class CollectionStorageWithNames<TUser, TObject>
    {
        private readonly string _path;
        private readonly ICollectionStorage<TObject> _storage;
        
        public CollectionStorageWithNames()
        {
            _path = Path.Combine(typeof(TUser).GetFriendlyName(), typeof(TObject).GetFriendlyName());
            _storage = new CollectionStorage<TObject>(new BinaryStorage());
        }

        public void Save(TObject item) => _storage.Save(item, _path);
        public void RemoveElement(TObject item) => _storage.RemoveElement(item, _path);
        public IEnumerable<TObject> Load() => _storage.Load(_path);
        public bool Exist() => _storage.Exists(_path);
        public void DeleteSave() => _storage.DeleteSave(_path);
    }
}