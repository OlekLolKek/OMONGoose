using UnityEngine;
using System.IO;


namespace OMONGoose
{
    public class JsonData<T> : IData<T>
    {
        public void Save(T data, string path = null)
        {
            var contents = JsonUtility.ToJson(data);
            File.WriteAllText(path, Crypto.XOR(contents));
        }

        public T Load(string path = null)
        {
            var contents = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(Crypto.XOR(contents));
        }
    }
}