using System;
using System.Collections.Generic;

namespace SwampAttack.Runtime.Tools.SaveSystem
{
    public class CollectionStorage<T> : ICollectionStorage<T>
    {
        private readonly List<T> _allSavedObject = new();
        private readonly IStorage _storage;

        public CollectionStorage(IStorage storage)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }

        public IEnumerable<T> Load(string key)
        {
            if (Exist(key) == false)
                throw new InvalidOperationException("Storage doesn't have save!");
            
            return _storage.Load<IEnumerable<T>>(key);
        }

        public void Save(T saveObject, string key)
        {
            _allSavedObject.Add(saveObject);
            _storage.Save(_allSavedObject, key);
        }

        public void RemoveElement(T saveObject, string key)
        {
            _allSavedObject.Remove(saveObject);
            _storage.Save(_allSavedObject, key);
        }

        public bool Exist(string key) => _storage.Exist(key);
        public void DeleteSave(string key) => _storage.DeleteSave(key);
    }
}