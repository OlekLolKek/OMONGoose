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

        public void Save(IPlayerFactory player, Transform camera, TaskObject[] tasks, TaskModel taskModel)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }

            var transform = player.GetTransform();

            var tasksDone = new bool [tasks.Length];
            int doneTasksAmount = taskModel.TasksDone;
            for (int i = 0; i < tasks.Length; i++)
            {
                tasksDone[i] = tasks[i].IsDone;
            }
            
            var savedData = new SavedData
            {
                PlayerPosition = transform.position,
                PlayerRotation = transform.rotation,
                CameraRotation = camera.rotation,
                PlayerName = player.GetTransform().transform.name,
                IsEnabled = player.GetTransform().gameObject.activeSelf,
                TasksDone = tasksDone,
                DoneTasksAmount = doneTasksAmount,
            };

            _data.Save(savedData, Path.Combine(_path, _FILE_NAME));
        }

        public void Load(IPlayerFactory player, Transform cameraTransform, TaskObject[] tasks, TaskModel taskModel)
        {
            var file = Path.Combine(_path, _FILE_NAME);
            if (!File.Exists(file)) return;
            var savedData = _data.Load(file);

            var playerTransform = player.GetTransform();

            playerTransform.position = savedData.PlayerPosition;
            playerTransform.rotation = savedData.PlayerRotation;
            cameraTransform.rotation = savedData.CameraRotation;
            playerTransform.gameObject.name = savedData.PlayerName;
            playerTransform.gameObject.SetActive(savedData.IsEnabled);
            taskModel.TasksDone = savedData.DoneTasksAmount;

            for (int i = 0; i < savedData.TasksDone.Length; i++)
            {
                tasks[i].IsDone = savedData.TasksDone[i];
            }
            
            Debug.Log(cameraTransform.rotation);
        }

        #endregion
    }
}