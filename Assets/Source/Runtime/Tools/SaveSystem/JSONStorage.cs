using System;
using System.IO;
using UnityEngine;

namespace SwampAttack.Runtime.Tools.SaveSystem
{
    public class JSONStorage : IStorage
    {
        public void Save<T>(T item, string path)
        {
            var jsonPath = CreatePath(path);
            var saveJson = JsonUtility.ToJson(item);
            
            Directory.CreateDirectory(Path.GetDirectoryName(jsonPath) ?? string.Empty);
            File.WriteAllText(jsonPath, saveJson);
        }

        public T Load<T>(string path)
        {
            var jsonPath = CreatePath(path);

            if (Exists(path) == false)
                throw new ArgumentException($"Saves doesn't contains object with path {path}");

            var jsonString = File.ReadAllText(jsonPath);
            return JsonUtility.FromJson<T>(jsonString);
        }

        public bool Exists(string path) => File.Exists(CreatePath(path));

        public void DeleteSave(string path)
        {
            var jsonPath = CreatePath(path);

            if (Exists(path) == false)
                throw new ArgumentException($"Saves doesn't contains object with path {path}");
            
            File.Delete(jsonPath);
        }

        private string CreatePath(string path) 
            => Path.Combine(Application.persistentDataPath, path);
    }
}