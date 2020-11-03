using System.IO;
using UnityEngine;


namespace OMONGoose
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public sealed class Data : ScriptableObject
    {
        #region Fields

        [SerializeField] private string _audioClipsDataPath;
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _taskDataPath;
        private AudioClipsData _audioClipsData;
        private PlayerData _playerData;
        private TaskData _taskData;

        #endregion


        #region Properties

        public AudioClipsData AudioClipsData
        {
            get
            {
                if (_audioClipsData == null)
                {
                    _audioClipsData = Load<AudioClipsData>("Data/" + _audioClipsDataPath);
                }

                return _audioClipsData;
            }
        }
        
        public PlayerData PlayerData
        {
            get
            {
                if (_playerData == null)
                {
                    _playerData = Load<PlayerData>("Data/" + _playerDataPath);
                }

                return _playerData;
            }
        }

        public TaskData TaskData
        {
            get
            {
                if (_taskData == null)
                {
                    _taskData = Load<TaskData>("Data/" + _taskDataPath);
                }

                return _taskData;
            }
        }

        #endregion

        private T Load<T>(string resourcesPath) where T : Object
        {
            return Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
        }
    }
}