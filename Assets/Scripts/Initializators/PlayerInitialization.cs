using UnityEngine;
using UnityEngine.PlayerLoop;


namespace OMONGoose
{
    public sealed class PlayerInitialization : IInitializable
    {
        #region Fields

        private readonly CharacterController _characterController;
        private readonly Transform _transform;
        private readonly Camera _camera;

        #endregion
        
        public PlayerInitialization(IPlayerFactory playerFactory)
        {
            playerFactory.CreatePlayer();
            _characterController = playerFactory.GetCharacterController();
            _transform = playerFactory.GetTransform();
            _camera = playerFactory.GetCamera();
        }
        
        public void Initialization()
        {
            
        }

        public Transform GetTransform()
        {
            return _transform;
        }
        
        public Camera GetCamera()
        {
            return _camera;
        }
        public CharacterController GetCharacterController()
        {
            return _characterController;
        }
    }
}
