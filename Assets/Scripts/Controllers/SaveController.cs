namespace OMONGoose
{
    public class SaveController : IInitializable, ICleanable
    {
        private SaveDataRepository _saveDataRepository;
        private IInputKeyPressable _load;
        private IInputKeyPressable _save;
        private IPlayerFactory _playerFactory;

        public SaveController(IInputKeyPressable load, IInputKeyPressable save, 
            SaveDataRepository saveDataRepository, IPlayerFactory playerFactory)
        {
            _saveDataRepository = saveDataRepository;
            _playerFactory = playerFactory;
            _load = load;
            _save = save;

            _load.OnKeyPressed += LoadGame;
            _save.OnKeyPressed += SaveGame;
        }
        
        public void Initialization()
        {
        }
        
        private void LoadGame(bool b)
        {
            _saveDataRepository.Load(_playerFactory);
        }

        private void SaveGame(bool b)
        {
            _saveDataRepository.Save(_playerFactory);
        }

        public void Cleanup()
        {
            _load.OnKeyPressed -= LoadGame;
            _save.OnKeyPressed -= SaveGame;
        }
    }
}