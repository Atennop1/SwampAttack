using System.Collections.Generic;

namespace SwampAttack.Runtime.Tools.SaveSystem
{
    public interface ICollectionStorage<T>
    {
        public IEnumerable<T> Load(string key);
        public void Save(T saveObject, string key);
        public void RemoveElement(T saveObject, string key);
        
        public bool Exist(string key);
        void DeleteSave(string path);
    }
}