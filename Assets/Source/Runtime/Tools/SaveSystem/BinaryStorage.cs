using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SwampAttack.Tools
{
    public sealed class BinaryStorage : IStorage
    {
        private readonly BinaryFormatter _formatter = new();

        public void DeleteSave(string path)
        {
            var allPath = CreatePath(path);

            if (Exists(allPath) == false)
                throw new InvalidOperationException(nameof(DeleteSave));

            File.Delete(allPath);
        }

        public T Load<T>(string path)
        {
            var allPath = CreatePath(path);

            if (Exists(path) == false)
                throw new InvalidOperationException(nameof(Load));

            using var file = File.Open(allPath, FileMode.Open);
            return (T)_formatter.Deserialize(file);
        }

        public void Save<T>(T saveObject, string path)
        {
            var allPath = CreatePath(path);
            Directory.CreateDirectory(Path.GetDirectoryName(allPath) ?? string.Empty);
            
            using var file = File.Create(allPath);
            _formatter.Serialize(file, saveObject);
        }

        public bool Exists(string key) 
            => File.Exists(CreatePath(key));
        
        private string CreatePath(string name) 
            => Path.Combine(Application.persistentDataPath, name);
    }
}