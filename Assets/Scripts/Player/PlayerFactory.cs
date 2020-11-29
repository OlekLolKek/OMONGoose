using UnityEngine;


namespace OMONGoose
{
    public sealed class PlayerFactory : IPlayerFactory
    {
        private readonly PlayerData _playerData;
        private CharacterController _characterController;
        private Transform _transform;
        private Animator _animator;
        private GameObject _player;
        private Camera _camera;

        public PlayerFactory(PlayerData playerData)
        {
            _playerData = playerData;
        }

        public void CreatePlayer()
        {
            //Так как игрок - не просто кружок, а полноценный персонаж с анимациями, решил заменить постепенное создание на префаб 
            //Возможно, поменяю позже на постепенное формирование игрока
            _player = Object.Instantiate(_playerData.PlayerPrefab);
            _transform = _player.transform;
            _characterController = _player.GetComponent<CharacterController>();
            _camera = _player.GetComponentInChildren<Camera>();
            _animator = _player.GetComponent<Animator>();
        }

        public Camera GetCamera()
        {
            return _camera;
        }

        public Transform GetTransform()
        {
            return _transform;
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