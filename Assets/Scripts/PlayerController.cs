using UnityEngine;


namespace OMONGoose
{
    public sealed class PlayerController : IUpdatable
    {
        #region Fields

        private PlayerModel _playerModel;
        private Transform _transform;
        private Transform _cameraTransform;
        private Rigidbody _rigidbody;
        private Animator _animator;
        private string _speedName = "Speed";
        private float _minYRotation = -90.0f;
        private float _maxYRotation = 90.0f;
        private float _xRotation = 0.0f;

        #endregion


        public PlayerController(PlayerModel playermodel)
        {
            _playerModel = playermodel;
            _rigidbody = _playerModel.PlayerStruct.Player.GetComponent<Rigidbody>();
            _animator = _playerModel.PlayerStruct.Player.GetComponent<Animator>();
            _transform = _playerModel.PlayerStruct.Player.transform;
            _cameraTransform = Camera.main.transform;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        #region Methods

        public void UpdateTick()
        {

        }

        public void Look(float mouseX, float mouseY)
        {
            _xRotation -= mouseY * _playerModel.PlayerStruct.Sensitivity * Time.deltaTime;
            _xRotation = Mathf.Clamp(_xRotation, _minYRotation, _maxYRotation);
            _cameraTransform.localRotation = Quaternion.Euler(_xRotation, 0.0f, 0.0f);
            _transform.Rotate(Vector3.up * mouseX * _playerModel.PlayerStruct.Sensitivity * Time.deltaTime);
        }

        public void Move(float horizontal, float vertical)
        {
            Vector3 move = (_transform.right * horizontal + _transform.forward * vertical).normalized;
            _rigidbody.velocity = move * _playerModel.PlayerStruct.PlayerSpeed;
            _animator.SetFloat(_speedName, _rigidbody.velocity.magnitude);
        }

        #endregion
    }
}