using UnityEngine;


namespace OMONGoose
{
    public sealed class PlayerController : IUpdatable
    {
        #region Fields

        private InputController _inputController;
        private PlayerModel _playerModel;
        private Transform _transform;
        private Transform _cameraTransform;
        private Rigidbody _rigidbody;
        private float _minYRotation = -90.0f;
        private float _maxYRotation = 90.0f;
        private float _xRotation = 0.0f;

        #endregion


        public PlayerController(PlayerModel playermodel)
        {
            _playerModel = playermodel;
            _rigidbody = _playerModel.PlayerStruct.Player.GetComponent<Rigidbody>();
            _transform = _playerModel.PlayerStruct.Player.transform;
            _cameraTransform = Camera.main.transform;
            _inputController = ServiceLocator.Resolve<InputController>();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        #region Methods

        public void UpdateTick()
        {
            Look();
            Move();
        }

        private void Look()
        {
            _xRotation -= _inputController.MouseY * _playerModel.PlayerStruct.Sensitivity * Time.deltaTime;
            _xRotation = Mathf.Clamp(_xRotation, _minYRotation, _maxYRotation);
            _cameraTransform.localRotation = Quaternion.Euler(_xRotation, 0.0f, 0.0f);
            _transform.Rotate(Vector3.up * _inputController.MouseX * _playerModel.PlayerStruct.Sensitivity * Time.deltaTime);
        }

        private void Move()
        {
            Vector3 move = (_transform.right * _inputController.Horizontal + _transform.forward * _inputController.Vertical).normalized;
            _rigidbody.velocity = move * _playerModel.PlayerStruct.PlayerSpeed;
        }

        #endregion
    }
}