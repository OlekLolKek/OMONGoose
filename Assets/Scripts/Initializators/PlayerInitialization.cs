using UnityEngine;
using UnityEngine.PlayerLoop;


namespace OMONGoose
{
    public sealed class PlayerInitialization : IInitializable
    {
        #region Fields

        private readonly IPlayerFactory _playerFactory;
        private CharacterController _player;

        #endregion
        
        public PlayerInitialization(IPlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
            _player = _playerFactory.CreatePlayer();
        }
        
        public void Initialization()
        {
            
        }

        public CharacterController GetPlayer()
        {
            return _player;
        }
    }
}
