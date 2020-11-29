using UnityEngine;


namespace OMONGoose
{
    public sealed class PlayerModel
    {
        #region Fields

        private readonly CharacterController _characterController;
        private readonly Transform _transform;
        private readonly Animator _animator;
        private readonly Camera _camera;

        #endregion
        
        public PlayerModel(IPlayerFactory playerFactory)
        {
            playerFactory.CreatePlayer();
            _characterController = playerFactory.GetCharacterController();
            _transform = playerFactory.GetTransform();
            _camera = playerFactory.GetCamera();
            _animator = playerFactory.GetAnimator();
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

        public Animator GetAnimator()
        {
            return _animator;
        }
    }
}
