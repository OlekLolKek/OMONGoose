using UnityEngine;


namespace OMONGoose
{
    public sealed class PlayerController : IUpdatable
    {
        #region Fields

        private GameContext _links;
        private PlayerModel _playerModel;
        private Transform _transform;
        private Transform _cameraTransform;
        private Rigidbody _rigidbody;
        private Animator _animator;
        private TaskObject _visibleTask;
        private string _speedName = "Speed";
        private float _minYRotation = -90.0f;
        private float _maxYRotation = 90.0f;
        private float _xRotation = 0.0f;
        private bool _seesTask = false;
        private bool _isDoingTask = false;
        private bool _isCursorLocked = true;

        #endregion


        public PlayerController(PlayerModel playermodel, GameContext links)
        {
            _links = links;
            _playerModel = playermodel;
            _rigidbody = _playerModel.PlayerStruct.Player.GetComponent<Rigidbody>();
            _animator = _playerModel.PlayerStruct.Player.GetComponent<Animator>();
            _transform = _playerModel.PlayerStruct.Player.transform;
            _cameraTransform = Camera.main.transform;

            LockCursor();
        }

        #region Methods

        public void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _isCursorLocked = true;
        }

        public void UnlockCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _isCursorLocked = false;
        }


        public void UpdateTick()
        {
            CheckTask();
        }

        public void UseTask()
        {
            if (_seesTask)
            {
                if (!_visibleTask.IsDone)
                {
                    _visibleTask.Switch();
                    if (!_isDoingTask)
                    {
                        _isDoingTask = true;
                        UnlockCursor();
                        Stop();
                    }
                    else
                    {
                        _isDoingTask = false;
                        LockCursor();
                    }
                }
            }
        }

        public void Look(float mouseX, float mouseY)
        {
            if (_isCursorLocked)
            {
                _xRotation -= mouseY * _playerModel.PlayerStruct.Sensitivity * Time.deltaTime;
                _xRotation = Mathf.Clamp(_xRotation, _minYRotation, _maxYRotation);
                _cameraTransform.localRotation = Quaternion.Euler(_xRotation, 0.0f, 0.0f);
                _transform.Rotate(Vector3.up * mouseX * _playerModel.PlayerStruct.Sensitivity * Time.deltaTime);
            }
        }

        public void Move(float horizontal, float vertical)
        {
            if (_isCursorLocked)
            {
                Vector3 move = (_transform.right * horizontal + _transform.forward * vertical).normalized;
                _rigidbody.velocity = move * _playerModel.PlayerStruct.PlayerSpeed;
                _animator.SetFloat(_speedName, _rigidbody.velocity.magnitude);
            }
        }

        private void Stop()
        {
            _rigidbody.velocity = Vector3.zero;
            _animator.SetFloat(_speedName, 0.0f);
        }


        private void CheckTask()
        {
            Ray ray = new Ray(_cameraTransform.position, _cameraTransform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, 3))
            {
                if (hit.collider.TryGetComponent<TaskObject>(out var task))
                {
                    _seesTask = true;
                    _visibleTask = task;
                    _links.CrosshairView.TaskLocated();
                }
                else
                {
                    _seesTask = false;
                    _visibleTask = null;
                    _links.CrosshairView.TaskUnlocated();
                }
            }
            else
            {
                _seesTask = false;
                _visibleTask = null;
                _links.CrosshairView.TaskUnlocated();
            }
        }

        #endregion
    }
}