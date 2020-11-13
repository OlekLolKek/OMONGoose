using System.IO;
using UnityEngine;


namespace OMONGoose
{
    public sealed class SaveDataRepository
    {
        #region Fields

        private readonly IData<SavedData> _data;

        private const string _FOLDER_NAME = "dataSave";
        private const string _FILE_NAME = "data.bat";
        private readonly string _path;

        #endregion

        public SaveDataRepository()
        {
            _data = new JsonData<SavedData>();
            _path = Path.Combine(Application.dataPath, _FOLDER_NAME);
        }

        #region Methods

        public void Save(IPlayerFactory player)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }

            var transform = player.GetTransform();
            
            var savePlayer = new SavedData
            {
                Position = transform.position,
                Rotation = transform.rotation,
                Name = player.GetTransform().transform.name,
                IsEnabled = player.GetTransform().gameObject.activeSelf
            };
            Debug.Log(savePlayer);
            
            _data.Save(savePlayer, Path.Combine(_path, _FILE_NAME));
        }

        public void Load(IPlayerFactory player)
        {
            var file = Path.Combine(_path, _FILE_NAME);
            if (!File.Exists(file)) return;
            var newPlayer = _data.Load(file);

            var transform = player.GetTransform();
            
            Debug.Log(transform.position);
            
            transform.position = newPlayer.Position;
            transform.rotation = newPlayer.Rotation;
            transform.gameObject.name = newPlayer.Name;
            transform.gameObject.SetActive(newPlayer.IsEnabled);
            
            Debug.Log(player.GetTransform().position);
        }

        #endregion
    }
}