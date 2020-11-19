using UnityEngine;


namespace OMONGoose
{
    public sealed class PlayerController : IExecutable
    {
        #region Fields

        private CharacterController _characterController;
        private PlayerModel _playerModel;
        private TaskObject _visibleTask;
        private TaskObject _activeTask;
        private Transform _cameraTransform;
        private Transform _transform;
        private Animator _animator;
        private GameContext _links;
        private Vector3 gravity;
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
            _characterController = _playerModel.PlayerStruct.Player.GetComponent<CharacterController>();
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


        public void Execute()
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
                        _activeTask = _visibleTask;
                        UnlockCursor();
                        _animator.SetFloat(_speedName, 0.0f);
                    }
                    else
                    {
                        _isDoingTask = false;
                        _activeTask = null;
                        LockCursor();
                    }
                }
            }
            else if (_isDoingTask)
            {
                _activeTask.Switch();
                _isDoingTask = false;
                LockCursor();
            }
        }

        public void Look(float mouseX, float mouseY)
        {
            if (_isCursorLocked)
            {
                _xRotation -= mouseY * _playerModel.PlayerStruct.Sensitivity * Time.deltaTime;
                _xRotation = Mathf.Clamp(_xRotation, _minYRotation, _maxYRotation);
                _cameraTransform.localRotation = Quaternion.Euler(_xRotation, 0.0f, 0.0f);
                _transform.Rotate(Vector3.up * (mouseX * _playerModel.PlayerStruct.Sensitivity * Time.deltaTime));
            }
        }

        public void Move(float horizontal, float vertical)
        {
            if (_isCursorLocked)
            {
                Vector3 move = (_transform.right * horizontal + _transform.forward * vertical).normalized;
                _characterController.Move(move * (_playerModel.PlayerStruct.PlayerSpeed * Time.deltaTime));
                _animator.SetFloat(_speedName, _characterController.velocity.magnitude);
            }

            if (!_characterController.isGrounded)
            {
                gravity.y += Physics.gravity.y * Time.deltaTime;
                _characterController.Move(gravity * Time.deltaTime);
            }
            else
            {
                gravity.y = -2.0f;
            }
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

        public void Execute(float deltaTime)
        {
            Debug.Log("Why");
        }
    }
}