using UnityEngine;


namespace OMONGoose
{
    public class SaveController : IInitializable, ICleanable
    {
        private readonly SaveDataRepository _saveDataRepository;
        private readonly IInputKeyPressable _load;
        private readonly IInputKeyPressable _save;
        private readonly IPlayerFactory _playerFactory;
        private readonly Transform _cameraTransform;
        private readonly TaskModel _taskModel;
        private readonly TaskObject[] _tasks;

        public SaveController(IInputKeyPressable load, IInputKeyPressable save,
            SaveDataRepository saveDataRepository, IPlayerFactory playerFactory, Transform cameraTransform, TaskModel taskModel)
        {
            _taskModel = taskModel;
            _saveDataRepository = saveDataRepository;
            _playerFactory = playerFactory;
            _cameraTransform = cameraTransform;
            _load = load;
            _save = save;
            _tasks = taskModel.GetTasks();

            _load.OnKeyPressed += LoadGame;
            _save.OnKeyPressed += SaveGame;
        }
        
        public void Initialization()
        {
        }
        
        private void LoadGame(bool b)
        {
            _saveDataRepository.Load(_playerFactory, _cameraTransform, _tasks, _taskModel);
        }

        private void SaveGame(bool b)
        {
            _saveDataRepository.Save(_playerFactory, _cameraTransform, _tasks, _taskModel);
        }

        public void Cleanup()
        {
            _load.OnKeyPressed -= LoadGame;
            _save.OnKeyPressed -= SaveGame;
        }
    }
}